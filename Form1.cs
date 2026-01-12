using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PSZ_ManualSoft
{
    public partial class Form1 : Form
    {
        List<DeviceRecord> devices = new List<DeviceRecord>();
        string dataFile => Path.Combine(Application.StartupPath, "devices.txt");

        public Form1()
        {
            InitializeComponent();

            LoadDevices();
            FillCategoryCombo();
            RefreshList();

            deviceListBox.SelectedIndexChanged += (s, e) => ShowDetails(Selected);
            searchTextBox.TextChanged += (s, e) => RefreshList();
            categoryFilterCombo.SelectedIndexChanged += (s, e) => RefreshList();

            openManualButton.Click += (s, e) => Open(Selected?.Manual);
            openWarrantyButton.Click += (s, e) => Open(Selected?.Warranty);
            openInvoiceButton.Click += (s, e) => Open(Selected?.Invoice);

            newButton.Click += (s, e) => AddDevice();
            deleteButton.Click += (s, e) => DeleteDevice();
            exitButton.Click += (s, e) => Close();

            FormClosing += (s, e) => SaveDevices();
        }

        DeviceRecord Selected => deviceListBox.SelectedItem as DeviceRecord;

        void LoadDevices()
        {
            devices.Clear();
            if (!File.Exists(dataFile)) return;

            foreach (var line in File.ReadAllLines(dataFile))
            {
                var d = DeviceRecord.Parse(line);
                if (d != null) devices.Add(d);
            }
        }

        void SaveDevices()
        {
            var lines = devices.Select(d => d.ToLine()).ToArray();
            File.WriteAllLines(dataFile, lines);
        }

        void FillCategoryCombo()
        {
            var cats = devices.Select(d => d.Category)
                              .Where(c => !string.IsNullOrWhiteSpace(c))
                              .Distinct()
                              .OrderBy(c => c)
                              .ToArray();

            categoryFilterCombo.Items.Clear();
            categoryFilterCombo.Items.Add("Összes kategória");
            categoryFilterCombo.Items.AddRange(cats);
            categoryFilterCombo.SelectedIndex = 0;
        }

        void RefreshList()
        {
            string s = (searchTextBox.Text ?? "").Trim();
            string cat = categoryFilterCombo.SelectedItem?.ToString() ?? "Összes kategória";

            var filtered = devices.Where(d =>
                    (string.IsNullOrWhiteSpace(s) || d.Name.IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0) &&
                    (cat == "Összes kategória" || string.Equals(d.Category, cat, StringComparison.OrdinalIgnoreCase))
                )
                .OrderBy(d => d.Name)
                .ToList();

            deviceListBox.DataSource = filtered;
            deviceListBox.DisplayMember = nameof(DeviceRecord.Name);

            ShowDetails(Selected);
        }

        void ShowDetails(DeviceRecord d)
        {
            bool ok = d != null;

            nameValueLabel.Text = ok ? d.Name : "-";
            categoryValueLabel.Text = ok ? d.Category : "-";
            manualValueLabel.Text = ok ? d.Manual : "-";
            warrantyValueLabel.Text = ok ? d.Warranty : "-";
            invoiceValueLabel.Text = ok ? d.Invoice : "-";

            openManualButton.Enabled = ok;
            openWarrantyButton.Enabled = ok;
            openInvoiceButton.Enabled = ok;

            devicePicture.Image = ok ? LoadImage(d.Image) : null;
        }

        void AddDevice()
        {
            using (var dlg = new NewDeviceForm())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK && dlg.Result != null)
                {
                    devices.Add(dlg.Result);
                    FillCategoryCombo();
                    RefreshList();
                }
            }
        }

        void DeleteDevice()
        {
            if (!(Selected is DeviceRecord d)) return;

            if (MessageBox.Show($"Biztosan törlöd: {d.Name} ?", "Törlés",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                devices.Remove(d);
                FillCategoryCombo();
                RefreshList();
            }
        }

        void Open(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw))
            {
                MessageBox.Show("Nincs megadva elérési út.", "Info");
                return;
            }

            string target = Resolve(raw);

            try
            {
                Process.Start(new ProcessStartInfo { FileName = target, UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nem sikerült megnyitni: " + ex.Message, "Hiba");
            }
        }

        string Resolve(string raw)
        {
            raw = raw.Trim().Trim('"');

            if (Uri.IsWellFormedUriString(raw, UriKind.Absolute))
                return raw;

            if (File.Exists(raw))
                return raw;

            string baseDir = Application.StartupPath;

            const string marker = "\\bin\\Debug\\";
            int i = raw.IndexOf(marker, StringComparison.OrdinalIgnoreCase);
            if (i >= 0)
            {
                string after = raw.Substring(i + marker.Length);
                string p = Path.Combine(baseDir, after);
                if (File.Exists(p)) return p;
            }

            string file = Path.GetFileName(raw);
            string[] folders = { "Kezikonyvek", "Garanciak", "Szamlak", "Kepek" };
            foreach (var f in folders)
            {
                string p = Path.Combine(baseDir, f, file);
                if (File.Exists(p)) return p;
            }

            return raw;
        }

        Image LoadImage(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw)) return null;

            string p = Resolve(raw);
            if (Uri.IsWellFormedUriString(p, UriKind.Absolute)) return null;

            if (!File.Exists(p)) return null;

            try { return Image.FromFile(p); }
            catch { return null; }
        }

        class DeviceRecord
        {
            public string Name, Category, Manual, Warranty, Invoice, Image;

            public override string ToString() => Name;

            public string ToLine()
                => string.Join("|", Name, Category, Manual, Warranty, Invoice, Image);

            public static DeviceRecord Parse(string line)
            {
                if (string.IsNullOrWhiteSpace(line)) return null;

                var p = line.Split('|');
                if (p.Length < 6) return null;

                return new DeviceRecord
                {
                    Name = p[0].Trim().Trim('"'),
                    Category = p[1].Trim().Trim('"'),
                    Manual = p[2].Trim(),
                    Warranty = p[3].Trim(),
                    Invoice = p[4].Trim(),
                    Image = p[5].Trim()
                };
            }
        }

        class NewDeviceForm : Form
        {
            public DeviceRecord Result;

            TextBox tName = new TextBox();
            TextBox tCat = new TextBox();
            TextBox tMan = new TextBox();
            TextBox tWar = new TextBox();
            TextBox tInv = new TextBox();
            TextBox tImg = new TextBox();

            public NewDeviceForm()
            {
                Text = "Új eszköz";
                Width = 600; Height = 330;
                StartPosition = FormStartPosition.CenterParent;
                FormBorderStyle = FormBorderStyle.FixedDialog;
                MaximizeBox = false; MinimizeBox = false;
                Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);

                var grid = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 3, RowCount = 7, Padding = new Padding(10) };
                grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140));
                grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
                grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90));

                AddRow(grid, 0, "Név", tName, null);
                AddRow(grid, 1, "Kategória", tCat, null);
                AddRow(grid, 2, "Kézikönyv", tMan, () => PickFile(tMan));
                AddRow(grid, 3, "Garancia", tWar, () => PickFile(tWar));
                AddRow(grid, 4, "Számla", tInv, () => PickFile(tInv));
                AddRow(grid, 5, "Kép", tImg, () => PickImage(tImg));

                var btnOk = new Button { Text = "Mentés", Dock = DockStyle.Fill };
                var btnNo = new Button { Text = "Mégse", Dock = DockStyle.Fill };

                btnOk.Click += (s, e) =>
                {
                    if (string.IsNullOrWhiteSpace(tName.Text))
                    {
                        MessageBox.Show("A név kötelező.");
                        return;
                    }

                    Result = new DeviceRecord
                    {
                        Name = tName.Text.Trim(),
                        Category = tCat.Text.Trim(),
                        Manual = tMan.Text.Trim(),
                        Warranty = tWar.Text.Trim(),
                        Invoice = tInv.Text.Trim(),
                        Image = tImg.Text.Trim()
                    };
                    DialogResult = DialogResult.OK;
                };

                btnNo.Click += (s, e) => DialogResult = DialogResult.Cancel;

                grid.Controls.Add(btnOk, 1, 6);
                grid.Controls.Add(btnNo, 2, 6);

                Controls.Add(grid);
            }

            void AddRow(TableLayoutPanel g, int r, string label, TextBox box, Action browse)
            {
                g.RowStyles.Add(new RowStyle(SizeType.Absolute, 38));

                g.Controls.Add(new Label { Text = label, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft }, 0, r);
                box.Dock = DockStyle.Fill;
                g.Controls.Add(box, 1, r);

                if (browse != null)
                {
                    var b = new Button { Text = "Tallóz", Dock = DockStyle.Fill };
                    b.Click += (s, e) => browse();
                    g.Controls.Add(b, 2, r);
                }
            }

            void PickFile(TextBox t)
            {
                using (var d = new OpenFileDialog())
                    if (d.ShowDialog(this) == DialogResult.OK) t.Text = d.FileName;
            }

            void PickImage(TextBox t)
            {
                using (var d = new OpenFileDialog())
                {
                    d.Filter = "Képek|*.png;*.jpg;*.jpeg;*.bmp";
                    if (d.ShowDialog(this) == DialogResult.OK) t.Text = d.FileName;
                }
            }

        }
    }
}

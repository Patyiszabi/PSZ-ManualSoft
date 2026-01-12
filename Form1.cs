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
        private readonly List<DeviceRecord> _allDevices = new List<DeviceRecord>();
        private readonly string _dataFilePath = Path.Combine(Application.StartupPath, "devices.txt");
        private bool _isDirty;

        public Form1()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            LoadFromFile();
            if (_allDevices.Count == 0)
            {
                _allDevices.AddRange(DeviceRecord.SampleData());
                _isDirty = true;
            }

            RefreshCategoryFilter();
            ApplyFilters();
        }

        private void RefreshCategoryFilter()
        {
            var categories = _allDevices
                .Select(device => device.Category)
                .Where(category => !string.IsNullOrWhiteSpace(category))
                .Distinct()
                .OrderBy(category => category)
                .ToList();

            categoryFilterCombo.Items.Clear();
            categoryFilterCombo.Items.Add("Összes kategória");
            categoryFilterCombo.Items.AddRange(categories.ToArray());
            categoryFilterCombo.SelectedIndex = 0;
        }

        private void ApplyFilters()
        {
            var search = searchTextBox.Text?.Trim() ?? string.Empty;
            var categoryFilter = categoryFilterCombo.SelectedItem?.ToString() ?? "Összes kategória";

            IEnumerable<DeviceRecord> filtered = _allDevices;

            if (!string.IsNullOrWhiteSpace(search))
            {
                filtered = filtered.Where(device =>
                    device.Name.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            if (!string.Equals(categoryFilter, "Összes kategória", StringComparison.OrdinalIgnoreCase))
            {
                filtered = filtered.Where(device =>
                    string.Equals(device.Category, categoryFilter, StringComparison.OrdinalIgnoreCase));
            }

            deviceListBox.DataSource = filtered.ToList();
            deviceListBox.DisplayMember = nameof(DeviceRecord.Name);
            UpdateDetails(deviceListBox.SelectedItem as DeviceRecord);
        }

        private void LoadFromFile()
        {
            _allDevices.Clear();
            if (!File.Exists(_dataFilePath))
            {
                return;
            }

            foreach (var line in File.ReadAllLines(_dataFilePath))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                var record = DeviceRecord.FromStorage(line);
                if (record != null)
                {
                    _allDevices.Add(record);
                }
            }
        }

        private void SaveToFile()
        {
            var lines = _allDevices.Select(device => device.ToStorage()).ToArray();
            File.WriteAllLines(_dataFilePath, lines);
            _isDirty = false;
        }

        private void UpdateDetails(DeviceRecord record)
        {
            if (record == null)
            {
                nameValueLabel.Text = "-";
                categoryValueLabel.Text = "-";
                manualValueLabel.Text = "-";
                warrantyValueLabel.Text = "-";
                invoiceValueLabel.Text = "-";
                devicePicture.Image = null;
                openManualButton.Enabled = false;
                openWarrantyButton.Enabled = false;
                openInvoiceButton.Enabled = false;
                return;
            }

            nameValueLabel.Text = record.Name;
            categoryValueLabel.Text = record.Category;
            manualValueLabel.Text = record.ManualPath;
            warrantyValueLabel.Text = record.WarrantyPath;
            invoiceValueLabel.Text = record.InvoicePath;
            devicePicture.Image = record.LoadImage();
            openManualButton.Enabled = true;
            openWarrantyButton.Enabled = true;
            openInvoiceButton.Enabled = true;
        }

        private void deviceListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDetails(deviceListBox.SelectedItem as DeviceRecord);
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void categoryFilterCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new NewDeviceForm())
            {
                if (dialog.ShowDialog(this) == DialogResult.OK && dialog.CreatedDevice != null)
                {
                    _allDevices.Add(dialog.CreatedDevice);
                    _isDirty = true;
                    RefreshCategoryFilter();
                    ApplyFilters();
                    deviceListBox.SelectedItem = dialog.CreatedDevice;
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (deviceListBox.SelectedItem is DeviceRecord record)
            {
                var result = MessageBox.Show(
                    $"Biztosan törli a(z) {record.Name} eszközt?",
                    "Törlés megerősítése",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    _allDevices.Remove(record);
                    _isDirty = true;
                    RefreshCategoryFilter();
                    ApplyFilters();
                }
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openManualButton_Click(object sender, EventArgs e)
        {
            OpenResource((deviceListBox.SelectedItem as DeviceRecord)?.ManualPath);
        }

        private void openWarrantyButton_Click(object sender, EventArgs e)
        {
            OpenResource((deviceListBox.SelectedItem as DeviceRecord)?.WarrantyPath);
        }

        private void openInvoiceButton_Click(object sender, EventArgs e)
        {
            OpenResource((deviceListBox.SelectedItem as DeviceRecord)?.InvoicePath);
        }

        private void OpenResource(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                MessageBox.Show("Nincs megadva elérési út.", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = path,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Nem sikerült megnyitni: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isDirty)
            {
                SaveToFile();
            }
        }

        private class DeviceRecord
        {
            public string Name { get; }
            public string Category { get; }
            public string ManualPath { get; }
            public string WarrantyPath { get; }
            public string InvoicePath { get; }
            public string ImagePath { get; }

            public DeviceRecord(string name, string category, string manualPath, string warrantyPath, string invoicePath, string imagePath)
            {
                Name = name;
                Category = category;
                ManualPath = manualPath;
                WarrantyPath = warrantyPath;
                InvoicePath = invoicePath;
                ImagePath = imagePath;
            }

            public string ToStorage()
            {
                return string.Join("|",
                    Escape(Name),
                    Escape(Category),
                    Escape(ManualPath),
                    Escape(WarrantyPath),
                    Escape(InvoicePath),
                    Escape(ImagePath));
            }

            public static DeviceRecord FromStorage(string line)
            {
                var parts = line.Split('|');
                if (parts.Length < 6)
                {
                    return null;
                }

                return new DeviceRecord(
                    Unescape(parts[0]),
                    Unescape(parts[1]),
                    Unescape(parts[2]),
                    Unescape(parts[3]),
                    Unescape(parts[4]),
                    Unescape(parts[5]));
            }

            public Image LoadImage()
            {
                if (string.IsNullOrWhiteSpace(ImagePath))
                {
                    return null;
                }

                if (!File.Exists(ImagePath))
                {
                    return null;
                }

                var bytes = File.ReadAllBytes(ImagePath);
                return Image.FromStream(new MemoryStream(bytes));
            }

            public override string ToString()
            {
                return Name;
            }

            private static string Escape(string value)
            {
                return value?.Replace("\\", "\\\\").Replace("|", "\\|") ?? string.Empty;
            }

            private static string Unescape(string value)
            {
                return value.Replace("\\|", "|").Replace("\\\\", "\\");
            }

            public static IEnumerable<DeviceRecord> SampleData()
            {
                return new[]
                {
                    new DeviceRecord("LG OLED televízió", "Szórakoztató elektronika",
                        "https://example.com/manuals/lg-oled.pdf",
                        "C:\\Dokumentumok\\Garanciak\\lg-oled-garancia.pdf",
                        "C:\\Dokumentumok\\Szamlak\\lg-oled-szamla.pdf",
                        "C:\\Dokumentumok\\Kepek\\lg-oled.jpg"),
                    new DeviceRecord("Apple MacBook Air", "Számítástechnika",
                        "https://example.com/manuals/macbook-air.pdf",
                        "C:\\Dokumentumok\\Garanciak\\macbook-air-garancia.pdf",
                        "C:\\Dokumentumok\\Szamlak\\macbook-air-szamla.pdf",
                        "C:\\Dokumentumok\\Kepek\\macbook-air.jpg"),
                    new DeviceRecord("Philips Hue starter", "Okosotthon",
                        "https://example.com/manuals/philips-hue.pdf",
                        "C:\\Dokumentumok\\Garanciak\\philips-hue-garancia.pdf",
                        "C:\\Dokumentumok\\Szamlak\\philips-hue-szamla.pdf",
                        "C:\\Dokumentumok\\Kepek\\philips-hue.jpg"),
                    new DeviceRecord("Bosch mosógép", "Háztartási gép",
                        "https://example.com/manuals/bosch-washer.pdf",
                        "C:\\Dokumentumok\\Garanciak\\bosch-washer-garancia.pdf",
                        "C:\\Dokumentumok\\Szamlak\\bosch-washer-szamla.pdf",
                        "C:\\Dokumentumok\\Kepek\\bosch-washer.jpg"),
                    new DeviceRecord("Dyson V15 porszívó", "Háztartási gép",
                        "https://example.com/manuals/dyson-v15.pdf",
                        "C:\\Dokumentumok\\Garanciak\\dyson-v15-garancia.pdf",
                        "C:\\Dokumentumok\\Szamlak\\dyson-v15-szamla.pdf",
                        "C:\\Dokumentumok\\Kepek\\dyson-v15.jpg"),
                    new DeviceRecord("Samsung Galaxy telefon", "Mobil eszköz",
                        "https://example.com/manuals/galaxy.pdf",
                        "C:\\Dokumentumok\\Garanciak\\galaxy-garancia.pdf",
                        "C:\\Dokumentumok\\Szamlak\\galaxy-szamla.pdf",
                        "C:\\Dokumentumok\\Kepek\\galaxy.jpg"),
                    new DeviceRecord("Sony WH-1000XM5", "Audio",
                        "https://example.com/manuals/sony-wh1000xm5.pdf",
                        "C:\\Dokumentumok\\Garanciak\\sony-wh1000xm5-garancia.pdf",
                        "C:\\Dokumentumok\\Szamlak\\sony-wh1000xm5-szamla.pdf",
                        "C:\\Dokumentumok\\Kepek\\sony-wh1000xm5.jpg"),
                    new DeviceRecord("Canon EOS fényképező", "Fotó",
                        "https://example.com/manuals/canon-eos.pdf",
                        "C:\\Dokumentumok\\Garanciak\\canon-eos-garancia.pdf",
                        "C:\\Dokumentumok\\Szamlak\\canon-eos-szamla.pdf",
                        "C:\\Dokumentumok\\Kepek\\canon-eos.jpg"),
                    new DeviceRecord("PlayStation 5", "Játékkonzol",
                        "https://example.com/manuals/ps5.pdf",
                        "C:\\Dokumentumok\\Garanciak\\ps5-garancia.pdf",
                        "C:\\Dokumentumok\\Szamlak\\ps5-szamla.pdf",
                        "C:\\Dokumentumok\\Kepek\\ps5.jpg"),
                    new DeviceRecord("Xiaomi robotporszívó", "Okosotthon",
                        "https://example.com/manuals/xiaomi-robot.pdf",
                        "C:\\Dokumentumok\\Garanciak\\xiaomi-robot-garancia.pdf",
                        "C:\\Dokumentumok\\Szamlak\\xiaomi-robot-szamla.pdf",
                        "C:\\Dokumentumok\\Kepek\\xiaomi-robot.jpg")
                };
            }
        }

        private sealed class NewDeviceForm : Form
        {
            public DeviceRecord CreatedDevice { get; private set; }

            private readonly TextBox _nameTextBox = new TextBox();
            private readonly TextBox _categoryTextBox = new TextBox();
            private readonly TextBox _manualTextBox = new TextBox();
            private readonly TextBox _warrantyTextBox = new TextBox();
            private readonly TextBox _invoiceTextBox = new TextBox();
            private readonly TextBox _imageTextBox = new TextBox();

            public NewDeviceForm()
            {
                Text = "Új eszköz felvétele";
                FormBorderStyle = FormBorderStyle.FixedDialog;
                MaximizeBox = false;
                MinimizeBox = false;
                StartPosition = FormStartPosition.CenterParent;
                ClientSize = new Size(540, 400);
                Font = new Font("Segoe UI", 9.5f);

                var panel = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    ColumnCount = 3,
                    RowCount = 7,
                    Padding = new Padding(16),
                    AutoSize = true
                };
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90));

                AddRow(panel, 0, "Eszköz neve:", _nameTextBox, null);
                AddRow(panel, 1, "Kategória:", _categoryTextBox, null);
                AddRow(panel, 2, "Kézikönyv út:", _manualTextBox, SelectPath);
                AddRow(panel, 3, "Garancia út:", _warrantyTextBox, SelectPath);
                AddRow(panel, 4, "Számla út:", _invoiceTextBox, SelectPath);
                AddRow(panel, 5, "Kép út:", _imageTextBox, SelectImage);

                var buttonPanel = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.RightToLeft,
                    Dock = DockStyle.Fill,
                    Padding = new Padding(0, 10, 0, 0)
                };

                var saveButton = new Button
                {
                    Text = "Mentés",
                    DialogResult = DialogResult.OK,
                    BackColor = Color.FromArgb(34, 197, 94),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Width = 100
                };
                saveButton.FlatAppearance.BorderSize = 0;
                saveButton.Click += SaveButton_Click;

                var cancelButton = new Button
                {
                    Text = "Mégse",
                    DialogResult = DialogResult.Cancel,
                    BackColor = Color.FromArgb(156, 163, 175),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Width = 100
                };
                cancelButton.FlatAppearance.BorderSize = 0;

                buttonPanel.Controls.Add(saveButton);
                buttonPanel.Controls.Add(cancelButton);
                panel.Controls.Add(buttonPanel, 0, 6);
                panel.SetColumnSpan(buttonPanel, 3);

                Controls.Add(panel);
            }

            private void AddRow(TableLayoutPanel panel, int row, string labelText, TextBox textBox, EventHandler browseHandler)
            {
                panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));

                var label = new Label
                {
                    Text = labelText,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Fill
                };

                textBox.Dock = DockStyle.Fill;

                panel.Controls.Add(label, 0, row);
                panel.Controls.Add(textBox, 1, row);

                if (browseHandler != null)
                {
                    var browseButton = new Button
                    {
                        Text = "Tallózás",
                        BackColor = Color.FromArgb(59, 130, 246),
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat,
                        Width = 80
                    };
                    browseButton.FlatAppearance.BorderSize = 0;
                    browseButton.Click += browseHandler;
                    panel.Controls.Add(browseButton, 2, row);
                }
            }

            private void SaveButton_Click(object sender, EventArgs e)
            {
                if (string.IsNullOrWhiteSpace(_nameTextBox.Text))
                {
                    MessageBox.Show("Az eszköz neve kötelező.", "Hiányzó adat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.None;
                    return;
                }

                CreatedDevice = new DeviceRecord(
                    _nameTextBox.Text.Trim(),
                    _categoryTextBox.Text.Trim(),
                    _manualTextBox.Text.Trim(),
                    _warrantyTextBox.Text.Trim(),
                    _invoiceTextBox.Text.Trim(),
                    _imageTextBox.Text.Trim());
            }

            private void SelectPath(object sender, EventArgs e)
            {
                using (var dialog = new OpenFileDialog())
                {
                    if (dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        GetTargetTextBox(sender).Text = dialog.FileName;
                    }
                }
            }

            private void SelectImage(object sender, EventArgs e)
            {
                using (var dialog = new OpenFileDialog())
                {
                    dialog.Filter = "Képfájlok|*.png;*.jpg;*.jpeg;*.bmp";
                    if (dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        _imageTextBox.Text = dialog.FileName;
                    }
                }
            }

            private TextBox GetTargetTextBox(object sender)
            {
                if (sender is Control control && control.Parent is TableLayoutPanel panel)
                {
                    var position = panel.GetPositionFromControl(control);
                    return panel.GetControlFromPosition(1, position.Row) as TextBox ?? _manualTextBox;
                }

                return _manualTextBox;
            }
        }
    }
}

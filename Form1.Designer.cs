
namespace PSZ_ManualSoft
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.ComboBox categoryFilterCombo;
        private System.Windows.Forms.ListBox deviceListBox;
        private System.Windows.Forms.PictureBox devicePicture;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.Label manualLabel;
        private System.Windows.Forms.Label warrantyLabel;
        private System.Windows.Forms.Label invoiceLabel;
        private System.Windows.Forms.Label nameValueLabel;
        private System.Windows.Forms.Label categoryValueLabel;
        private System.Windows.Forms.Label manualValueLabel;
        private System.Windows.Forms.Label warrantyValueLabel;
        private System.Windows.Forms.Label invoiceValueLabel;
        private System.Windows.Forms.Button openManualButton;
        private System.Windows.Forms.Button openWarrantyButton;
        private System.Windows.Forms.Button openInvoiceButton;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button exitButton;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.headerPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.categoryFilterCombo = new System.Windows.Forms.ComboBox();
            this.deviceListBox = new System.Windows.Forms.ListBox();
            this.devicePicture = new System.Windows.Forms.PictureBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.manualLabel = new System.Windows.Forms.Label();
            this.warrantyLabel = new System.Windows.Forms.Label();
            this.invoiceLabel = new System.Windows.Forms.Label();
            this.nameValueLabel = new System.Windows.Forms.Label();
            this.categoryValueLabel = new System.Windows.Forms.Label();
            this.manualValueLabel = new System.Windows.Forms.Label();
            this.warrantyValueLabel = new System.Windows.Forms.Label();
            this.invoiceValueLabel = new System.Windows.Forms.Label();
            this.openManualButton = new System.Windows.Forms.Button();
            this.openWarrantyButton = new System.Windows.Forms.Button();
            this.openInvoiceButton = new System.Windows.Forms.Button();
            this.newButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.devicePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.headerPanel.Controls.Add(this.titleLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1200, 70);
            this.headerPanel.TabIndex = 0;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.titleLabel.Location = new System.Drawing.Point(24, 18);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(199, 32);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "PSZ-ManualSoft";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.searchTextBox.Location = new System.Drawing.Point(24, 90);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(290, 25);
            this.searchTextBox.TabIndex = 1;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // categoryFilterCombo
            // 
            this.categoryFilterCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryFilterCombo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.categoryFilterCombo.FormattingEnabled = true;
            this.categoryFilterCombo.Location = new System.Drawing.Point(330, 90);
            this.categoryFilterCombo.Name = "categoryFilterCombo";
            this.categoryFilterCombo.Size = new System.Drawing.Size(210, 25);
            this.categoryFilterCombo.TabIndex = 2;
            this.categoryFilterCombo.SelectedIndexChanged += new System.EventHandler(this.categoryFilterCombo_SelectedIndexChanged);
            // 
            // deviceListBox
            // 
            this.deviceListBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.deviceListBox.FormattingEnabled = true;
            this.deviceListBox.ItemHeight = 17;
            this.deviceListBox.Location = new System.Drawing.Point(24, 130);
            this.deviceListBox.Name = "deviceListBox";
            this.deviceListBox.Size = new System.Drawing.Size(300, 412);
            this.deviceListBox.TabIndex = 3;
            this.deviceListBox.SelectedIndexChanged += new System.EventHandler(this.deviceListBox_SelectedIndexChanged);
            // 
            // devicePicture
            // 
            this.devicePicture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.devicePicture.Location = new System.Drawing.Point(360, 130);
            this.devicePicture.Name = "devicePicture";
            this.devicePicture.Size = new System.Drawing.Size(300, 200);
            this.devicePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.devicePicture.TabIndex = 4;
            this.devicePicture.TabStop = false;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.nameLabel.Location = new System.Drawing.Point(360, 332);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(78, 15);
            this.nameLabel.TabIndex = 5;
            this.nameLabel.Text = "Eszköz neve:";
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.categoryLabel.Location = new System.Drawing.Point(360, 362);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(64, 15);
            this.categoryLabel.TabIndex = 6;
            this.categoryLabel.Text = "Kategória:";
            // 
            // manualLabel
            // 
            this.manualLabel.AutoSize = true;
            this.manualLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.manualLabel.Location = new System.Drawing.Point(360, 392);
            this.manualLabel.Name = "manualLabel";
            this.manualLabel.Size = new System.Drawing.Size(83, 15);
            this.manualLabel.TabIndex = 7;
            this.manualLabel.Text = "Kézikönyv út:";
            // 
            // warrantyLabel
            // 
            this.warrantyLabel.AutoSize = true;
            this.warrantyLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.warrantyLabel.Location = new System.Drawing.Point(360, 422);
            this.warrantyLabel.Name = "warrantyLabel";
            this.warrantyLabel.Size = new System.Drawing.Size(73, 15);
            this.warrantyLabel.TabIndex = 8;
            this.warrantyLabel.Text = "Garancia út:";
            // 
            // invoiceLabel
            // 
            this.invoiceLabel.AutoSize = true;
            this.invoiceLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.invoiceLabel.Location = new System.Drawing.Point(360, 452);
            this.invoiceLabel.Name = "invoiceLabel";
            this.invoiceLabel.Size = new System.Drawing.Size(64, 15);
            this.invoiceLabel.TabIndex = 9;
            this.invoiceLabel.Text = "Számla út:";
            // 
            // nameValueLabel
            // 
            this.nameValueLabel.AutoSize = true;
            this.nameValueLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nameValueLabel.Location = new System.Drawing.Point(480, 330);
            this.nameValueLabel.Name = "nameValueLabel";
            this.nameValueLabel.Size = new System.Drawing.Size(15, 19);
            this.nameValueLabel.TabIndex = 10;
            this.nameValueLabel.Text = "-";
            // 
            // categoryValueLabel
            // 
            this.categoryValueLabel.AutoSize = true;
            this.categoryValueLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.categoryValueLabel.Location = new System.Drawing.Point(480, 360);
            this.categoryValueLabel.Name = "categoryValueLabel";
            this.categoryValueLabel.Size = new System.Drawing.Size(15, 19);
            this.categoryValueLabel.TabIndex = 11;
            this.categoryValueLabel.Text = "-";
            // 
            // manualValueLabel
            // 
            this.manualValueLabel.AutoSize = true;
            this.manualValueLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.manualValueLabel.Location = new System.Drawing.Point(480, 390);
            this.manualValueLabel.Name = "manualValueLabel";
            this.manualValueLabel.Size = new System.Drawing.Size(13, 17);
            this.manualValueLabel.TabIndex = 12;
            this.manualValueLabel.Text = "-";
            // 
            // warrantyValueLabel
            // 
            this.warrantyValueLabel.AutoSize = true;
            this.warrantyValueLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.warrantyValueLabel.Location = new System.Drawing.Point(480, 420);
            this.warrantyValueLabel.Name = "warrantyValueLabel";
            this.warrantyValueLabel.Size = new System.Drawing.Size(13, 17);
            this.warrantyValueLabel.TabIndex = 13;
            this.warrantyValueLabel.Text = "-";
            // 
            // invoiceValueLabel
            // 
            this.invoiceValueLabel.AutoSize = true;
            this.invoiceValueLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.invoiceValueLabel.Location = new System.Drawing.Point(480, 450);
            this.invoiceValueLabel.Name = "invoiceValueLabel";
            this.invoiceValueLabel.Size = new System.Drawing.Size(13, 17);
            this.invoiceValueLabel.TabIndex = 14;
            this.invoiceValueLabel.Text = "-";
            // 
            // openManualButton
            // 
            this.openManualButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.openManualButton.FlatAppearance.BorderSize = 0;
            this.openManualButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openManualButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.openManualButton.ForeColor = System.Drawing.Color.White;
            this.openManualButton.Location = new System.Drawing.Point(863, 130);
            this.openManualButton.Name = "openManualButton";
            this.openManualButton.Size = new System.Drawing.Size(200, 40);
            this.openManualButton.TabIndex = 15;
            this.openManualButton.Text = "Kézikönyv megnyitása";
            this.openManualButton.UseVisualStyleBackColor = false;
            this.openManualButton.Click += new System.EventHandler(this.openManualButton_Click);
            // 
            // openWarrantyButton
            // 
            this.openWarrantyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.openWarrantyButton.FlatAppearance.BorderSize = 0;
            this.openWarrantyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openWarrantyButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.openWarrantyButton.ForeColor = System.Drawing.Color.White;
            this.openWarrantyButton.Location = new System.Drawing.Point(863, 176);
            this.openWarrantyButton.Name = "openWarrantyButton";
            this.openWarrantyButton.Size = new System.Drawing.Size(200, 40);
            this.openWarrantyButton.TabIndex = 16;
            this.openWarrantyButton.Text = "Garancia megnyitása";
            this.openWarrantyButton.UseVisualStyleBackColor = false;
            this.openWarrantyButton.Click += new System.EventHandler(this.openWarrantyButton_Click);
            // 
            // openInvoiceButton
            // 
            this.openInvoiceButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(63)))), ((int)(((byte)(94)))));
            this.openInvoiceButton.FlatAppearance.BorderSize = 0;
            this.openInvoiceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openInvoiceButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.openInvoiceButton.ForeColor = System.Drawing.Color.White;
            this.openInvoiceButton.Location = new System.Drawing.Point(863, 222);
            this.openInvoiceButton.Name = "openInvoiceButton";
            this.openInvoiceButton.Size = new System.Drawing.Size(200, 40);
            this.openInvoiceButton.TabIndex = 17;
            this.openInvoiceButton.Text = "Számla megnyitása";
            this.openInvoiceButton.UseVisualStyleBackColor = false;
            this.openInvoiceButton.Click += new System.EventHandler(this.openInvoiceButton_Click);
            // 
            // newButton
            // 
            this.newButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.newButton.FlatAppearance.BorderSize = 0;
            this.newButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.newButton.ForeColor = System.Drawing.Color.White;
            this.newButton.Location = new System.Drawing.Point(863, 319);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(200, 40);
            this.newButton.TabIndex = 18;
            this.newButton.Text = "Új felvétele";
            this.newButton.UseVisualStyleBackColor = false;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.deleteButton.FlatAppearance.BorderSize = 0;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.deleteButton.ForeColor = System.Drawing.Color.White;
            this.deleteButton.Location = new System.Drawing.Point(863, 367);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(200, 40);
            this.deleteButton.TabIndex = 19;
            this.deleteButton.Text = "Törlés";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.exitButton.ForeColor = System.Drawing.Color.White;
            this.exitButton.Location = new System.Drawing.Point(863, 422);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(200, 40);
            this.exitButton.TabIndex = 20;
            this.exitButton.Text = "Kilépés";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.openInvoiceButton);
            this.Controls.Add(this.openWarrantyButton);
            this.Controls.Add(this.openManualButton);
            this.Controls.Add(this.invoiceValueLabel);
            this.Controls.Add(this.warrantyValueLabel);
            this.Controls.Add(this.manualValueLabel);
            this.Controls.Add(this.categoryValueLabel);
            this.Controls.Add(this.nameValueLabel);
            this.Controls.Add(this.invoiceLabel);
            this.Controls.Add(this.warrantyLabel);
            this.Controls.Add(this.manualLabel);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.devicePicture);
            this.Controls.Add(this.deviceListBox);
            this.Controls.Add(this.categoryFilterCombo);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.headerPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PSZ-ManualSoft";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.devicePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}

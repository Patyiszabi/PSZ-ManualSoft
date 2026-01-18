namespace PSZ_ManualSoft
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ListBox deviceListBox;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.ComboBox categoryFilterCombo;

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

        private System.Windows.Forms.PictureBox devicePicture;

        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button exitButton;

        private System.Windows.Forms.Button openManualButton;
        private System.Windows.Forms.Button openWarrantyButton;
        private System.Windows.Forms.Button openInvoiceButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.deviceListBox = new System.Windows.Forms.ListBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.categoryFilterCombo = new System.Windows.Forms.ComboBox();
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
            this.devicePicture = new System.Windows.Forms.PictureBox();
            this.newButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.openManualButton = new System.Windows.Forms.Button();
            this.openWarrantyButton = new System.Windows.Forms.Button();
            this.openInvoiceButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.devicePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // deviceListBox
            // 
            this.deviceListBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.deviceListBox.FormattingEnabled = true;
            this.deviceListBox.ItemHeight = 15;
            this.deviceListBox.Location = new System.Drawing.Point(12, 45);
            this.deviceListBox.Name = "deviceListBox";
            this.deviceListBox.Size = new System.Drawing.Size(476, 559);
            this.deviceListBox.TabIndex = 2;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.searchTextBox.Location = new System.Drawing.Point(12, 12);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(250, 23);
            this.searchTextBox.TabIndex = 0;
            
            // 
            // categoryFilterCombo
            // 
            this.categoryFilterCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryFilterCombo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.categoryFilterCombo.FormattingEnabled = true;
            this.categoryFilterCombo.Location = new System.Drawing.Point(268, 12);
            this.categoryFilterCombo.Name = "categoryFilterCombo";
            this.categoryFilterCombo.Size = new System.Drawing.Size(220, 23);
            this.categoryFilterCombo.TabIndex = 1;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nameLabel.Location = new System.Drawing.Point(510, 15);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(33, 15);
            this.nameLabel.TabIndex = 10;
            this.nameLabel.Text = "Név:";
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.categoryLabel.Location = new System.Drawing.Point(510, 40);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(64, 15);
            this.categoryLabel.TabIndex = 12;
            this.categoryLabel.Text = "Kategória:";
            // 
            // manualLabel
            // 
            this.manualLabel.AutoSize = true;
            this.manualLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.manualLabel.Location = new System.Drawing.Point(510, 330);
            this.manualLabel.Name = "manualLabel";
            this.manualLabel.Size = new System.Drawing.Size(68, 15);
            this.manualLabel.TabIndex = 30;
            this.manualLabel.Text = "Kézikönyv:";
            // 
            // warrantyLabel
            // 
            this.warrantyLabel.AutoSize = true;
            this.warrantyLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.warrantyLabel.Location = new System.Drawing.Point(510, 395);
            this.warrantyLabel.Name = "warrantyLabel";
            this.warrantyLabel.Size = new System.Drawing.Size(58, 15);
            this.warrantyLabel.TabIndex = 40;
            this.warrantyLabel.Text = "Garancia:";
            // 
            // invoiceLabel
            // 
            this.invoiceLabel.AutoSize = true;
            this.invoiceLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.invoiceLabel.Location = new System.Drawing.Point(510, 460);
            this.invoiceLabel.Name = "invoiceLabel";
            this.invoiceLabel.Size = new System.Drawing.Size(49, 15);
            this.invoiceLabel.TabIndex = 50;
            this.invoiceLabel.Text = "Számla:";
            // 
            // nameValueLabel
            // 
            this.nameValueLabel.AutoSize = true;
            this.nameValueLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nameValueLabel.Location = new System.Drawing.Point(620, 15);
            this.nameValueLabel.Name = "nameValueLabel";
            this.nameValueLabel.Size = new System.Drawing.Size(12, 15);
            this.nameValueLabel.TabIndex = 11;
            this.nameValueLabel.Text = "-";
            // 
            // categoryValueLabel
            // 
            this.categoryValueLabel.AutoSize = true;
            this.categoryValueLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.categoryValueLabel.Location = new System.Drawing.Point(620, 40);
            this.categoryValueLabel.Name = "categoryValueLabel";
            this.categoryValueLabel.Size = new System.Drawing.Size(12, 15);
            this.categoryValueLabel.TabIndex = 13;
            this.categoryValueLabel.Text = "-";
            // 
            // manualValueLabel
            // 
            this.manualValueLabel.AutoSize = true;
            this.manualValueLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.manualValueLabel.Location = new System.Drawing.Point(620, 330);
            this.manualValueLabel.Name = "manualValueLabel";
            this.manualValueLabel.Size = new System.Drawing.Size(12, 15);
            this.manualValueLabel.TabIndex = 31;
            this.manualValueLabel.Text = "-";
            // 
            // warrantyValueLabel
            // 
            this.warrantyValueLabel.AutoSize = true;
            this.warrantyValueLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.warrantyValueLabel.Location = new System.Drawing.Point(620, 395);
            this.warrantyValueLabel.Name = "warrantyValueLabel";
            this.warrantyValueLabel.Size = new System.Drawing.Size(12, 15);
            this.warrantyValueLabel.TabIndex = 41;
            this.warrantyValueLabel.Text = "-";
            // 
            // invoiceValueLabel
            // 
            this.invoiceValueLabel.AutoSize = true;
            this.invoiceValueLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.invoiceValueLabel.Location = new System.Drawing.Point(620, 460);
            this.invoiceValueLabel.Name = "invoiceValueLabel";
            this.invoiceValueLabel.Size = new System.Drawing.Size(12, 15);
            this.invoiceValueLabel.TabIndex = 51;
            this.invoiceValueLabel.Text = "-";
            // 
            // devicePicture
            // 
            this.devicePicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.devicePicture.Location = new System.Drawing.Point(513, 70);
            this.devicePicture.Name = "devicePicture";
            this.devicePicture.Size = new System.Drawing.Size(560, 240);
            this.devicePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.devicePicture.TabIndex = 20;
            this.devicePicture.TabStop = false;
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newButton.Location = new System.Drawing.Point(12, 612);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(110, 28);
            this.newButton.TabIndex = 3;
            this.newButton.Text = "Új felvétele";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.BackColor = System.Drawing.Color.LightGreen;
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.Location = new System.Drawing.Point(128, 612);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(110, 28);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Törlés";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.BackColor = System.Drawing.Color.LightCoral;
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.exitButton.Location = new System.Drawing.Point(978, 612);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(110, 28);
            this.exitButton.TabIndex = 5;
            this.exitButton.Text = "Kilépés";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.BackColor = System.Drawing.Color.LightGray;
            // 
            // openManualButton
            // 
            this.openManualButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.openManualButton.Location = new System.Drawing.Point(513, 350);
            this.openManualButton.Name = "openManualButton";
            this.openManualButton.Size = new System.Drawing.Size(220, 30);
            this.openManualButton.TabIndex = 32;
            this.openManualButton.Text = "Kézikönyv megnyitása";
            this.openManualButton.UseVisualStyleBackColor = true;
            this.openManualButton.BackColor = System.Drawing.Color.LightBlue;
            // 
            // openWarrantyButton
            // 
            this.openWarrantyButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.openWarrantyButton.Location = new System.Drawing.Point(513, 415);
            this.openWarrantyButton.Name = "openWarrantyButton";
            this.openWarrantyButton.Size = new System.Drawing.Size(220, 30);
            this.openWarrantyButton.TabIndex = 42;
            this.openWarrantyButton.Text = "Garancia megnyitása";
            this.openWarrantyButton.UseVisualStyleBackColor = true;
            this.openWarrantyButton.BackColor = System.Drawing.Color.LightBlue;
            // 
            // openInvoiceButton
            // 
            this.openInvoiceButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.openInvoiceButton.Location = new System.Drawing.Point(513, 480);
            this.openInvoiceButton.Name = "openInvoiceButton";
            this.openInvoiceButton.Size = new System.Drawing.Size(220, 30);
            this.openInvoiceButton.TabIndex = 52;
            this.openInvoiceButton.Text = "Számla megnyitása";
            this.openInvoiceButton.UseVisualStyleBackColor = true;
            this.openInvoiceButton.BackColor = System.Drawing.Color.LightBlue;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.categoryFilterCombo);
            this.Controls.Add(this.deviceListBox);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameValueLabel);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.categoryValueLabel);
            this.Controls.Add(this.devicePicture);
            this.Controls.Add(this.manualLabel);
            this.Controls.Add(this.manualValueLabel);
            this.Controls.Add(this.openManualButton);
            this.Controls.Add(this.warrantyLabel);
            this.Controls.Add(this.warrantyValueLabel);
            this.Controls.Add(this.openWarrantyButton);
            this.Controls.Add(this.invoiceLabel);
            this.Controls.Add(this.invoiceValueLabel);
            this.Controls.Add(this.openInvoiceButton);
            this.Name = "Form1";
            this.Text = "PSZ-ManualSoft";
            ((System.ComponentModel.ISupportInitialize)(this.devicePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}

﻿namespace GUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            plaintextBox = new TextBox();
            ciphertextBox = new TextBox();
            encryptButton = new Button();
            decryptButton = new Button();
            saveButton = new Button();
            savectButton = new Button();
            loadkButton = new Button();
            loadctButton = new Button();
            genkButton = new Button();
            loadptButton = new Button();
            checksumBox = new TextBox();
            cleanButton = new Button();
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // plaintextBox
            // 
            plaintextBox.AllowDrop = true;
            plaintextBox.BackColor = Color.FromArgb(34, 34, 40);
            plaintextBox.Cursor = Cursors.IBeam;
            plaintextBox.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            plaintextBox.ForeColor = Color.White;
            plaintextBox.Location = new Point(90, 180);
            plaintextBox.MaximumSize = new Size(420, 390);
            plaintextBox.MaxLength = 65535;
            plaintextBox.MinimumSize = new Size(420, 390);
            plaintextBox.Multiline = true;
            plaintextBox.Name = "plaintextBox";
            plaintextBox.PlaceholderText = "Plaintext ";
            plaintextBox.ScrollBars = ScrollBars.Both;
            plaintextBox.Size = new Size(420, 390);
            plaintextBox.TabIndex = 0;
            plaintextBox.Tag = "plaintextBox";
            // 
            // ciphertextBox
            // 
            ciphertextBox.BackColor = Color.FromArgb(34, 34, 40);
            ciphertextBox.Cursor = Cursors.IBeam;
            ciphertextBox.Enabled = false;
            ciphertextBox.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            ciphertextBox.ForeColor = Color.White;
            ciphertextBox.Location = new Point(770, 180);
            ciphertextBox.MaximumSize = new Size(420, 420);
            ciphertextBox.MaxLength = 2000000;
            ciphertextBox.MinimumSize = new Size(420, 420);
            ciphertextBox.Multiline = true;
            ciphertextBox.Name = "ciphertextBox";
            ciphertextBox.PlaceholderText = "Cipher text";
            ciphertextBox.ReadOnly = true;
            ciphertextBox.ScrollBars = ScrollBars.Vertical;
            ciphertextBox.Size = new Size(420, 420);
            ciphertextBox.TabIndex = 1;
            ciphertextBox.Tag = "plaintextBox";
            // 
            // encryptButton
            // 
            encryptButton.BackColor = Color.FromArgb(34, 34, 40);
            encryptButton.FlatAppearance.BorderColor = Color.FromArgb(147, 172, 201);
            encryptButton.FlatAppearance.BorderSize = 3;
            encryptButton.FlatStyle = FlatStyle.Flat;
            encryptButton.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            encryptButton.ForeColor = Color.White;
            encryptButton.Location = new Point(575, 295);
            encryptButton.Name = "encryptButton";
            encryptButton.Size = new Size(130, 51);
            encryptButton.TabIndex = 2;
            encryptButton.Text = "Encrypt";
            encryptButton.UseVisualStyleBackColor = false;
            encryptButton.Click += encryptButton_Click;
            // 
            // decryptButton
            // 
            decryptButton.BackColor = Color.FromArgb(34, 34, 40);
            decryptButton.FlatAppearance.BorderColor = Color.FromArgb(147, 172, 201);
            decryptButton.FlatAppearance.BorderSize = 3;
            decryptButton.FlatStyle = FlatStyle.Flat;
            decryptButton.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            decryptButton.ForeColor = Color.White;
            decryptButton.Location = new Point(575, 352);
            decryptButton.Name = "decryptButton";
            decryptButton.Size = new Size(130, 51);
            decryptButton.TabIndex = 6;
            decryptButton.Text = "Decrypt";
            decryptButton.UseVisualStyleBackColor = false;
            decryptButton.Click += decryptButton_Click;
            // 
            // saveButton
            // 
            saveButton.BackColor = Color.FromArgb(34, 34, 40);
            saveButton.FlatAppearance.BorderColor = Color.FromArgb(147, 172, 201);
            saveButton.FlatAppearance.BorderSize = 3;
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            saveButton.ForeColor = Color.White;
            saveButton.Location = new Point(420, 53);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(90, 55);
            saveButton.TabIndex = 8;
            saveButton.Text = "Save Key Pair";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += skpButton_Click;
            // 
            // savectButton
            // 
            savectButton.BackColor = Color.FromArgb(34, 34, 40);
            savectButton.FlatAppearance.BorderColor = Color.FromArgb(147, 172, 201);
            savectButton.FlatAppearance.BorderSize = 3;
            savectButton.FlatStyle = FlatStyle.Flat;
            savectButton.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            savectButton.ForeColor = Color.White;
            savectButton.Location = new Point(770, 53);
            savectButton.Name = "savectButton";
            savectButton.Size = new Size(99, 55);
            savectButton.TabIndex = 9;
            savectButton.Text = "Save Cipher text";
            savectButton.UseVisualStyleBackColor = false;
            savectButton.Click += sctButton_Click;
            // 
            // loadkButton
            // 
            loadkButton.BackColor = Color.FromArgb(34, 34, 40);
            loadkButton.FlatAppearance.BorderColor = Color.FromArgb(147, 172, 201);
            loadkButton.FlatAppearance.BorderSize = 3;
            loadkButton.FlatStyle = FlatStyle.Flat;
            loadkButton.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            loadkButton.ForeColor = Color.White;
            loadkButton.Location = new Point(537, 53);
            loadkButton.Name = "loadkButton";
            loadkButton.Size = new Size(90, 55);
            loadkButton.TabIndex = 10;
            loadkButton.Text = "Load Key Pair";
            loadkButton.UseVisualStyleBackColor = false;
            loadkButton.Click += lkpButton_Click;
            // 
            // loadctButton
            // 
            loadctButton.BackColor = Color.FromArgb(34, 34, 40);
            loadctButton.FlatAppearance.BorderColor = Color.FromArgb(147, 172, 201);
            loadctButton.FlatAppearance.BorderSize = 3;
            loadctButton.FlatStyle = FlatStyle.Flat;
            loadctButton.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            loadctButton.ForeColor = Color.White;
            loadctButton.Location = new Point(896, 53);
            loadctButton.Name = "loadctButton";
            loadctButton.Size = new Size(98, 55);
            loadctButton.TabIndex = 11;
            loadctButton.Text = "Load Cipher text";
            loadctButton.UseVisualStyleBackColor = false;
            loadctButton.Click += lctButton_Click;
            // 
            // genkButton
            // 
            genkButton.BackColor = Color.FromArgb(34, 34, 40);
            genkButton.FlatAppearance.BorderColor = Color.FromArgb(147, 172, 201);
            genkButton.FlatAppearance.BorderSize = 3;
            genkButton.FlatStyle = FlatStyle.Flat;
            genkButton.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            genkButton.ForeColor = Color.White;
            genkButton.Location = new Point(305, 53);
            genkButton.Name = "genkButton";
            genkButton.Size = new Size(90, 55);
            genkButton.TabIndex = 12;
            genkButton.Text = "Generate Key";
            genkButton.UseVisualStyleBackColor = false;
            genkButton.Click += gkpButton_Click;
            // 
            // loadptButton
            // 
            loadptButton.BackColor = Color.FromArgb(34, 34, 40);
            loadptButton.FlatAppearance.BorderColor = Color.FromArgb(147, 172, 201);
            loadptButton.FlatAppearance.BorderSize = 3;
            loadptButton.FlatStyle = FlatStyle.Flat;
            loadptButton.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            loadptButton.ForeColor = Color.White;
            loadptButton.Location = new Point(655, 53);
            loadptButton.Name = "loadptButton";
            loadptButton.Size = new Size(90, 55);
            loadptButton.TabIndex = 13;
            loadptButton.Text = "Load Plaintext";
            loadptButton.UseVisualStyleBackColor = false;
            loadptButton.Click += lptButton_CLick;
            // 
            // checksumBox
            // 
            checksumBox.BackColor = Color.FromArgb(34, 34, 40);
            checksumBox.Font = new Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point);
            checksumBox.ForeColor = Color.White;
            checksumBox.Location = new Point(90, 576);
            checksumBox.Multiline = true;
            checksumBox.Name = "checksumBox";
            checksumBox.PlaceholderText = "Checksum";
            checksumBox.Size = new Size(420, 24);
            checksumBox.TabIndex = 14;
            checksumBox.Tag = "checksumBox";
            checksumBox.TextAlign = HorizontalAlignment.Center;
            // 
            // cleanButton
            // 
            cleanButton.BackColor = Color.FromArgb(34, 34, 40);
            cleanButton.FlatAppearance.BorderColor = Color.FromArgb(147, 172, 201);
            cleanButton.FlatAppearance.BorderSize = 3;
            cleanButton.FlatStyle = FlatStyle.Flat;
            cleanButton.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            cleanButton.ForeColor = Color.White;
            cleanButton.Location = new Point(575, 409);
            cleanButton.Name = "cleanButton";
            cleanButton.Size = new Size(130, 51);
            cleanButton.TabIndex = 15;
            cleanButton.Text = "Clean";
            cleanButton.UseVisualStyleBackColor = false;
            cleanButton.Click += cleanButton_Click;
            // 
            // listBox1
            // 
            listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBox1.BackColor = Color.FromArgb(34, 34, 40);
            listBox1.ColumnWidth = 60;
            listBox1.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            listBox1.ForeColor = Color.White;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 17;
            listBox1.Items.AddRange(new object[] { "File", "Text" });
            listBox1.Location = new Point(9, 9);
            listBox1.Margin = new Padding(0);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(37, 38);
            listBox1.TabIndex = 16;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 35, 43);
            ClientSize = new Size(1264, 681);
            Controls.Add(listBox1);
            Controls.Add(cleanButton);
            Controls.Add(checksumBox);
            Controls.Add(loadptButton);
            Controls.Add(genkButton);
            Controls.Add(loadctButton);
            Controls.Add(loadkButton);
            Controls.Add(savectButton);
            Controls.Add(saveButton);
            Controls.Add(decryptButton);
            Controls.Add(encryptButton);
            Controls.Add(ciphertextBox);
            Controls.Add(plaintextBox);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Location = new Point(325, 180);
            Margin = new Padding(4);
            MaximumSize = new Size(1280, 720);
            MinimumSize = new Size(1280, 720);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Tag = "window";
            Text = "AES Cipher Tool";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox plaintextBox;
        private TextBox ciphertextBox;
        private Button encryptButton;
        private Button decryptButton;
        private Button saveButton;
        private Button savectButton;
        private Button loadkButton;
        private Button loadctButton;
        private Button genkButton;
        private Button loadptButton;
        private TextBox checksumBox;
        private Button cleanButton;
        private ListBox listBox1;
    }
}
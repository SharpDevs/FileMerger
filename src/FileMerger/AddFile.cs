﻿using System;using System.IO;using System.Windows.Forms;namespace FileMerger {    public partial class AddFile : Form {        public string Key { get; set; }        public string Path { get; set; }        public AddFile() {            InitializeComponent();        }        private void btnAdd_Click(object sender, EventArgs e) {            if (File.Exists(txtPath.Text)) {                Path = txtPath.Text;                Key = "{" + txtKey.Text + "}";                if (FileMergerSettings.Files.ContainsKey(Key)) {
                    MessageBox.Show($"A file with the key {Key} already exists. Please choose a different key.", @"Key Exists", MessageBoxButtons.OK,
                      MessageBoxIcon.Error);                }                else {
                    DialogResult = DialogResult.OK;
                    Close();
                }            }            else {                MessageBox.Show($"Could not find the file {txtPath.Text}", @"File not found", MessageBoxButtons.OK,                    MessageBoxIcon.Error);            }        }        private void btnFindFile_Click(object sender, EventArgs e) {            try {                var ofd = new OpenFileDialog {                    Filter = @"Textfiles|*.txt",                    Multiselect = false,                    CheckFileExists = true                };                if (ofd.ShowDialog() == DialogResult.OK) {                    txtPath.Text = ofd.FileName;                }            }            catch (Exception ex) {                MessageBox.Show($"Failed to get path Error: {ex}", @"Error", MessageBoxButtons.OK,                  MessageBoxIcon.Error);            }        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }
    }}
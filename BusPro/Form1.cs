using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusPro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            check_availability();
        }

        private void BrowseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog
            {
                Filter = "All Files (*.*)|*.*",
                FilterIndex = 1,
                Multiselect = false
            };
            choofdlog.ShowDialog();
            if (choofdlog.FileName.Length != 0)
            {
                FileNameBox.Text = choofdlog.FileName;
            }
            check_availability();
        }

        private void BrowseSignature_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog
            {
                Filter = "Signature Files (*.sign)|*.sign",
                FilterIndex = 1,
                Multiselect = false
            };
            choofdlog.ShowDialog();
            if (choofdlog.FileName.Length != 0)
            {
                SignaturePathBox.Text = choofdlog.FileName;
            }
            check_availability();
        }

        private void BrowseKey_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog
            {
                Filter = "Key Files (*.key)|*.key",
                FilterIndex = 1,
                Multiselect = false
            };
            choofdlog.ShowDialog();
            if (choofdlog.FileName.Length != 0)
            {
                KeyFilePath.Text = choofdlog.FileName;
            }
            check_availability();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Signature test = new Signature();
            LogTextBox.AppendText("Generated private key" + Environment.NewLine);
            test.CreatePublicKey();
            LogTextBox.AppendText("Generated public key" + Environment.NewLine);
            if (test.CreateHash(FileNameBox.Text))
            {
                LogTextBox.AppendText("Calculated hash" + Environment.NewLine);
                test.CreateFiles(FileNameBox.Text);
                LogTextBox.AppendText("Created Signature, and generated files" + Environment.NewLine);
                LogTextBox.AppendText("Signing Successsed" + Environment.NewLine);
            }
            else
            {
                LogTextBox.AppendText("Failed to calculate hash" + Environment.NewLine);
                LogTextBox.AppendText("Signing failed" + Environment.NewLine);
            }
            LogTextBox.AppendText(Environment.NewLine);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Verify test = new Verify(SignaturePathBox.Text, KeyFilePath.Text);
                LogTextBox.AppendText("Loaded signature and key." + Environment.NewLine);
                LogTextBox.AppendText("Veryfing file..." + Environment.NewLine);
                if (test.VerifySignature(FileNameBox.Text))
                    LogTextBox.AppendText("Signature verified successfully" + Environment.NewLine);
                else
                    LogTextBox.AppendText("Signature verified unsuccessfully" + Environment.NewLine);
            }
            catch (Exception ex)
            {
                LogTextBox.AppendText("Signature verification failed." + Environment.NewLine);
                LogTextBox.AppendText(ex.Message + Environment.NewLine);
            }
            finally { LogTextBox.AppendText(Environment.NewLine); }
        }
        private void check_availability()
        {
            if (SignTest()) button1.Enabled = true;
            else button1.Enabled = false;

            if (VerifyTest()) button2.Enabled = true;
            else button2.Enabled = false;
        }
        private bool SignTest()  { return FileNameBox.Text != ""; }
        private bool VerifyTest() { return SignTest() && KeyFilePath.Text != "" && SignaturePathBox.Text != ""; }

    }
}

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
            //readonly = true
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
                //if (DirectoryPath.Text == "") DirectoryPath.Text = new FileInfo(choofdlog.FileName).DirectoryName;
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
                //if (DirectoryPath.Text == "") DirectoryPath.Text = new FileInfo(choofdlog.FileName).DirectoryName;
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
                //if (DirectoryPath.Text == "") DirectoryPath.Text = new FileInfo(choofdlog.FileName).DirectoryName;
            }
            check_availability();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Signature test = new Signature();
            test.CreatePublicKey();
            test.CreateHash(FileNameBox.Text);
            test.CreateFiles(FileNameBox.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Verify test = new Verify(SignaturePathBox.Text, KeyFilePath.Text);
            if (test.VerifySignature(FileNameBox.Text)) label1.Text = "OK";
            else label1.Text = "Not Ok";
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

        /*private void button1_Click(object sender, EventArgs e)
        {
            Signature test = new Signature();
            test.CreatePublicKey();
            test.CreateHash(FileNameBox.Text);
            test.CreateFiles(FileNameBox.Text);
        }*/
    }
}

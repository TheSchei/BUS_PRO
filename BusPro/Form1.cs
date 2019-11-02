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
        }

        private void BrowseFile_Click(object sender, EventArgs e)
        {
            //readonly = true
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;

            choofdlog.Multiselect = false;
            choofdlog.ShowDialog();
            if (choofdlog.FileName.Length != 0)
            {
                FileNameBox.Text = choofdlog.FileName;
                //if (DirectoryPath.Text == "") DirectoryPath.Text = new FileInfo(choofdlog.FileName).DirectoryName;
            }
        }
    }
}

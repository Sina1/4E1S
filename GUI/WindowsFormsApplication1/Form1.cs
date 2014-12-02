using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
//public sealed class SaveFileDialog



namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Process.Start("explorer.exe", "-p");
            OpenFileDialog x = new OpenFileDialog();
            x.Multiselect = true;
            x.ShowDialog();
            string[] result = x.FileNames;

            //foreach (string y in result)
                //MessageBox.Show(y, "Selected Item", MessageBoxButtons.OK, MessageBoxIcon.Information);

            foreach (string y in result)
                textBox1.Text = y;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog x = new OpenFileDialog();
            x.Multiselect = true;
            x.ShowDialog();
            string[] result = x.FileNames;

            foreach (string y in result)
                textBox2.Text = y;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog x = new OpenFileDialog();
            x.Multiselect = true;
            x.ShowDialog();
            string[] result = x.FileNames;

            foreach (string y in result)
                textBox3.Text = y;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Show the FolderBrowserDialog.
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                var folderName = folderBrowserDialog1.SelectedPath;
                //if (!filenotOpened)
                //{
                //    // No file is opened, bring up openFileDialog in selected path.
                //    openFileDialog1.InitialDirectory = folderName;
                //    openFileDialog1.FileName = null;
                //    openMenuItem.PerformClick();
                //}
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog2_HelpRequest(object sender, EventArgs e)
        {
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Brett Check to see if the file location are .raw if yes return false
        }
    }
}

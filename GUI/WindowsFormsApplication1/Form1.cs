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
        // public variables
        public String baseCase   = "";
        public String newCase    = "";
        public String destFolder = "";
        public String filename   = "";


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
            // base case

            //Process.Start("explorer.exe", "-p");
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.ShowDialog();
            string[] result = fileDialog.FileNames;

            //foreach (string y in result)
                //MessageBox.Show(y, "Selected Item", MessageBoxButtons.OK, MessageBoxIcon.Information);

            foreach (string filenameString in result)
            {
                textBox1.Text = filenameString;
                this.baseCase = filenameString;
                break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // New case
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.ShowDialog();
            string[] result = fileDialog.FileNames;

            foreach (string filenameString in result) {
                textBox2.Text = filenameString;
                this.newCase = filenameString;
                break;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // folder path
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.ShowDialog();
            string[] result = fileDialog.FileNames;

            foreach (string filenameString in result)
            {
                textBox2.Text = filenameString;
                this.destFolder = filenameString;
                break;
            }
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

                textBox4.Text = folderName;

                // do path validation here



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
            this.filename = textBox5.Text;
            this.Close();
        
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

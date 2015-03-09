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
        public String baseCase   {get;set;}
        public String newCase    {get;set;}
        public String destFolder {get;set;}
        public String filename   {get;set;}
        public bool HelpButton   {get; set;}
      
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
                originalMap.Text = filenameString;
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
                newMap.Text = filenameString;
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
                //newMap.Text = filenameString;
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

                saveLocationFolder.Text = folderName;

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
            this.filename = saveName.Text;
            this.destFolder = saveLocationFolder.Text;
            

            if (testTextBoxes())
            {


                //busSelection busListSelect = new busSelection(originalMap.Text, newMap.Text, saveLocationFolder.Text, saveName.Text);
                enterBus busListSelect = new enterBus(originalMap.Text, newMap.Text, saveLocationFolder.Text, saveName.Text);
                busListSelect.ShowDialog();
                
                
            }
            else
            {
                MessageBox.Show("Please fill in all fields of this form!", "Missing Fields", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }


        }

        //Brett move or delete this alter
        private bool testTextBoxes()
        {
            if (String.IsNullOrWhiteSpace(saveLocationFolder.Text)) return false;
            if (String.IsNullOrWhiteSpace(saveName.Text)) return false;
            if (String.IsNullOrWhiteSpace(newMap.Text)) return false;
            if (String.IsNullOrWhiteSpace(originalMap.Text)) return false;

            return true;


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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    
        private void originalMap_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void hELPToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void newMap_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

      

    }
}

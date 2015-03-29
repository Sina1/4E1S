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
using System.IO;
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
            // Create the ToolTip and associate with the Form container.
            ToolTip toolTip1 = new ToolTip();

            //Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 1000;
            toolTip1.InitialDelay = 30;
            toolTip1.ReshowDelay = 30;
            //Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.originalMap, "Type the path to base case or click Base Case button");
            toolTip1.SetToolTip(this.newMap, "Type the path to new case or click New Case button");
            //toolTip1.SetToolTip(this.menuStrip1, "Help > Instructions");
           
            toolTip1.SetToolTip(this.saveLocationFolder, "Select a folder to save result of comparison");
            toolTip1.SetToolTip(this.saveName, "Select a name for the compared case");

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // base case


            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = false;
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "raw files (*.raw)|*.raw|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        
                        using (myStream)
                        {
                            // Insert code to read the stream here.
                            //if myStream 
                            string[] result = openFileDialog1.FileNames;
                            
                            string filenameStr = ".raw", item;

                            foreach (string flileType in result)
                            {
                                int len = flileType.Length;
                                
                                if (flileType.Trim().EndsWith("w"))
                                {
                                    int lastLocation = flileType.LastIndexOf(filenameStr);

                                    // identified section, if it is a valid .raw file
                                    if (lastLocation >= 0)
                                        {
                                            item = flileType.Substring(0, lastLocation);
                                            originalMap.Text = flileType;
                                            this.baseCase = flileType;
                                            //break;
                                            //MessageBox.Show("The New Case file exists at:\n\n" + item + filenameStr);
                                            break;
                                        }
                                        
                                }
                                else
                                    MessageBox.Show("Error, not a \".raw\" file: \n" + flileType + "\nPlease slecte a correct file type");                                
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            //Process.Start("explorer.exe", "-p");
            /*OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.ShowDialog();
            string[] result2 = fileDialog.FileNames;

            //foreach (string y in result)
                //MessageBox.Show(y, "Selected Item", MessageBoxButtons.OK, MessageBoxIcon.Information);

            foreach (string filenameString in result2)
            {
                originalMap.Text = filenameString;
                this.baseCase = filenameString;
                break;
            }*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // New case

            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = false;
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "raw files (*.raw)|*.raw|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {

                        using (myStream)
                        {
                            // Insert code to read the stream here.
                            //if myStream 
                            string[] result = openFileDialog1.FileNames;

                            string filenameStr = ".raw", item;

                            foreach (string flileType in result)
                            {
                                int len = flileType.Length;

                                if (flileType.Trim().EndsWith("w"))
                                {
                                    int lastLocation = flileType.LastIndexOf(filenameStr);

                                    // identified section, if it is a valid .raw file
                                    if (lastLocation >= 0)
                                    {
                                        item = flileType.Substring(0, lastLocation);
                                        newMap.Text = flileType;
                                        this.newCase = flileType;
                                        //break;
                                        //MessageBox.Show("The New Case file exists at:\n\n" + item + filenameStr);
                                        break;
                                    }

                                }
                                else
                                    MessageBox.Show("Error, not a \".raw\" file: \n" + flileType + "\nPlease slecte a correct file type");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }


           /* OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.ShowDialog();
            string[] result2 = fileDialog.FileNames;

            foreach (string filenameString in result2) 
            {
                newMap.Text = filenameString;
                this.newCase = filenameString;
                break;
            }*/
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
        {/*
            string BussList = BussesList.Text;
            foreach (char C in BussList)
            {
                if ((C == '/')|(C == '*') | (C == '_') | (C == '^') | (C == '&') | (C == '<') | (C == '>') | (C == '?')|
                    (C == '\t') | (C == ' ')|(C == '.') | ((C >= 'a') && (C <= 'z')) | ((C >= 'A') && (C <= 'Z')))
                {
                    MessageBox.Show("Bus List contains ivalid Characters: " + C+
                        "\n\nPlease use integers separated by comma only.");
                }
                
            }
          */
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
            string saveFolder = @saveLocationFolder.Text;
            if (Directory.Exists(saveFolder)) { }
                    //Directory.CreateDirectory(saveFolder);
                
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
            
            this.filename = saveName.Text;
            this.destFolder = saveLocationFolder.Text;

            string BaseCaseFile = @originalMap.Text;
            string newCaseFile = @newMap.Text;
            string saveFolder = @saveLocationFolder.Text;
            string errStr = null;

            string filePath1 = @originalMap.Text;
            string filePath2 = @newMap.Text;
            string filePath3 = @saveLocationFolder.Text;//
            string saveNm = @saveName.Text;//

            string badCharStr1 = null;
            string badCharStr2 = null;
            string badCharStr3 = null;
            string badCharStr4 = null;
            string WrongChr = null;

            string s1 = null;
            string s2 = null;
            string s3 = null;
            string s4 = null;
            string errMsg = null;
            string invFilePath = null;
            
            if (testTextBoxes())
            {   
                //Adding more error checks here: 
                if (!File.Exists(BaseCaseFile)){
                    errStr = errStr+"\nBase Case File does not exist at the selected location:\n"; //+ originalMap.Text);
                    //this.originalMap.BackColor = System.Drawing.SystemColors.ActiveCaption;
                    foreach (char C in BaseCaseFile)
                    {
                        if ((C == '/') | (C == '*') | (C == '_') | (C == '^') | (C == '&') | (C == '<') | (C == '>') | (C == '?'))
                        {
                            //flag = false;
                            //MessageBox.Show("File name contains ivalid Characters: " + C);
                            //break;
                            badCharStr1 = badCharStr1 + C;
                        }
                    }
                }
                if (!(File.Exists(newCaseFile))){
                     errStr = errStr+"\nNew Case File does not exist at the selected location:\n";// + newMap.Text);
                     //this.newMap.BackColor = System.Drawing.SystemColors.ActiveCaption;

                     foreach (char C in filePath2)
                     {
                         if ((C == '/') | (C == '*') | (C == '_') | (C == '^') | (C == '&') | (C == '<') | (C == '>') | (C == '?'))
                         {
                             badCharStr2 = badCharStr2 + C;
                         }
                     }
                    }
                //MessageBox.Show(File.Exists(BaseCaseFile) ? "File exists." : "File does not exist.");
                if (!Directory.Exists(this.destFolder))
                {
                     errStr = errStr+"\nThe Folder does not exist at the selected dirctory:\n";// + saveLocationFolder.Text);
                     //this.saveLocationFolder.BackColor = System.Drawing.SystemColors.ActiveCaption;
                        //Directory.CreateDirectory(saveFolder);
                     foreach (char c in filePath3)
                     {
                         //if ((C == '/') | (C == '*') | (C == '_') | (C == '^') | (C == '&') | (C == '<') | (C == '>') | (C == '?'))
                         if ((c == '/') | (c == '*') | (c == '_') | (c == '^') | (c == '&') | (c == '<') | (c == '>') | (c == '?')
                             | (c == '\t') | (c == ' ') | (c == '.'))
                         {
                             badCharStr3 = badCharStr3 + c;
                         }
                     }
                }

                foreach (char c in this.filename)
                {
                    
                    if ((c == '/') | (c == '*') | (c == '_') | (c == '^') | (c == '&') | (c == '<') | (c == '>') | (c == '?')
                    | (c == '\t') | (c == ' ') | (c == '.'))
                    {
                        badCharStr4 = badCharStr4 + c;
                        this.saveName.BackColor = System.Drawing.SystemColors.ActiveCaption;
                    }
                }

                WrongChr = badCharStr1 + badCharStr2 + badCharStr3 + badCharStr4;                  

                    if (badCharStr1 != null)
                    {
                        s1 = "\nBad Charachter " + badCharStr1 + " in " + "<"+ filePath1+"> in Base Case\n" ;
                        errMsg = errMsg + s1;
                        //this.originalMap.BackColor = System.Drawing.SystemColors.ActiveCaption;
                    }
                    if (badCharStr2 != null)
                    {
                        s2 = "\nBad Charachter " + badCharStr2 + " in " + "<" + filePath2 + "> in New Case\n";
                        errMsg = errMsg + s2;
                    }
                    if (badCharStr3 != null)
                    {
                        s3 = "\nBad Charachter " + badCharStr3 + " in " + "<" + filePath3 + "> in Folde Path\n";
                        errMsg = errMsg + s3;
                    }

                    if (badCharStr4 != null)
                      {
                          s4 = "\nBad Charachter " + badCharStr4 + " in " + "<" + saveNm + "> in File Name\n";
                        errMsg = errMsg + s4;
                      }
                
                    invFilePath = errStr;
                    if ((File.Exists(BaseCaseFile)) && (File.Exists(newCaseFile)) && (Directory.Exists(this.destFolder)))
                    {
                        if (!(badCharStr4 != null))
                        {
                            this.originalMap.BackColor = System.Drawing.SystemColors.Window;
                            this.saveLocationFolder.BackColor = System.Drawing.SystemColors.Window;
                            this.newMap.BackColor = System.Drawing.SystemColors.Window;
                            this.saveName.BackColor = System.Drawing.SystemColors.Window;

                            if (this.IdvCheckBox.Checked || this.visioCheckBox.Checked)
                            {
                                BusSelectionForm busSelection = new BusSelectionForm(originalMap.Text, newMap.Text, saveLocationFolder.Text, saveName.Text, this.visioCheckBox.Checked, this.IdvCheckBox.Checked);
                                busSelection.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("\n\tPlease Check A Item to Produce\n");
                            }
                        }
                        else
                        {
                            this.originalMap.BackColor = System.Drawing.SystemColors.Window;
                            this.saveLocationFolder.BackColor = System.Drawing.SystemColors.Window;
                            this.newMap.BackColor = System.Drawing.SystemColors.Window;
                            this.saveName.BackColor = System.Drawing.SystemColors.ActiveCaption;
                            MessageBox.Show("\n\tPlease Fix Errors! \n\n" + invFilePath + "\n" + errMsg + "\n");
                        }
                    }
    
                    else
                    {
                        if (!(File.Exists(BaseCaseFile)))
                            this.originalMap.BackColor = System.Drawing.SystemColors.ActiveCaption;
                        else
                            this.originalMap.BackColor = System.Drawing.SystemColors.Window;
                        if (!(File.Exists(newCaseFile)))
                        this.newMap.BackColor = System.Drawing.SystemColors.ActiveCaption;
                        else
                            this.newMap.BackColor = System.Drawing.SystemColors.Window;

                        if (!(Directory.Exists(this.destFolder)))
                        this.saveLocationFolder.BackColor = System.Drawing.SystemColors.ActiveCaption;
                        else
                            this.saveLocationFolder.BackColor = System.Drawing.SystemColors.Window;
                        if ((badCharStr4 != null))
                        this.saveName.BackColor = System.Drawing.SystemColors.ActiveCaption;
                        else
                            this.saveName.BackColor = System.Drawing.SystemColors.Window;
                        MessageBox.Show("\n\tPlease Fix Errors! \n\n" + invFilePath + "\n" + errMsg + "\n");
                    }   
            }

            else
            {MessageBox.Show("Please fill in all fields of this form!", 
             "Missing Fields", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
        }


        private void elif(bool p)
        {
            throw new NotImplementedException();
        }


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
            string s = saveName.Text;
            string b = null;
            foreach (char c in s)
            {
                //if ((C == '/') | (C == '*') | (C == '_') | (C == '^') | (C == '&') | (C == '<') | (C == '>') | (C == '?'))
                if ((c == '/') | (c == '*') | (c == '_') | (c == '^') | (c == '&') | (c == '<') | (c == '>') | (c == '?')
                    | (c == '\t') | (c == ' ') | (c == '.'))
                {
                    b= b + c;
                }
            }
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
            string BaseCaseFile = @originalMap.Text;
            
            if (File.Exists(BaseCaseFile)) { }
        }

        private void hELPToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
          
        }

        private void newMap_TextChanged(object sender, EventArgs e)
        {
            string newCaseFile = @newMap.Text;
            //string saveFolder = @saveLocationFolder.Text;
            if ((File.Exists(newCaseFile))) { }
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

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void sssToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String platFromReq = "\n" +
            "\nHARDWARE:" +
            "\nWindow PC, 4GB RAM, 2 Core CPU" +
            "\n\nSOFTWARE:" +
            "\nWindow OS 7 or higher, Visio 2010, Python 3.xx installed.\n";
            MessageBox.Show(platFromReq);
        }

        private void helpTopicsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String howToUseTheProgram = "\n" +
        "\nHOW TO RUN THE PROGRAM:\n" +
"\nStep 1:\n" +
"Select an old base *.raw file by clicking on the brows button \"Base Case\" or type the path to the location where the *.raw file is stored" +
"\nStep 2:\n" +
"Select a new base *.raw file by clicking on brows button \"New Case\" or type the path to its location" +
"\nStep 3:\n" +
"Select a list of busses from the old and new cases to be compared for any changes" +
"\nStep 4:\n" +
"Select a location by clicking on the \"Select\" button or type the path to for storing the change file that will contain the result of comparison." +
"\nStep 5:\n" +
"Select a file name; file name must be alpha-numeric; special characters \\ ? / ^ % > < | * are not allowed; allowed special chars are  _ ,  - ." +
"\nStep 6:\n" +
"Click on \"OK\" button to run the program. Any of the fields not filled properly or left blank will cause error; the user to fix before proceeding" +
"\nStep 7:\n" +
"At any time click \"Cancel\" button or press <esc> key on the keyboard to cancel the program session and exit" +
"\n";
            MessageBox.Show(howToUseTheProgram);
        }

        private void userGuideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("FULL User Guide");
        }

        private void hELPToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }

        private void nEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String fullUserGuide = "HOW TO RUN THE PROGRAM\n\n" +
            "Step 1: 	Select an old base *.raw file by clicking on the brows button \"Base Case\" or type the path to the location where the *.raw file is stored\n"+
            "Step 2: 	Select a new base *.raw file by clicking on brows button \"New Case\" or type the path to its location\n"+
            "Step 3:	Select a list of busses from the old and new cases to be compared for any changes\n"+
            "Step 4:	Select a location by clicking on the \"Select\" button or type the path to for storing the change file that will contain the result of comparison.\n"+ 
            "Step 5:	Select a file name for the change file; the name must be alpha-numeric; characters \\? / ^ % > < | * are not allowed in the"+
            "file name;\n"+
            "Step 6:	Click on \"OK\" to run the program. If any of the fields filled incorrectly or left blank, it will cause an error message!\n"+
            "Step 7:	At any time click \"Cancel\" button or press <esc> key on the keyboard to cancel the program session and exit\n" +
            "\nMENU DESCRITION:\n"+
            "HELP:\n"+"Contains info on how to use the program, hardware-software platform requirements for the program to be able to run on, general description of the program,"+ 
            "and contact info for tech support or troubleshooting.\n"+ 
            "\nOPTIONS:\nProvides the user with option to open the Full Program User Guide in a separate window\n\n"+ 	

            "\nPLATFORM REQUIREMENTS\n"+
            "HARDWARE: Window PC, 4GB RAM, 2 Core CPU\n"+
            "SOFTWARE: Window OS 7 or higher, Visio 2010, Python 3.xx installed.\n"+

            "\nABOUT\n" +
             "This program is a customized software tool designed to process AESO base case files to identify any changes in connections between specific busses and\n"+ 
            "generate a Visio file that will contain the single line diagram reflecting the changes between the two cases. The Visio file will be editable\n"+ 
            "in Microsoft Visio 2010 for further modifications. The base case files are in *.raw format.\n"+
            "All rights to this software belong to its developers and are protected by law under the group license with permission for AESO for use in their company.\n"+ 

            "\nTECH SUPPORT\n"+
            "For troubleshooting, and/or other technical support in relation to the use of this software please consult your IT department. Firewall, Virus, Spyware and other\n"+ 
            "security issues that may arise as a result of use of this program must be reviewed prior to installing this program.\n"+
            "For program malfunction, modification, improvements, and software upgrades please contact the developer team @: xxx.xxx@xxx.com\n\n";

            MessageBox.Show(fullUserGuide);
            
        }

        private void toolStripComboBox3_Click(object sender, EventArgs e)
        {

        }

        private void ddddToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click_2(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string about = "\n" +
                "This program is a customized software tool designed to process AESO base case files to indentify" +
                "any changes in connections between specific busses and generate a visio file that will contain" +
                "the single line diagram reflecting the changes between the two cases. The visio file will be editable" +
                "in Microsoft  Visio 2010 for further modifications. The base case files are in *.raw format." +

                "\n\nAll rights to this software belong to its developers and are protected by law under the group" +
                "license with permission for AESO for use in their company.\n";
            MessageBox.Show(about);
        }

        private void technicalSupportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string techReq = "\n" +
           "For troubleshooting, and/or other technical support in relation to the use of this software " +
           "please consutl your IT department. Firewall, Virus, Spyware and other security issues that may" +
           "arise as a result of use of this program must be reviewed prior to installing this program." +
           "\n\nFor program malfunction, modification, improvements, and software upgrades please contact " +
           "the developer team @: xxx.xxx@xxx.com.\n";
            MessageBox.Show(techReq);

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

      

    }
}

namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.originalMap = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.newMap = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
<<<<<<< HEAD
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.loadingIcon = new System.Windows.Forms.PictureBox();
=======
>>>>>>> origin/master
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.saveName = new System.Windows.Forms.TextBox();
            this.saveLocationFolder = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hELPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpTopicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
<<<<<<< HEAD
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.sssToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox2 = new System.Windows.Forms.ToolStripComboBox();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox5 = new System.Windows.Forms.ToolStripComboBox();
            this.technicalSupportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox4 = new System.Windows.Forms.ToolStripComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingIcon)).BeginInit();
=======
>>>>>>> origin/master
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // originalMap
            // 
            this.originalMap.AccessibleDescription = "";
            this.originalMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.originalMap.Location = new System.Drawing.Point(12, 46);
            this.originalMap.Multiline = true;
            this.originalMap.Name = "originalMap";
            this.originalMap.Size = new System.Drawing.Size(287, 20);
            this.originalMap.TabIndex = 3;
            this.originalMap.TextChanged += new System.EventHandler(this.originalMap_TextChanged);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(313, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Base Case";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // newMap
            // 
            this.newMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newMap.Location = new System.Drawing.Point(12, 116);
            this.newMap.Name = "newMap";
            this.newMap.Size = new System.Drawing.Size(287, 20);
            this.newMap.TabIndex = 3;
            this.newMap.TextChanged += new System.EventHandler(this.newMap_TextChanged);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button3.Location = new System.Drawing.Point(313, 114);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "New Case";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button6.Location = new System.Drawing.Point(313, 46);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 9;
            this.button6.Text = "Select";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
<<<<<<< HEAD
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.BussesList);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Location = new System.Drawing.Point(0, 198);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 66);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BUS NUMBERS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(137, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(237, 39);
            this.label5.TabIndex = 7;
            this.label5.Text = "Place a comma following every bus number entry\r\nExample: 1,3,5\r\n\r\n";
            this.label5.Click += new System.EventHandler(this.label5_Click_1);
            // 
            // loadingIcon
            // 
            this.loadingIcon.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.loadingIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loadingIcon.Cursor = System.Windows.Forms.Cursors.Default;
            this.loadingIcon.Image = global::WindowsFormsApplication1.Properties.Resources.ajax_loader_blue_512;
            this.loadingIcon.Location = new System.Drawing.Point(306, 84);
            this.loadingIcon.Name = "loadingIcon";
            this.loadingIcon.Size = new System.Drawing.Size(92, 63);
            this.loadingIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.loadingIcon.TabIndex = 15;
            this.loadingIcon.TabStop = false;
            this.loadingIcon.Visible = false;
            this.loadingIcon.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
=======
>>>>>>> origin/master
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.groupBox2.Controls.Add(this.loadingIcon);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.saveName);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.saveLocationFolder);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Window;
            this.groupBox2.Location = new System.Drawing.Point(0, 206);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(398, 147);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CHANGE FILE NAME";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Folder";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "File Name";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // saveName
            // 
            this.saveName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveName.Location = new System.Drawing.Point(12, 108);
            this.saveName.Name = "saveName";
            this.saveName.Size = new System.Drawing.Size(287, 20);
            this.saveName.TabIndex = 10;
            this.saveName.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // saveLocationFolder
            // 
            this.saveLocationFolder.BackColor = System.Drawing.SystemColors.Info;
            this.saveLocationFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveLocationFolder.Location = new System.Drawing.Point(12, 48);
            this.saveLocationFolder.Name = "saveLocationFolder";
            this.saveLocationFolder.Size = new System.Drawing.Size(287, 20);
            this.saveLocationFolder.TabIndex = 8;
            this.saveLocationFolder.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // button4
            // 
            this.button4.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button4.Location = new System.Drawing.Point(313, 371);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 13;
            this.button4.Text = "Cancel";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(224, 371);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.groupBox3.Controls.Add(this.originalMap);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.newMap);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Window;
            this.groupBox3.Location = new System.Drawing.Point(0, 36);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(398, 154);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "MAPS";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "After Base Case";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Before Base Case";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // fILEToolStripMenuItem
            // 
            this.fILEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nEToolStripMenuItem});
            this.fILEToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Info;
            this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            this.fILEToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.fILEToolStripMenuItem.Text = "OPTIONS";
            // 
            // nEToolStripMenuItem
            // 
            this.nEToolStripMenuItem.BackColor = System.Drawing.Color.DimGray;
            this.nEToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.nEToolStripMenuItem.Name = "nEToolStripMenuItem";
            this.nEToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.nEToolStripMenuItem.Text = "Click > Full User Guide";
            this.nEToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nEToolStripMenuItem.Click += new System.EventHandler(this.nEToolStripMenuItem_Click);
            // 
            // hELPToolStripMenuItem
            // 
            this.hELPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpTopicsToolStripMenuItem,
            this.sssToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.technicalSupportToolStripMenuItem});
            this.hELPToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.hELPToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.hELPToolStripMenuItem.Name = "hELPToolStripMenuItem";
            this.hELPToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.hELPToolStripMenuItem.RightToLeftAutoMirrorImage = true;
            this.hELPToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.hELPToolStripMenuItem.Text = "HELP";
            this.hELPToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.hELPToolStripMenuItem.Click += new System.EventHandler(this.hELPToolStripMenuItem_Click_1);
            // 
            // helpTopicsToolStripMenuItem
            // 
            this.helpTopicsToolStripMenuItem.BackColor = System.Drawing.Color.DimGray;
            this.helpTopicsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1});
            this.helpTopicsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.helpTopicsToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.helpTopicsToolStripMenuItem.Name = "helpTopicsToolStripMenuItem";
            this.helpTopicsToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.helpTopicsToolStripMenuItem.Text = "How to Use the Program ";
            this.helpTopicsToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.helpTopicsToolStripMenuItem.Click += new System.EventHandler(this.helpTopicsToolStripMenuItem_Click);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.AccessibleDescription = "";
            this.toolStripComboBox1.AccessibleName = "";
            this.toolStripComboBox1.AutoSize = false;
            this.toolStripComboBox1.AutoToolTip = true;
            this.toolStripComboBox1.BackColor = System.Drawing.SystemColors.Info;
            this.toolStripComboBox1.DropDownHeight = 450;
            this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1.DropDownWidth = 600;
            this.toolStripComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.toolStripComboBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.toolStripComboBox1.IntegralHeight = false;
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "",
            "",
            "HOW TO RUN THE PROGRAM:",
            "Step 1: ",
            "Select an old base *.raw file by clicking on the brows button \"Base Case\" or type" +
                " the path to the location ",
            "where the *.raw file is stored",
            "Step 2: ",
            "Select a new base *.raw file by clicking on brows button \"New Case\" or type the p" +
                "ath to its location",
            "Step 3: ",
            "Select a list of busses from the old and new cases to be compared for any changes" +
                "",
            "Step 4: ",
            "Select a location by clicking on the \"Select\" button or type the path to for stor" +
                "ing the change file that will ",
            "contain the result of comparison. ",
            "Step 5: ",
            "Select a valid file name for the change file; file name must be alpha-numeric;  s" +
                "pecial characters such as",
            " \\ ? / ^ % > < | * are not allowed in the file name; allowed special chars  _ ,  " +
                "- .",
            "Step 6: ",
            "Click on \"OK\" button to run the program. If any of the fields not filled properly" +
                ",or left blank will cause an ",
            "error message prompting the user to fix before proceeding",
            "Step 7:\t",
            "At any time click \"Cancel\" button or press <esc> key on the keyboard to cancel th" +
                "e program session and exit",
            "",
            "MENU DESCRITION:",
            "HELP: ",
            "Information on how to use the program, hardware-software platform requirements fo" +
                "r the program to ",
            "be able to run on, general description the program, and contact info for tech sup" +
                "port or troubleshooting. ",
            "OPTIONS:",
            "Provides the user with option to open the Full Program User Guide in a separate  " +
                "window  ",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""});
            this.toolStripComboBox1.MaxDropDownItems = 100;
            this.toolStripComboBox1.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(600, 23);
            this.toolStripComboBox1.Tag = "";
            this.toolStripComboBox1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.toolStripComboBox1.ToolTipText = "How to Use the Program";
            // 
            // sssToolStripMenuItem
            // 
            this.sssToolStripMenuItem.AutoToolTip = true;
            this.sssToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox2});
            this.sssToolStripMenuItem.Name = "sssToolStripMenuItem";
            this.sssToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.sssToolStripMenuItem.Text = "Platform Requirements ";
            this.sssToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sssToolStripMenuItem.Click += new System.EventHandler(this.sssToolStripMenuItem_Click);
            // 
            // toolStripComboBox2
            // 
            this.toolStripComboBox2.AutoToolTip = true;
            this.toolStripComboBox2.DropDownHeight = 500;
            this.toolStripComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox2.DropDownWidth = 450;
            this.toolStripComboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.toolStripComboBox2.IntegralHeight = false;
            this.toolStripComboBox2.Items.AddRange(new object[] {
            "",
            "",
            "For Optimal Operation of the Program:",
            "HARDWARE:",
            "Window PC, 4GB RAM, 2 Core CPU",
            "",
            "SOFTWARE:",
            "Window OS 7 or higher, Visio 2010, Python 3.xx installed.",
            "",
            ""});
            this.toolStripComboBox2.MaxDropDownItems = 100;
            this.toolStripComboBox2.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.toolStripComboBox2.Name = "toolStripComboBox2";
            this.toolStripComboBox2.Size = new System.Drawing.Size(450, 23);
            this.toolStripComboBox2.ToolTipText = "Platform Requirements";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox5});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // toolStripComboBox5
            // 
            this.toolStripComboBox5.AutoSize = false;
            this.toolStripComboBox5.AutoToolTip = true;
            this.toolStripComboBox5.DropDownHeight = 360;
            this.toolStripComboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox5.DropDownWidth = 600;
            this.toolStripComboBox5.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.toolStripComboBox5.IntegralHeight = false;
            this.toolStripComboBox5.Items.AddRange(new object[] {
            "",
            "This program is a customized software tool designed to process AESO base case fil" +
                "es to indentify ",
            "any changes in connections between specific busses and generate a visio file that" +
                " will contain ",
            "the single line diagram reflecting the changes between the two cases. The visio f" +
                "ile will be editable",
            "in Microsoft  Visio 2010 for further modifications. The base case files are in *." +
                "raw format.",
            "",
            "All rights to this software belong to its developers and are protected by law und" +
                "er the group ",
            "license with permission for AESO for use in their company. ",
            "",
            "March 08, 2015",
            ""});
            this.toolStripComboBox5.MaxDropDownItems = 100;
            this.toolStripComboBox5.Name = "toolStripComboBox5";
            this.toolStripComboBox5.Size = new System.Drawing.Size(550, 23);
            // 
            // technicalSupportToolStripMenuItem
            // 
            this.technicalSupportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox4});
            this.technicalSupportToolStripMenuItem.Name = "technicalSupportToolStripMenuItem";
            this.technicalSupportToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.technicalSupportToolStripMenuItem.Text = "Technical Support";
            this.technicalSupportToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripComboBox4
            // 
            this.toolStripComboBox4.AutoToolTip = true;
            this.toolStripComboBox4.DropDownHeight = 350;
            this.toolStripComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox4.DropDownWidth = 550;
            this.toolStripComboBox4.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.toolStripComboBox4.IntegralHeight = false;
            this.toolStripComboBox4.Items.AddRange(new object[] {
            "",
            "",
            "For troubleshooting, and/or other technical support in relation to the use of thi" +
                "s software ",
            "please consutl your IT department. Firewall, Virus, Spyware and other security is" +
                "sues that may",
            "arise as a result of use of this program must be reviewed prior to installing thi" +
                "s program.",
            "",
            "For program malfunction, modification, improvements, and software upgrades please" +
                " contact ",
            "the developer team @: xxx.xxx@xxx.com",
            ""});
            this.toolStripComboBox4.MaxDropDownItems = 100;
            this.toolStripComboBox4.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.toolStripComboBox4.Name = "toolStripComboBox4";
            this.toolStripComboBox4.Size = new System.Drawing.Size(500, 23);
            this.toolStripComboBox4.ToolTipText = "Technical Support Info";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DimGray;
            this.menuStrip1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem,
            this.hELPToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(407, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
<<<<<<< HEAD
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DimGray;
            this.CancelButton = this.button4;
            this.ClientSize = new System.Drawing.Size(407, 477);
            this.Controls.Add(this.menuStrip1);
=======
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.DimGray;
            this.CancelButton = this.button4;
            this.ClientSize = new System.Drawing.Size(398, 405);
>>>>>>> origin/master
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
<<<<<<< HEAD
=======
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
>>>>>>> origin/master
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CDUP Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox originalMap;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox newMap;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox saveLocationFolder;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox saveName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
<<<<<<< HEAD
        private System.Windows.Forms.PictureBox loadingIcon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
=======
        private System.Windows.Forms.MenuStrip menuStrip1;
>>>>>>> origin/master
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hELPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpTopicsToolStripMenuItem;
<<<<<<< HEAD
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripMenuItem sssToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox5;
        private System.Windows.Forms.ToolStripMenuItem technicalSupportToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox4;
        public System.Windows.Forms.MenuStrip menuStrip1;
=======
>>>>>>> origin/master
    }
}


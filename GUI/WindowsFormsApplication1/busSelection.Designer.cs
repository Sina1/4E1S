namespace WindowsFormsApplication1
{
    partial class busSelection
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
            this.BusCheckList = new System.Windows.Forms.CheckedListBox();
            this.OK_button = new System.Windows.Forms.Button();
            this.cancel_Button = new System.Windows.Forms.Button();
            this.SearchText = new System.Windows.Forms.Label();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BusCheckList
            // 
            this.BusCheckList.CheckOnClick = true;
            this.BusCheckList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BusCheckList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BusCheckList.FormattingEnabled = true;
            this.BusCheckList.IntegralHeight = false;
            this.BusCheckList.Location = new System.Drawing.Point(23, 67);
            this.BusCheckList.Name = "BusCheckList";
            this.BusCheckList.Size = new System.Drawing.Size(240, 237);
            this.BusCheckList.TabIndex = 0;
            this.BusCheckList.SelectedValueChanged += new System.EventHandler(this.CheckList_SelectedIndexChanged);
            // 
            // OK_button
            // 
            this.OK_button.Location = new System.Drawing.Point(107, 326);
            this.OK_button.Name = "OK_button";
            this.OK_button.Size = new System.Drawing.Size(75, 23);
            this.OK_button.TabIndex = 1;
            this.OK_button.Text = "Ok";
            this.OK_button.UseVisualStyleBackColor = true;
            this.OK_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // cancel_Button
            // 
            this.cancel_Button.Location = new System.Drawing.Point(188, 326);
            this.cancel_Button.Name = "cancel_Button";
            this.cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.cancel_Button.TabIndex = 2;
            this.cancel_Button.Text = "Cancel";
            this.cancel_Button.UseVisualStyleBackColor = true;
            this.cancel_Button.Click += new System.EventHandler(this.cancel_Button_Click);
            // 
            // SearchText
            // 
            this.SearchText.AutoSize = true;
            this.SearchText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchText.Location = new System.Drawing.Point(19, 15);
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(107, 20);
            this.SearchText.TabIndex = 3;
            this.SearchText.Text = "Bus Selection";
            this.SearchText.Click += new System.EventHandler(this.label1_Click);
            // 
            // SearchBox
            // 
            this.SearchBox.Location = new System.Drawing.Point(23, 38);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(240, 20);
            this.SearchBox.TabIndex = 4;
            this.SearchBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // busSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(288, 361);
            this.ControlBox = false;
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.SearchText);
            this.Controls.Add(this.cancel_Button);
            this.Controls.Add(this.OK_button);
            this.Controls.Add(this.BusCheckList);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "busSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox BusCheckList;
        private System.Windows.Forms.Button OK_button;
        private System.Windows.Forms.Button cancel_Button;
        private System.Windows.Forms.Label SearchText;
        private System.Windows.Forms.TextBox SearchBox;

    }
}
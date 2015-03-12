using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class BusSelectionForm : Form
    {
        string startPath, EndPath, savePath, saveName;
        public BusSelectionForm(string path1, string path2, string sPath, string sName)
        {
            InitializeComponent();
            startPath = path1;
            EndPath = path2;
            savePath = sPath;
            saveName = sName;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string[] list = busList.Items.Cast<string>().ToArray();
            if (list.Length != 0)
            {
                CompareTool.StartCompareTool(startPath, EndPath, list, savePath, saveName);
                MessageBox.Show("Your file has been successfully saved to the following location: \n\n " + savePath + "\\" + saveName + ".vsd", "File Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else MessageBox.Show("Please enter Items into the list", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void enterTextBus_TextChanged(object sender, EventArgs e)
        {

        }

        private void enterTextBus_Press(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                 
                if(!String.IsNullOrWhiteSpace(enterTextBus.Text))
                {

                    busList.Items.Add(enterTextBus.Text);
                    enterTextBus.Clear();
                }

                e.Handled = true;
                
            }
        }

        private void busSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            busList.Items.Remove(busList.SelectedItem);
        }
    }
}

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
        string firstRawPath, SectionRawPath, savePath, folderName;
        bool prodIdvFile, prodVisioFile;
        public BusSelectionForm(string firstRaw, string secondRaw, string sPath, string sName, bool prodVisio = true, bool prodIdv = true)
        {
            InitializeComponent();
            firstRawPath = firstRaw;
            SectionRawPath = secondRaw;
            savePath = sPath;
            folderName = sName;
            prodVisioFile = prodVisio;
            prodIdvFile = prodIdv;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string[] list = busList.Items.Cast<string>().ToArray();
            Array.Sort<string>(list);
            if (list.Length != 0)
            {
                CompareTool.StartCompareTool(firstRawPath, firstRawPath, list, savePath, folderName, "Before-", prodVisioFile, false);

                CompareTool.StartCompareTool(firstRawPath, SectionRawPath, list, savePath, folderName, "After-", prodVisioFile, prodIdvFile);
                
                
                MessageBox.Show("Your files has been successfully saved to the following location: \n\n " + savePath + "\\" + folderName, "File Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

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
    public partial class busSelection : Form
    {
        List<string> CheckedBusList = new List<string>();
        List<string> busList = new List<string>();
        string firstPath, secondPath, savePath, saveName;
        
        
        public busSelection(string path1, string path2, string newSavePath, string newSaveName)
        {
            firstPath = path1; secondPath = path2; savePath = newSavePath; saveName = newSaveName;

            InitializeComponent();

            CheckedBusList.Clear();
            busList.Clear();
            
            var checkList = BusCheckList.Items;
            busList = CompareTool.getBusList(path1, path2);
            busList.Sort();
            checkList.AddRange(busList.ToArray());
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            CompareTool.StartCompareTool(firstPath, secondPath, CheckedBusList.ToArray(), savePath, saveName);

            MessageBox.Show("Your file has been successfully saved to the following location: \n\n " + savePath + "\\" + saveName + ".vsd", "File Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CheckList_SelectedIndexChanged(object sender, EventArgs e)
        {  
            if(BusCheckList.CheckedItems.Contains(BusCheckList.SelectedItem))
            {
                CheckedBusList.Add((string)BusCheckList.SelectedItem); 
            }
            else
            {
                CheckedBusList.Remove((string)BusCheckList.SelectedItem);
            }
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var search = SearchBox.Text.Trim();
            BusCheckList.BeginUpdate();
            var checkList = BusCheckList.Items;
            checkList.Clear();
            if(!String.IsNullOrWhiteSpace(search))
            {
               
                foreach(string item in busList)
                {
                    if(item.Contains(search))
                    {
                        checkList.Add(item, (CheckedBusList.Contains(item))? true : false);
                    }
                }
            }
            else
            {
                 foreach(string item in busList)
                {
                     checkList.Add(item, (CheckedBusList.Contains(item))? true : false);
                }
            }
            BusCheckList.EndUpdate();
        }

        private void cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

 
    }
}

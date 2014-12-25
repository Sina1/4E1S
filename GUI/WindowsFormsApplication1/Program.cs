using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    static class Program
    {
        // static variabler
        //static String baseCase = "";
        //static String newCase = "";
        //static String destFolder = "";
        //static String filename = "";


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            var form = new Form1();
            var result = form.ShowDialog();
            /* Brett has commented this out because it was hard to work around
             * He is planning to delete this later 
             *  -----> Don't remove this
             
           
            var baseCase = "";
            var newCase = "";
            var destFolder = "";
            var filename = "";

            if (result == DialogResult.OK) {
                baseCase = form.baseCase;
                newCase = form.newCase;
                destFolder = form.destFolder;
                filename = form.filename;
            }
            else {
                Application.Exit();
            }
            

          
            // read files
            // select area/busses
            // make database
            // compare

            // call drawing tool

            //temp
            MessageBox.Show("Completed. File Saved to \n " + destFolder + "\\" + filename, "Complete", MessageBoxButtons.OK);

            DrawTool dTool = new DrawTool(destFolder, filename);
            //dTool.drawCanned();
            
            // Roshaan: moved the completed dialog box here
            MessageBox.Show("Completed. File Saved to \n " + destFolder + "\\" + filename, "Complete", MessageBoxButtons.OK);
            */

        }
    }

    static class dummyTest
    {
        public static void StartMockProject(string destFolder, string filename)
        {

            // call drawing tool
            DrawTool dTool = new DrawTool(destFolder, filename);
            dTool.drawCanned();
        }
    }

   
}

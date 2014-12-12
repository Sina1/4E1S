using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

//ADDED
using System.IO;
using System.Data.SqlClient;
//using System.Data.SqlServerCe;

namespace WindowsFormsApplication1
{
    static class Program
    {
        // static variabler
        static String baseCase = "";
        static String newCase = "";
        static String destFolder = "";
        static String filename = "";


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
            form.ShowDialog();
            /* Brett has commented this out because it was hard to work around
             * He is planning to delete this later 
             * 
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
            DrawTool dTool = new DrawTool(destFolder, filename);
            dTool.drawCanned();
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

    static class FileReader
    {
        static private string currentSection = "Bus_Data";
        public static void ConvertFileToDatabases(string fileLocation)
        {
            
            StreamReader rawFile = new StreamReader(fileLocation);

            //Brett come back and do it for all sections
            ConvertSectionToDataBase(rawFile);
        }

        private static void ConvertSectionToDataBase(StreamReader rawFile )
        {
            //Brett Create db and then add to it
        }
    }


    /*This will conert a string and seperate it into comas
     * This will also check to see what section we are in
     * and See when a section ends
     */
    static class Converter
    {

        /*This will convert a single line
         * Input: line - line of the strin that can be converted
         * Output: Array of strings
         * Error: You can't enter lines that are not suppose to be cnverted
         */ 
        public static string [] ConverterString(string line)
        {
            //Remove unwanted char and convert into array
            line = line.Replace(" ", string.Empty);
            line = line.Replace("'", string.Empty);
            string[] words = line.Split(',');
            return words;
        }

        /*Checks to see if this is a proper convertable string
         *Input: line- the line to be tested
         *Output: True - if the string is properly convertable
         *        False - Something is wrong with this string
         */        
        public static bool TestString(string line)
        {
            if (false)
            {
                return false;
            }
            return true;
        }

        public static bool EndString(string line)
        {
            line = line.Replace(" ", string.Empty);
           //Test to see if this is the section ender
            if (line.StartsWith("0/")) return true;

            return false;
        }
    }

    /*This is where all functions that are connected to the database will be 
     * located. 
     */ 
    class DataBaseConnection
    {

        private static bool dbCreated = false; //Tell if this section database has been created
        private static string dbName = "";
        public static void CreateDatabase(string newDbName)
        {
            try
            {
                dbCreated = true;
                dbName = newDbName;
            }catch(Exception e)
            {

            }
        }

        public static void AddToDataBase()
        {

        }
    }
}

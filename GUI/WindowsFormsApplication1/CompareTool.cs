using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//ADDED
using System.IO;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{

    /* Note: This will convert the files into the database and compare what the drawtool needs
    */ 
    static class CompareTool
    {
        
        private static FileReader beforeBusCase;
        private static FileReader afterBusCase;

        /* Note: This will take in the 2 path files and create the fileReaders that are need when the compare tool is started
        * Input: beforePath - the before bus cases path to the raw file 
         *      afterPath - the after bus case path to the raw file
        * Output: Nothing
        */
        public static void StartCompareTool(string beforePath, string afterPath)
        {
            beforeBusCase = new FileReader(beforePath);
            afterBusCase = new FileReader(afterPath);
        }


    }
    
    /* Note:
    * Input:
    * Output:
    */ 
    class FileReader
    {
        private static string currentSection = "Bus_Data";

        /* Note:
        * Input:
        * Output:
        */ 
        public FileReader(string path)
        {
            StreamReader rawFile = new StreamReader(path);
            ConvertFileToDatabases(rawFile);
            
        }

        private static void ConvertFileToDatabases(StreamReader rawFile)
        {
            //Brett come back and do it for all sections
            ConvertSectionToDataBase(rawFile);
        }

        /* Note:
        * Input:
        * Output:
        */ 
        private static void ConvertSectionToDataBase(StreamReader rawFile)
        {
            //Brett Create db and then add to it
        }
    }


    /* Note:
    */ 
    static class Converter
    {

        /*This will convert a single line
         * Input: line - line of the string that can be converted
         * Output: Array of strings
         * Error: You can't enter lines that are not suppose to be converted
         */
        public static string[] ConverterString(string line)
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

        /* Note:
        * Input:
        * Output:
        */ 
        public static bool EndString(string line)
        {
            line = line.Replace(" ", string.Empty);
            //Test to see if this is the section ender
            if (line.StartsWith("0/")) return true;

            return false;
        }
    }

    /* Note:
    * Input:
    * Output:
    */ 
    class DataBaseConnection
    {
        /*List of items to improve on Brett
         * -Create the table
         * -Add to it
         * 
         */ 
      
        private static string tableName;
        private static SqlConnection con;

        /* Note:
        * Input:
        * Output:
        */ 
        public DataBaseConnection(string newTableName)
        {
            //Brett come back to this Might cause issues
            /*Things to test for
             * What if it fails (what the program does)
             * What if we have the same db (Clear and replace)
             */
            var currentDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            con = new SqlConnection(String.Format("Data Source=(LocalDB)\\v11.0;AttachDbFilename={0}\\DrawToolDB.mdf;Integrated Security=True",currentDir));
            tableName = newTableName;
            Console.WriteLine(currentDir);

       
            try
            {
                    
                con.Open();

                var commandStr = String.Format("If not exists (select name from sysobjects where name = '{0}') CREATE TABLE {0}(First_Name char(50),Last_Name char(50),Address char(50),City char(50),Country char(25),Birth_Date datetime)", newTableName);
                using (SqlCommand cmd = new SqlCommand(commandStr, con)) cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            con.Close();            
      
        }

        /* Note:
         * Input:
         * Output:
         */
        public virtual void AddToDataBase()
        {
            
            //Insert into the db
            con.Open();
            try{
            var commandStr = String.Format("Insert into {0} (First_Name, Last_Name) values ('Brett', 'Pel')", tableName);
            using (SqlCommand cmd = new SqlCommand(commandStr, con)) cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            con.Close();
        }

        /* Note:
        * Input:
        * Output:
        */
        public virtual void getFromDataBase()
        {

        }
    }
}

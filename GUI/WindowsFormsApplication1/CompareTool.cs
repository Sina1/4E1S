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
            //afterBusCase = new FileReader(afterPath);
        }

        public static void ClearData()
        {
            beforeBusCase.ClearTables();

        }


    }
    
    /* Note:
    * Input:
    * Output:
    */ 
    class FileReader
    {

        //List of sections that have data
        private static List<string> sectionList = new List<string> ();

        //List of DataConnection
        private static List<DataBaseConnection> dataConnectionList = new List<DataBaseConnection>();

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
            string line;
            bool firstSection = true;
            bool firstEntrie = true;
            DataBaseConnection currentDBConnection;

            //Move the section to the first entrie
            //Brett Test to see if this works with all raw files
            for(int i = 0; i < 3; i++) line = rawFile.ReadLine();

            line = rawFile.ReadLine();
            while(!LineConverter.FileEnd(line))
            {

                //Skip this onces
                if (!firstSection)
                {
                    currentSection = LineConverter.GetNextSection(line);          
                    line = rawFile.ReadLine();    
                }
                else { firstSection = false; }


                while (!LineConverter.EndSectionString(line) )
                {
                    //This test to see if a section has an entrie into the database
                    if (firstEntrie)
                    {
                        sectionList.Add(currentSection);
                        currentDBConnection = new DataBaseConnection(currentSection);
                        dataConnectionList.Add(currentDBConnection);
                        firstEntrie = false;
                    }

                    //Where we convert lines and add to the database
                    System.Console.WriteLine(line);
                    line = rawFile.ReadLine();           
                }
                firstEntrie = true;
            }
           
        }

        public virtual void ClearTables()
        {
            dataConnectionList.ForEach(delegate(DataBaseConnection database)
            {
                database.clearAllDataBase();
            });
        }
    }


    /* Note:
    */ 
    static class LineConverter
    {

        /*This will convert a single line
         * Input: line - line of the string that can be converted
         * Output: Array of strings
         * Error: You can't enter lines that are not suppose to be converted
         */
        public static string[] ConverterLine(string line)
        {
            //Remove unwanted char and convert into array
            line = line.Replace(" ", string.Empty);
            line = line.Replace("'", string.Empty);
            string[] words = line.Split(',');
            return words;
        }

        public static string GetNextSection(string line)
        {
            int pos = line.LastIndexOf("BEGIN");
            if (pos <= 0) return "";


            string nextSection = line.Substring(pos + 5);
            nextSection = nextSection.Trim().Replace(" ", "_");

            return nextSection;
        }

        /*
         *Input: 
         *Output: 
         */
        public static bool FileEnd(string line)
        {
            if (line.StartsWith("Q")) { Console.WriteLine("End Passes");  return true; }
            return false;
        }

        /* Note:
        * Input:
        * Output:
        */ 
        public static bool EndSectionString(string line)
        {
            line = line.Replace(" ", string.Empty);
            //Test to see if this is the section ender
            if (line.StartsWith("0/") || line.StartsWith("Q")) return true;

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

        public virtual void clearAllDataBase()
        {
            /* Brett need to fix this
            con.Open();
            try
            {
                var commandStr = String.Format("DELETE * FROM {0}", tableName);
                using (SqlCommand cmd = new SqlCommand(commandStr, con)) cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            con.Close();
             */
        }
    }
}

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


        /* Note: This will take in the 2 path files and create the fileReaders that are need when the compare tool is started
        * Input: beforePath - the before bus cases path to the raw file 
         *      afterPath - the after bus case path to the raw file
        * Output: Nothing
        */
        public static void StartCompareTool(string compareFilePath1, string compareFilePath2, string busSection, string savePath, string saveName )
        {
            beforeBusCase = new FileReader(compareFilePath1, compareFilePath2, busSection, savePath, saveName);
            

            
        }

        public static void ClearData()
        {
            //beforeBusCase.ClearTables();

        }


    }

    /* Note:
    * Input:
    * Output:
    */
    class FileReader
    {

        //List of sections that have data
        private static List<string> sectionList = new List<string>();

        //List of DataConnection
        private static List<DataBaseConnection> dataConnectionList = new List<DataBaseConnection>();

        private static DataBaseConnection compareDB = new DataBaseConnection();

        private static List<string> busList = new List<string>();



        //The first section
        private static string currentSection = "BUS_DATA";

        /* Note:
        * Input:
        * Output:
        */
        public FileReader(string compareFilePath1, string compareFilePath2, string busSet, string savePath, string saveName )
        {
            busList.AddRange(LineConverter.ConverterLine(busSet));
            StreamReader rawFileFirst = new StreamReader(compareFilePath1);
            StreamReader rawFileSecond = new StreamReader(compareFilePath2);
            //Brett ----------------------------------------------
            compareDB = new DataBaseConnection();
            compareDB.setBusList(busSet);
            ConvertFilesToDatabases(rawFileFirst, true);
            ConvertFilesToDatabases(rawFileSecond, false);

            //Call to get the function Roshaan Add here

            //Fucntion( compareDB.getBus();
            compareDB.getBusList(); //Bust informatin list
           compareDB.getConnectionList(); //connection between busses
           //savePath; //file path 
            //saveName;//file name

        }

      
        private static void ConvertFilesToDatabases(StreamReader rawFile, bool firstRun)
        {
            string line;
            bool firstSection = true;
            bool firstEntrie = true;
            DataBaseConnection currentDBConnection;

            //Move the section to the first entrie
            //Brett Test to see if this works with all raw files
            for (int i = 0; i < 3; i++) line = rawFile.ReadLine();

            line = rawFile.ReadLine();
            while (!LineConverter.FileEnd(line))
            {



                //Will skip the first section because we already know it
                if (!firstSection)
                {
                    currentSection = LineConverter.GetNextSection(line);
                    line = rawFile.ReadLine();

                }
                else { firstSection = false; }


                while (!LineConverter.EndSectionString(line))
                {

                    if (currentSection.CompareTo("BRANCH_DATA") == 0)
                    {
                
                   
                        //This test to see if a section has an entrie into the database
                        if (firstEntrie)
                        {
                            //sectionList.Add(currentSection);

                            //compareDB.CreateConnectionDatabase(currentSection);

                            
                            //currentDBConnection =  new DataBaseConnection();
                            //dataConnectionList.Add(compareDB);
                            firstEntrie = false;
                        }

                        string[] lineArr = LineConverter.ConverterLine(line);

                        if (busList.Contains(lineArr[0]) && busList.Contains(lineArr[1]))
                        {
                            if (firstRun) compareDB.CompareTableFirstRun(lineArr[0], lineArr[1]);
                            else compareDB.CompareTableSecondRun(lineArr[0], lineArr[1]);
                        }
   
                    }
                    line = rawFile.ReadLine();
                }
                firstEntrie = true;
            }
           

        }

         public virtual  void ClearTables()
         {
             dataConnectionList.ForEach(delegate(DataBaseConnection database)
             {
                 database.clearAllData();
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
            line = line.ToUpper();
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
            if (String.IsNullOrEmpty(line)) return true;
            if (line.StartsWith("Q")) { return true; }
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

        private static List<Dictionary<string, string>> busList = new List<Dictionary<string,string>>();
        private static List<Dictionary<string, string>> connectionList = new List<Dictionary<string, string>>();

       

        /* Note:
        * Input:
        * Output:
        */
        //Brett we need to test what we can do with this
        public virtual void CreateConnectionDatabase(string newTableName)
        {
            //Brett come back to this Might cause issues
            /*Things to test for
             * What if it fails (what the program does)
             * What if we have the same db (Clear and replace)
             */
            var currentDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            con = new SqlConnection(String.Format("Data Source=(LocalDB)\\v11.0;AttachDbFilename={0}\\DrawToolDB.mdf;Integrated Security=True", currentDir));
            tableName = newTableName;

            try
            {

                con.Open();

                var commandStr = String.Format("If not exists (select name from sysobjects where name = '{0}') CREATE TABLE {0}(Bus_From char(50),Bus_To char(50),Connection_Status char(50))", newTableName);
                using (SqlCommand cmd = new SqlCommand(commandStr, con)) cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            con.Close();

        }




       public virtual void setBusList(string list)
        {
           string[] busSet = LineConverter.ConverterLine(list);

           for (int i = 0; i < busSet.Length; i++ )
           {
               busList.Add(new Dictionary<string,string>());
               busList[i].Add("name", busSet[i]);
               busList[i].Add("description", busSet[i]);
               busList[i].Add("status", ".");
           }



        }
        //A temp to make the demo work
        public virtual void CompareTableFirstRun(string busFrom, string busTo)
        {
            string status = "-";

            connectionList.Add(new Dictionary<string, string>());
            connectionList.Last().Add("1", busFrom);
            connectionList.Last().Add("2", busTo);
            connectionList.Last().Add("status", status);


        }

        public virtual void CompareTableSecondRun(string busFrom, string busTo)
        {
            bool inSystem = false;
            foreach(var entry in connectionList)
            {
                if (entry.ContainsValue(busFrom) && entry.ContainsValue(busTo))
                {
                    entry["status"] = ".";
                    inSystem = true;
                }
            }

            if (!inSystem)
            {
                connectionList.Add(new Dictionary<string, string>());
                connectionList.Last().Add("1", busFrom);
                connectionList.Last().Add("2", busTo);
                connectionList.Last().Add("status", "+");
            }

        
        }

        /* Note:
        * Input:
        * Output:
        */
        /*public virtual void getBusConnection()
        {

           /* con.Open();
            try
            {
                string commandStr = String.Format("SELECT * FROM {0}", tableName);
                using (SqlCommand cmd = new SqlCommand(commandStr, con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {



                           // Console.WriteLine(reader.GetString(i));
                        
                    }

                }
                   
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            con.Close();
        }*/

        public virtual List<Dictionary<string, string>> getBusList()
        {
            return busList;
        }
        public virtual List<Dictionary<string, string>> getConnectionList() 
        {
           /*foreach (var output in connectionList)
            {
                var busFrom = output["1"];
                var busTo = output["2"];
                var status = output["status"];
                string statusOf = " ";
                if( status.CompareTo(".") == 0)
                    statusOf = "Connected";
                else if( status.CompareTo("+") == 0)
                    statusOf = "Added";
                else
                    statusOf = "Removed";


                Console.WriteLine(output.ToString());//"Bus From " + busFrom + " to " + busTo + " is " + statusOf);
            }*/
            return connectionList;
        }


        //This is now the removed from database Brett update
        private static void dataBaseCommand(/**/)
        {

            //This inserts into
            //string test = String.Format("Insert into {0} (Bus_From,Bus_To,Connection_Status) values ({1},{2},'{3}')", tableName, busFrom, busTo, status);
      
            con.Open();
            try
            {
                var commandStr = String.Format("delete from {0}", tableName);
                using (SqlCommand cmd = new SqlCommand(commandStr, con)) cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            con.Close();
            con.Dispose();
        }

        public virtual void clearAllData()
        {      
            
            
            
            
            
        }

    }


}


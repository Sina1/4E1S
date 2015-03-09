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

   


    static class CompareTool
    {
        
        //lists
        private static List<string> sectionList = new List<string>();       
        private static List<string> stringBusList = new List<string>();
        private static List<Dictionary<string, string>> busList = new List<Dictionary<string,string>>();
        private static List<Dictionary<string, string>> connectionList = new List<Dictionary<string, string>>();
        private static List<string> entireBusList = new List<string>();

        public static List<string> getBusList(string filePath1, string falePath2)
        {
            entireBusList.Clear();
            convertSection(filePath1);
            convertSection(falePath2);
            return entireBusList;
        }

        public static void convertSection(string filePath)
        {

            StreamReader rawFile = new StreamReader(filePath);
            string line = "";

            for (int i = 0; i < 4; i++) line = rawFile.ReadLine();

            while (!LineConverter.EndSectionString(line))
            {
                string[] lineArr = LineConverter.ConverterLine(line);

                if (!entireBusList.Contains(lineArr[0]))
                {
                    entireBusList.Add(lineArr[0]);
                }

                line = rawFile.ReadLine();
            }

        } 
   


        public static void StartCompareTool(string compareFilePath1, string compareFilePath2, string[] busSet, string savePath, string saveName )
        {

            stringBusList.AddRange(busSet);
            StreamReader rawFileFirst = new StreamReader(compareFilePath1);
            StreamReader rawFileSecond = new StreamReader(compareFilePath2);

            setBusList(busSet);
            ConvertFilesAndStore(rawFileFirst, true);
            ConvertFilesAndStore(rawFileSecond, false);

            //Call to get the function Roshaan Add here
            DrawTool dTool = new DrawTool(savePath, saveName);
            dTool.drawGraph(busList, connectionList);
        }

      
        private static void ConvertFilesAndStore(StreamReader rawFile, bool firstRun)
        {
            string line;
            bool firstSection = true;
            string currentSection = "BUS_DATA";
  

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
                        string[] lineArr = LineConverter.ConverterLine(line);

                        if (stringBusList.Contains(lineArr[0]) && stringBusList.Contains(lineArr[1]))
                        {
                            if (firstRun) CompareTableFirstRun(lineArr[0], lineArr[1]);
                            else CompareTableSecondRun(lineArr[0], lineArr[1]);
                        }

                    }
                    line = rawFile.ReadLine();
                }

            }   
        }

    
        private static void setBusList(string[] busses)
        {
            for (int i = 0; i < busses.Length; i++)
           {
               busList.Add(new Dictionary<string,string>());
               busList[i].Add("name", busses[i]);
               busList[i].Add("description", busses[i]);
               busList[i].Add("status", ".");
           }
        }

        private static void CompareTableFirstRun(string busFrom, string busTo)
        {
            string status = "-";

            connectionList.Add(new Dictionary<string, string>());
            connectionList.Last().Add("1", busFrom);
            connectionList.Last().Add("2", busTo);
            connectionList.Last().Add("status", status);


        }
        private static void CompareTableSecondRun(string busFrom, string busTo)
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

    }



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

    }





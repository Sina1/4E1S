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
        private static List<string> stringBusList = new List<string>();
        private static List<Dictionary<string, string>> busList = new List<Dictionary<string,string>>();
        private static List<Dictionary<string, string>> connectionList = new List<Dictionary<string, string>>();


        /*
        
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

        } */

        public static void StartCompareTool(string compareFilePath1, string compareFilePath2, string[] busSet, string savePath, string saveName )
        {

            stringBusList.AddRange(busSet);
            StreamReader rawFileFirst = new StreamReader(compareFilePath1);
            StreamReader rawFileSecond = new StreamReader(compareFilePath2);

            ConvertFilesAndStore(rawFileFirst, true);
            ConvertFilesAndStore(rawFileSecond, false);

            //Call to get the function Roshaan Add here
           // DrawTool dTool = new DrawTool(savePath, saveName);
           // dTool.drawGraph(busList, connectionList);

            //Clear all lists
            stringBusList.Clear();
            busList.Clear();
            connectionList.Clear();

        }

      
        private static void ConvertFilesAndStore(StreamReader rawFile, bool firstRun)
        {
            string line;
            bool firstSection = true;
            string currentSection = "BUS_DATA";
            string[] lineArr;
  

            //Move the section to the first entrie
            //Brett Test to see if this works with all raw files
            for (int i = 0; i < 3; i++) line = rawFile.ReadLine();

            line = rawFile.ReadLine();
            while (!LineConverter.FileEnd(line))
            {
                if (!firstSection)
                {
                    currentSection = LineConverter.GetNextSection(line);
                    line = rawFile.ReadLine();

                }
                else { firstSection = false; }

                while (!LineConverter.EndSectionString(line))
                {
                    switch (currentSection)
                    {
                        case "BUS_DATA":
                            lineArr = LineConverter.ConverterLine(line);
                            lineArr[0] = lineArr[0].Replace("-", string.Empty);
                            if (stringBusList.Contains(lineArr[0]))
                            {
                                if (firstRun) setBusListFirstRun(lineArr);
                                else setBusListSecondRun(lineArr);

                            }
                            line = rawFile.ReadLine();
                            break;

                        case "BRANCH_DATA":
                            lineArr = LineConverter.ConverterLine(line);
                            lineArr[0] = lineArr[0].Replace("-", string.Empty);
                            lineArr[1] = lineArr[1].Replace("-", string.Empty);

                            if (stringBusList.Contains(lineArr[0]) && stringBusList.Contains(lineArr[1]))
                            {
                                if (firstRun) CompareTableFirstRun(lineArr[0], lineArr[1]);
                                else CompareTableSecondRun(lineArr[0], lineArr[1]);
                            }
  
                            line = rawFile.ReadLine();
                            break;

                        default:
                            line = rawFile.ReadLine();
                            break;
                    }


                    
                }

            } 
  

        }
        

        private static void setBusListFirstRun(string[] rawBusInfo)
        {
            var busInformation = new Dictionary<string, string>();
            busInformation.Add("name", rawBusInfo[0]);
            busInformation.Add("description", rawBusInfo[2] + " kV");
            busInformation.Add("status", "-");
            busList.Add(busInformation);      
        }

        private static void setBusListSecondRun(string[] rawBusInfo)
        {
            bool inSystem = false;
            foreach (var bus in busList)
            {
                if (bus.ContainsValue(rawBusInfo[0]))
                {
                    bus["status"] = ".";
                    inSystem = true;
                    break;
                }
            }

            if (!inSystem)
            {
                var busInformation = new Dictionary<string, string>();
                busInformation.Add("name", rawBusInfo[0]);
                busInformation.Add("description", rawBusInfo[2] + " kV");
                busInformation.Add("status", "+");
                busList.Add(busInformation);
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
            foreach (var entry in connectionList)
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

        private static void createIDev(string savePath)
        {
            if (!File.Exists(savePath))
            {
                using (StreamWriter sw = File.CreateText(savePath))
                {
                    sw.WriteLine("Hello");
                    sw.WriteLine("And");
                    sw.WriteLine("Welcome");
                    sw.Close();
                }	
                
            }
            else Console.WriteLine("Create Dev File issues");
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
                line = line.Replace("\"", " ");
                line = line.Replace("'", " ");
                line = line.Replace(",", " ");
                string[] words = line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
               
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
                if (String.IsNullOrEmpty(line)) return true;
                line = line.Replace(" ", string.Empty);
                //Test to see if this is the section ender
                if (line.StartsWith("0/") || line.StartsWith("Q")) return true;

                return false;
            }
        }

    }




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
        private static List<Dictionary<string, string>> nodeList = new List<Dictionary<string,string>>();
        private static List<Dictionary<string, string>> connectionList = new List<Dictionary<string, string>>();
        private static List<Dictionary<string, string>> idvList = new List<Dictionary<string, string>>();



        /*
        Get the busList
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

        public static void StartCompareTool(string compareFilePath1, string compareFilePath2, string[] busSet, string savePath, string saveFolder, bool produceVisio, bool produceIdv)
        {

            stringBusList.AddRange(busSet);
            StreamReader rawFileFirst = new StreamReader(compareFilePath1);
            StreamReader rawFileSecond = new StreamReader(compareFilePath2);

            ConvertFilesAndStore(rawFileFirst, true);
            ConvertFilesAndStore(rawFileSecond, false);

            if (produceVisio)
            {
                //Call to get the function Roshaan Add here
                string saveFullPath = savePath + "\\" + saveFolder;
                //DrawTool dTool = new DrawTool(saveFullPath, "VisioFile");
                //dTool.drawGraph(nodeList, connectionList);
            }

            if(produceIdv)
            {

            }
            //Clear all lists
            stringBusList.Clear();
            nodeList.Clear();
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
                                BusNodeFunction(lineArr, firstRun, line);
                            }
                            break;
                        case "GENERATOR_DATA":
                            lineArr = LineConverter.ConverterLine(line);
                            lineArr[0] = lineArr[0].Replace("-", string.Empty);
                             if (stringBusList.Contains(lineArr[0]))
                            {
                                GeneratorNodeFunction(lineArr, firstRun, line);
                            }
                            break;
                        case "BRANCH_DATA":
                            lineArr = LineConverter.ConverterLine(line);
                            lineArr[0] = lineArr[0].Replace("-", string.Empty);
                            lineArr[1] = lineArr[1].Replace("-", string.Empty);

                            if (stringBusList.Contains(lineArr[0]) && stringBusList.Contains(lineArr[1]))
                            {
                                BranchConnectionNode(lineArr, firstRun, line);
                            }
                            break;
                        case "TRANSFORMER_DATA":
                            lineArr = LineConverter.ConverterLine(line);
                            lineArr[0] = lineArr[0].Replace("-", string.Empty);
                            lineArr[1] = lineArr[1].Replace("-", string.Empty);
                            if (stringBusList.Contains(lineArr[0]) && stringBusList.Contains(lineArr[1]))
                            {
                                TransformerNodeFunction(lineArr, firstRun, line);
                            }

                            break;
                        default:
                            break;
                    }
                    line = rawFile.ReadLine();


                    
                }

            } 
  

        }
        

        private static void BusNodeFunction(string[] rawBusInfo, bool firstRun, string fullLine)
        {
            bool inSystem = false;

            if (!firstRun)
            {
                foreach (var node in nodeList)
                {
                    //Checks to see if this connection has the 2 bus numbers and the id
                    if (node.ContainsValue(rawBusInfo[0]) && string.Compare(node["type"], "bus", true) == 0) 
                    {
                        node["status"] = ".";
                        node["reason"] = "norm";
                        inSystem = true;
                        break;
                    }
                }
            }

            if (firstRun || !inSystem)
            {
                string status = (firstRun) ? "-" : "+";
                string reason = (firstRun) ? "removed" : "Added";
                var busInformation = new Dictionary<string, string>();
                busInformation.Add("type", "bus");
                busInformation.Add("name", rawBusInfo[0]);
                busInformation.Add("description", rawBusInfo[2] + " kV");
                busInformation.Add("status", status);
                busInformation.Add("codeFrom", rawBusInfo[9]);
                busInformation.Add("reason", reason); //This is used for the idv file (if changes made to this make sure to change the idv file)
                nodeList.Add(busInformation);   

                if(!firstRun)
                {
                    var idvLineInfo = new Dictionary<string, string>();
                    idvLineInfo.Add("type", "bus");
                    idvLineInfo.Add("line", fullLine);
                    idvList.Add(idvLineInfo);
                }
               
            }
        }

        private static void BranchConnectionNode(string[] rawConnectInfo, bool firstRun, string fullLine)
        {
            
            bool inSystem = false;

            if (!firstRun)
            {
                foreach (var connection in connectionList)
                {
                    //Checks to see if this connection has the 2 bus numbers and the id
                    if (connection.ContainsValue(rawConnectInfo[0])&& connection.ContainsValue(rawConnectInfo[1])&& connection.ContainsValue(rawConnectInfo[2]))
                    {
                        connection["status"] = ".";
                        inSystem = true;
                        break;
                    }
                }
            }

            if (firstRun || !inSystem)
            {
                string status = (firstRun) ? "-" : "+";
                Dictionary<string, string> connection = new Dictionary<string, string>();
                connection.Add("1", rawConnectInfo[0]);
                connection.Add("2", rawConnectInfo[1]);
                connection.Add("description", "");
                connection.Add("status", status);
                connection.Add("serviceFrom", rawConnectInfo[8]);
                connection.Add("id", rawConnectInfo[2]);

                connectionList.Add(connection);

                if (!firstRun)
                {
                    var idvLineInfo = new Dictionary<string, string>();
                    idvLineInfo.Add("type", "branch");
                    idvLineInfo.Add("line", fullLine);
                    idvList.Add(idvLineInfo);
                }
                
            }
        }


        private static void GeneratorNodeFunction(string[] rawGenInfo, bool firstRun, string fullLine)
        {
            bool inSystem = false;
            
            if(!firstRun)
            {
                       
                foreach (var node in nodeList)
                {
                    //checks if the node has the same bus connection, if it is a generator type and has the same id
                    if (node.ContainsValue(rawGenInfo[0]) && string.Compare(node["type"], "generator", true) == 0 && node.ContainsValue(rawGenInfo[1]))
                    {
                        node["status"] = ".";
                        inSystem = true;
                        break;
                    }
                }
            }

            if(firstRun || !inSystem)
            {
                string status = (firstRun) ? "-" : "+";
                var generatorInfo = new Dictionary<string, string>();
                generatorInfo.Add("type","generator");
                generatorInfo.Add("name", rawGenInfo[0]);
                generatorInfo.Add("id", rawGenInfo[1]);           
                generatorInfo.Add("description", "");
                generatorInfo.Add("status", status);
                nodeList.Add(generatorInfo);

                if (!firstRun)
                {
                    var idvLineInfo = new Dictionary<string, string>();
                    idvLineInfo.Add("type", "generator");
                    idvLineInfo.Add("line", fullLine);
                    idvList.Add(idvLineInfo);
                }
            }
        }

        private static void TransformerNodeFunction(string[] rawTranInfo, bool firstRun, string fullLine)
        {
            bool inSystem = false;

            if (!firstRun)
            {

                foreach (var node in nodeList)
                {
                    //checks if the node has the same bus connection, if it is a generator type and has the same id
                    if (node.ContainsValue(rawTranInfo[0]) && node.ContainsValue(rawTranInfo[1]) && node.ContainsValue(rawTranInfo[2]) && string.Compare(node["type"], "transformer", true) == 0)
                    {
                        node["status"] = ".";
                        inSystem = true;
                        break;
                    }
                }
            }

            if (firstRun || !inSystem)
            {
                string status = (firstRun) ? "-" : "+";
                var generatorInfo = new Dictionary<string, string>();
                generatorInfo.Add("type", "transformer");
                generatorInfo.Add("busFrom", rawTranInfo[0]);
                generatorInfo.Add("busTo", rawTranInfo[1]);
                generatorInfo.Add("description", "");
                generatorInfo.Add("id", rawTranInfo[2]);
                generatorInfo.Add("status", status);
                nodeList.Add(generatorInfo);

                if (!firstRun)
                {
                    var idvLineInfo = new Dictionary<string, string>();
                    idvLineInfo.Add("type", "transformer");
                    idvLineInfo.Add("line", fullLine);
                    idvList.Add(idvLineInfo);
                }
            }
        }

        private static void CreateIDev(string savePath)
        {


            if (!File.Exists(savePath))
            {
                using (StreamWriter sw = File.CreateText(savePath))
                {

                    foreach (var node in nodeList)
                    {
                        if (String.Compare(node["type"], "bus", true) == 0 && String.Compare(node["reason"], "removed", true) == 0)
                        {
                            string line = "BAT_DSCN," + node["name"];
                            sw.WriteLine(line);
                        }
                    }
                    foreach (var connect in connectionList)
                    {
                        if (String.Compare(connect["status"], "-") == 0)
                        {
                            string line = "BAT_PURGBRN," + connect["1"] + "," + connect["2"] + ",'" + connect["id"] + "'";
                            sw.WriteLine(line);
                        }
                    }

                    //------------------------------------
                    sw.WriteLine("RDCH");
                    sw.WriteLine("1");
                    //Bus Added
                    enterIdvSec(sw, "bus");      
              
                    sw.WriteLine("0/ END OF BUS DATA, BEGIN LOAD DATA");
                    //Load data added

                    sw.WriteLine("0/ END OF LOAD DATA, BEGIN FIXED SHUNT DATA");
                    //Unknow at the moment

                    sw.WriteLine("0/ END OF FIXED SHUNT DATA, BEGIN GENERATOR DATA");
                    //Generators added
                    enterIdvSec(sw, "generator");  

                    sw.WriteLine("0/ END OF GENERATOR DATA, BEGIN BRANCH DATA");
                    enterIdvSec(sw, "branch");                    

                    sw.WriteLine("0/ END OF BRANCH DATA, BEGIN TRANSFORMER DATA");
                    enterIdvSec(sw, "transformer"); 
                   
                    
                    //This is what we can do later
                    /* sw.WriteLine("0/ END OF TRANSFORMER DATA, BEGIN AREA DATA");
                    sw.WriteLine("0/ END OF AREA DATA, BEGIN TWO-TERMINAL DC DATA");
                    sw.WriteLine("0/ END OF TWO-TERMINAL DC DATA, BEGIN VSC DC LINE DATA");
                    sw.WriteLine("0/ END OF VSC DC LINE DATA, BEGIN IMPEDANCE CORRECTION DATA");
                    sw.WriteLine("0/ END OF IMPEDANCE CORRECTION DATA, BEGIN MULTI-TERMINAL DC DATA");
                    sw.WriteLine("0/ END OF MULTI-TERMINAL DC DATA, BEGIN MULTI-SECTION LINE DATA");
                    sw.WriteLine("0/ END OF MULTI-SECTION LINE DATA, BEGIN ZONE DATA");
                    sw.WriteLine("0/ END OF ZONE DATA, BEGIN INTER-AREA TRANSFER DATA");
                    sw.WriteLine("0/ END OF INTER-AREA TRANSFER DATA, BEGIN OWNER DATA");
                    sw.WriteLine("0/ END OF OWNER DATA, BEGIN FACTS DEVICE DATA");
                    sw.WriteLine("0/ END OF FACTS DEVICE DATA, BEGIN SWITCHED SHUNT DATA");
                    sw.WriteLine("0/ END OF SWITCHED SHUNT DATA, BEGIN GNE DATA");
                    sw.WriteLine("0/ END OF GNE DATA, BEGIN INDUCTION MACHINE DATA");
                    sw.WriteLine("0/ END OF INDUCTION MACHINE DATA");*/

                    sw.WriteLine("Q");

                    sw.Close();
                }

            }
            else Console.WriteLine("Create Dev File issues");
        }

        private static void enterIdvSec(StreamWriter sw, string section )
        {
            foreach (var node in idvList)
            {
                if (String.Compare(node["type"], section, true) == 0)
                {
                    sw.WriteLine(node["line"]);
                }
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

                //One raw file type had this issue
                nextSection = nextSection.Trim().Replace("NON-TRANSFORMER", string.Empty);
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




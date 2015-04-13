using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Threading;
using System.Web;
using Newtonsoft.Json;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    // aliases
    using BusList = List<Dictionary<string, string>>;
    using ConnectionList = List<Dictionary<string, string>>;


    class DrawTool
    {
        // config
        static String visioPath = ""; // modify this to match visio path on your computer
        static String pythonPath = "";
        static String jsonFIlePath = "";

        // variables
        static String filepath = "";
        static String filename = "";



        public DrawTool(String _filepath, String _filename)
        {
            filepath = _filepath;
            filename = _filename;
        }

        public void drawGraph(BusList busList, ConnectionList connectionList)
        {
            if (busList.Count() == 0 && connectionList.Count() == 0)
            {
                throw new Exception(@"[busList cannot be of size 0.]");
            }

            // setup config variables
            string[] lines = System.IO.File.ReadAllLines("config.txt");

            visioPath = lines[0];
            pythonPath = lines[1];
            jsonFIlePath = lines[2];

            // combine filename and file path to get the target destination for the output file
            var currentDirectory = Directory.GetCurrentDirectory();
            String destFilePath = Path.Combine(filepath, filename).Replace("\\", "/");

            // seialize the connectionList and busList to JSON
            string jsonBusList = JsonConvert.SerializeObject(busList, Formatting.None);
            string jsonConnectionList = JsonConvert.SerializeObject(connectionList, Formatting.None);
            string jsonDestFilePath = JsonConvert.SerializeObject(connectionList, Formatting.None);

            String combinedJson = "{ \"filepath\":\"" + destFilePath + "\" , \"busList\": " + jsonBusList + ", \"connectionList\": " + jsonConnectionList + "}";

            // write text to json file
            System.IO.File.WriteAllText("jsonFile.txt", combinedJson);

            // check if python exists
            Process pythonVersionProcess = Process.Start(pythonPath , "--version");
            pythonVersionProcess.WaitForExit();
            if (pythonVersionProcess.ExitCode != 0) {
                //MessageBox.Show("Python27 not found in c:\\Python27. Exiting.");
                MessageBox.Show("Python27 not found in c:\\Python27. Exiting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Windows.Forms.Application.Exit();
            }
            // check if file exists
            // TODO soft code the .vdx
            if (File.Exists(destFilePath + ".vdx"))
            {
                DialogResult dialogResult = MessageBox.Show("File: " + destFilePath + " already exists. Overwrite?", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            

            Process bruteForceDrawTool = Process.Start(pythonPath , "bruteForceDrawTool.py");
            //Process process = Process.Start("cmd");  // Process.GetProcesses(); if you dont have.
            //string fullPath = process.Modules[0].FileName;
            //Console.Write(fullPath);
            bruteForceDrawTool.WaitForExit();



            
        }

        static int FakeGraphViz()
        {
            // call python module
            // Process p = Process.Start(pythonPath, "temp.py");
            // p.WaitForExit();



            return 1;
        }

    }
}

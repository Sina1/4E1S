using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;


namespace WindowsFormsApplication1
{
    class DrawTool
    {
        // config
        static String visioPath = "C:/Program Files/Microsoft Office/Visio10/Visio.exe"; // modify this to match visio path on your computer
        static String pythonPath = "C:\\Python33\\python.exe";

        // variables
        static String filepath = "";
        static String filename = "";

        public DrawTool(String _filepath, String _filename)
        {
            filepath = _filepath;
            filename = _filename;

        }
       
        public void drawCanned()
        {

            // setup config variables
            string[] lines = System.IO.File.ReadAllLines("config.txt");

            visioPath = lines[0];
            pythonPath = lines[1];


            //String filename = ""; //absolute path to visio file
            FakeGraphViz();

            // copy fake files
            Process.Start("copy", "dummy.VDX " + Regex.Replace(filepath, @"\\", @"\\") + "\\" + filename);


            //Process.Start("C:/python27/python.exe -c 'print(\"python\")\ninput(\"Press a key\")' "); // make sure that 
            //Process.Start(visioPath + " " + filename);


            
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

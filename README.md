4E1S
====

4th year design project

******* temporary********

class CannedDrawingTool
    {
        static void Main(string[] args)
        {
            String filename = ""; //absolute path to visio file
            String visioPath = "C:/Program Files/Microsoft Office/Visio10/Visio.exe"; // modify this to match visio path on your computer
            
            Process.Start("C:/python27/python.exe -c 'print(\"python\")\ninput(\"Press a key\")' "); // make sure that 
            Process.Start(visioPath + " " + filename);
        }
    }
    
    *********************

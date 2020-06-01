using System;
using System.Collections.Generic;
using System.IO;

namespace LogParser
{
    class Parser
    {
        public String LogDirectory;
        public List<String> LogLevels = new List<String>();
        public String outputDirectory;
        public void getFilesData()
        {
            try
            {
                string[] dirs = Directory.GetFiles(@LogDirectory, "*.log");
            
                foreach (string dir in dirs)
                {
                    Console.WriteLine(dir);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not find the directory " + e.ToString());
            }
        }
        void readFile()
        {
            
        }
        public void writeToCSV()
        {

        }
    }
}
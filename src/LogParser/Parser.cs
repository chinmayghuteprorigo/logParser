using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
                String outputFilePath = outputDirectory != null? outputDirectory : $"{LogDirectory}/output.csv";
                string[] dirs = Directory.GetFiles(@LogDirectory, "*.log");
                using(var fileWriter = new StreamWriter(outputFilePath))
                try{
                    foreach (string dir in dirs)
                    {
                        readFile(dir, fileWriter);
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    fileWriter.Flush();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not find the directory " + e.ToString());
            }
        }
        void readFile(String dir, StreamWriter fileWriter)
        {
            String line;
            // Console.WriteLine(dir);
            System.IO.StreamReader file =
                new System.IO.StreamReader(@dir);  
            try
            {
                while((line = file.ReadLine()) != null)  
                {  
                    writeToCSV(fileWriter, line);
                    // Console.WriteLine(line);
                }  
            }
            catch (Exception)
            {
                Console.WriteLine($"Error in reading file {dir}");
            }
            finally
            {
                file.Close();
            }
        }
        public void writeToCSV(StreamWriter fileWriter, String line)
        {
            
            var csv = new StringBuilder();
            var first = "first";
            var second = "Second";
            //Suggestion made by KyleMit
            // var newLine = line;
            fileWriter.WriteLine(line);
        }
    }
}
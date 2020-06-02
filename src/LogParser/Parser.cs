using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

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
                if (!outputFilePath.Contains(".csv"))
                {
                    outputFilePath += ".csv";
                }
                string[] dirs = Directory.GetFiles(@LogDirectory, "*.log");
                using(var fileWriter = new StreamWriter(outputFilePath))
                try{
                    int counter = 1;
                    fileWriter.WriteLine("Count, Date, Time, Logging Level, Info");
                    foreach (string dir in dirs)
                    {
                        readFile(dir, fileWriter, ref counter);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Something went wrong, Please try again.");
                }
                finally
                {
                    fileWriter.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not find the directory " + e.ToString());
            }
        }
        void readFile(String dir, StreamWriter fileWriter, ref int counter)
        {
            String line;
            System.IO.StreamReader file =
                new System.IO.StreamReader(@dir);  
            try
            {
                while((line = file.ReadLine()) != null)  
                {  
                    writeToCSV(fileWriter, line, ref counter);
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
        public void writeToCSV(StreamWriter fileWriter, String line, ref int counter)
        {
            string date = "";
            string time = "";
            string loggingLevel = "";
            string info = "";
            var match = Regex.Match(line, @"([^\s]*\s\s)",
                RegexOptions.IgnoreCase);
            loggingLevel = match.Groups[1].Value;
            if (LogLevels.Contains(loggingLevel.Trim()))
            {
                match = Regex.Match(line, @"(\s+[^\s]*)",
                RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    time = match.Groups[1].Value;
                    
                }

                match = Regex.Match(line, @"([^\s]+)",
                RegexOptions.IgnoreCase);
                
                if (match.Success)
                {
                    date = match.Groups[1].Value;
                }
                
                match = Regex.Match(line, @"(\s:+[^\s]*)",
                RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    info = match.Groups[1].Value;
                }
                var csv = new StringBuilder();
                fileWriter.WriteLine($"{counter},{date}, {time}, {loggingLevel}, {info}");
                counter++;
            }           
        }

    }
}
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
                    fileWriter.Close();
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
            string date = "";
            string time = "";
            string loggingLevel = "";
            string info = "";
            var match = Regex.Match(line, @"([^\s]*\s\s)",
                RegexOptions.IgnoreCase);
                    loggingLevel = match.Groups[1].Value;
            if (LogLevels.Contains(loggingLevel.Trim()))
            {
            Console.WriteLine(loggingLevel);
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
                fileWriter.WriteLine($"{date}, {time}, {loggingLevel}, {info}");
            }
            
        }

    }
}
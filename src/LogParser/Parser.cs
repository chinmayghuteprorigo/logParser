using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace LogParser
{
    public class Parser
    {
        public String LogDirectory;
        public List<String> LogLevels = new List<String>();
        public String outputDirectory;

        string getOutputFile(string outputDirectory)
        {
            String outputFilePath = outputDirectory != null? outputDirectory : $"{LogDirectory}/output.csv";
            if (!outputFilePath.Contains(".csv"))
            {
                outputFilePath += ".csv";
            }
            return outputFilePath;
        } 
        public void getFilesData()
        {
            try
            {
                string outputFilePath = getOutputFile(outputDirectory);
                string[] dirs = Directory.GetFiles(@LogDirectory, "*.log");
                using(var fileWriter = new StreamWriter(outputFilePath))
                try{
                    int counter = 1;
                    fileWriter.WriteLine("Count, Date, Time, Logging Level, Info");
                    foreach (string dir in dirs)
                    {
                        string[] fileText = readFile(dir);
                        foreach(var line in fileText)
                        {
                            writeToCSV(fileWriter, line, ref counter, LogLevels);
                        }
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
        public string[] readFile(String dir)
        {
            Console.WriteLine("text");
            try
            {
                 string[] readText = File.ReadAllLines(dir);
                 return readText;
            }
            catch (Exception)
            {
                Console.WriteLine($"Error in reading file {dir}");
            }
            return null;
        }
        public void writeToCSV(StreamWriter fileWriter, String line, ref int counter, List<string> logLevels)
        {
            string date = "";
            string time = "";
            string loggingLevel = "";
            string info = "";
            var match = Regex.Match(line, @"([^\s]*\s\s)",
                RegexOptions.IgnoreCase);
            loggingLevel = match.Groups[1].Value;
            if (logLevels.Contains(loggingLevel.Trim()))
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
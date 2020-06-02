using System;

namespace LogParser
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args[0] == "--help" || args.Length < 3)
            {
                Console.WriteLine("Usage: logParser --log-dir <dir> --log-level <level> --csv <out>\n --log-dir   Directory to parse recursively for .log files\n    --csv       Out file-path (absolute/relative)");
            }
            bool isLogDirPresent = false;
            bool isLoggingLevelPresent = false;
            Parser parser = new Parser();
            for (int i = 0; i < args.Length - 1; i++) 
            {
                if (args[i] == "--log-dir")
                {
                    parser.LogDirectory = args[i+1];
                    i++;
                    isLogDirPresent = true;
                    continue;
                }
                if (args[i] == "--log-level")
                {
                    parser.LogLevels.Add(args[i+1]);
                    i++;
                    isLoggingLevelPresent = true;
                    continue;
                }
                if (args[i] == "--csv")
                {
                    parser.outputDirectory = args[i+1];
                    i++;
                    continue;
                }
            }
            if (isLogDirPresent && isLoggingLevelPresent)
            {
                parser.getFilesData();
            }
            else
            {
                Console.WriteLine("Please pass parameters correctly.");
            }
            
        }
    }
}

﻿using System;

namespace LogParser
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("helpText");
            }
            Parser parser = new Parser();
            for (int i = 0; i < args.Length - 1; i++) 
            {
                // Console.WriteLine(args[i] + args.Length);
                if (args[i] == "--log-dir")
                {
                    // Console.WriteLine(args[i++]);
                    parser.LogDirectory = args[i+1];
                    i++;
                    continue;
                }
                if (args[i] == "--log-level")
                {
                    parser.LogLevels.Add(args[i+1]);
                    i++;
                    continue;
                }
                if (args[i] == "--csv")
                {
                    parser.outputDirectory = args[i+1];
                    i++;
                    continue;
                }
            }
            parser.getFilesData();
            
        }
    }
}

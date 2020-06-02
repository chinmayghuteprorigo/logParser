# logParser
# This project helps in combining all log files in single csv in particular directory.
# This project takes following arguments - 
#   --log-dir - Where all log files are present
#   --log-level - <INFO | ERROR | DEBUG>which level info we want program to include in output csv. This parameter can be given multiple times
#   --csv - Output file (optional, if not given file is created in log directory)

#>dotnet run --log-dir D:\\dotNet\\c#\\2020_02\\2020_02 --log-level INFO --csv ../logs123
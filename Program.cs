using System;
using System.Collections.Generic;
using System.IO;

namespace chartMerger {
    class Program {
        static void Main(string[] args) {
            if(args.Length == 0) {
                Console.WriteLine("Usage: Drag and drop the .chart files you want to merge.");
                Console.WriteLine("It will output a file called \"chartMerger_output.chart\".");
                Console.Write("The .chart files must have a CHARTMERGER_START and CHARTMERGER_END events ");
                Console.Write("(not track events - global events!) ");
                Console.Write("so the program is able to determine which part of the .chart file ");
                Console.WriteLine("it should include in the final, merged .chart file.");
                Console.Write("The .chart files are read in alphabetical order, ");
                Console.WriteLine("so they can be ordered in a custom way.");
                Console.WriteLine("Press any key to exit.");
            } else {
                Array.Sort(args); //sorts arguments alphabetically
                List<Song> charts = new List<Song>();
                foreach(var file in args) {
                    if(File.Exists(file)) {
                        charts.Add(Reader.ReadChart(file));
                        Console.WriteLine("Finished reading file {0}",file);
                    } else {
                        Console.WriteLine("File {0} not found - skipping;",file);
                    }
                }
                Writer.WriteChart(SongMerger.Merge(charts));
                Console.WriteLine("Finished! Press any key to exit");
            }
            Console.ReadKey();
        }
    }
}

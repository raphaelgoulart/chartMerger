using System;
using System.Collections.Generic;
using System.IO;

namespace chartMerger {
    class Reader {
        public static Song ReadChart(string path) {
            var s = new Song();
            var file = new StreamReader(path);
            string line;
            while((line = file.ReadLine()) != null) {
                line = line.Trim();
                try {
                    if(line == "[Song]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            if (tmp[0].Trim() == "Name") {
                                s.name = tmp[1].Trim().Substring(1,tmp[1].Length-3);
                            }
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[SyncTrack]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            if (tmp[1].Trim().Split(' ')[0] != "A") {
                                s.sync.Add(CreateEvent(tmp));
                            }
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[Events]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            if(tmp[1].Trim() == "E \"CHARTMERGER_START\"") {
                                s.start = Convert.ToInt64(tmp[0].Trim());
                            } else if(tmp[1].Trim() == "E \"CHARTMERGER_END\"") {
                                s.end = Convert.ToInt64(tmp[0].Trim());
                            } else {
                                s.events.Add(CreateEvent(tmp));
                            }
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[EasySingle]") s.single[0] = ReadDiff(line,file);
                    if(line == "[MediumSingle]") s.single[1] = ReadDiff(line,file);
                    if(line == "[HardSingle]") s.single[2] = ReadDiff(line,file);
                    if(line == "[ExpertSingle]") s.single[3] = ReadDiff(line,file);
                    if(line == "[EasyDoubleGuitar]") s.doubleGuitar[0] = ReadDiff(line,file);
                    if(line == "[MediumDoubleGuitar]") s.doubleGuitar[1] = ReadDiff(line,file);
                    if(line == "[HardDoubleGuitar]") s.doubleGuitar[2] = ReadDiff(line,file);
                    if(line == "[ExpertDoubleGuitar]") s.doubleGuitar[3] = ReadDiff(line,file);
                    if(line == "[EasyDoubleBass]") s.doubleBass[0] = ReadDiff(line,file);
                    if(line == "[MediumDoubleBass]") s.doubleBass[1] = ReadDiff(line,file);
                    if(line == "[HardDoubleBass]") s.doubleBass[2] = ReadDiff(line,file);
                    if(line == "[ExpertDoubleBass]") s.doubleBass[3] = ReadDiff(line,file);
                    if(line == "[EasyEnhancedGuitar]") s.enhancedGuitar[0] = ReadDiff(line,file);
                    if(line == "[MediumEnhancedGuitar]") s.enhancedGuitar[1] = ReadDiff(line,file);
                    if(line == "[HardEnhancedGuitar]") s.enhancedGuitar[2] = ReadDiff(line,file);
                    if(line == "[ExpertEnhancedGuitar]") s.enhancedGuitar[3] = ReadDiff(line,file);
                    if(line == "[EasyCoopLead]") s.coopLead[0] = ReadDiff(line,file);
                    if(line == "[MediumCoopLead]") s.coopLead[1] = ReadDiff(line,file);
                    if(line == "[HardCoopLead]") s.coopLead[2] = ReadDiff(line,file);
                    if(line == "[ExpertCoopLead]") s.coopLead[3] = ReadDiff(line,file);
                    if(line == "[EasyCoopBass]") s.coopBass[0] = ReadDiff(line,file);
                    if(line == "[MediumCoopBass]") s.coopBass[1] = ReadDiff(line,file);
                    if(line == "[HardCoopBass]") s.coopBass[2] = ReadDiff(line,file);
                    if(line == "[ExpertCoopBass]") s.coopBass[3] = ReadDiff(line,file);
                    if(line == "[Easy10KeyGuitar]") s.tenKeyGuitar[0] = ReadDiff(line,file);
                    if(line == "[Medium10KeyGuitar]") s.tenKeyGuitar[1] = ReadDiff(line,file);
                    if(line == "[Hard10KeyGuitar]") s.tenKeyGuitar[2] = ReadDiff(line,file);
                    if(line == "[Expert10KeyGuitar]") s.tenKeyGuitar[3] = ReadDiff(line,file);
                    if(line == "[EasyDrums]") s.drums[0] = ReadDiff(line,file);
                    if(line == "[MediumDrums]") s.drums[1] = ReadDiff(line,file);
                    if(line == "[HardDrums]") s.drums[2] = ReadDiff(line,file);
                    if(line == "[ExpertDrums]") s.drums[3] = ReadDiff(line,file);
                    if(line == "[EasyDoubleDrums]") s.doubleDrums[0] = ReadDiff(line,file);
                    if(line == "[MediumDoubleDrums]") s.doubleDrums[1] = ReadDiff(line,file);
                    if(line == "[HardDoubleDrums]") s.doubleDrums[2] = ReadDiff(line,file);
                    if(line == "[ExpertDoubleDrums]") s.doubleDrums[3] = ReadDiff(line,file);
                    if(line == "[EasyVocals]") s.vocals[0] = ReadDiff(line,file);
                    if(line == "[MediumVocals]") s.vocals[1] = ReadDiff(line,file);
                    if(line == "[HardVocals]") s.vocals[2] = ReadDiff(line,file);
                    if(line == "[ExpertVocals]") s.vocals[3] = ReadDiff(line,file);
                    if(line == "[EasyKeyboard]") s.keyboard[0] = ReadDiff(line,file);
                    if(line == "[MediumKeyboard]") s.keyboard[1] = ReadDiff(line,file);
                    if(line == "[HardKeyboard]") s.keyboard[2] = ReadDiff(line,file);
                    if(line == "[ExpertKeyboard]") s.keyboard[3] = ReadDiff(line,file);
                } catch(Exception e) {
                    if(line != "}") Console.WriteLine("Error parsing line {0} - ignoring it",line);
                }
                
            }
            return s;
        }

        private static List<Event> ReadDiff(string line,StreamReader file) {
            List <Event> diff = new List<Event>();
            line = file.ReadLine();
            line = file.ReadLine();
            while(line != "}") {
                var tmp = line.Split('=');
                diff.Add(CreateEvent(tmp));
                line = file.ReadLine();
            }
            return diff;
        }

        private static Event CreateEvent(string[] tmp) {
            long tick = 0;
            tick = Convert.ToInt64(tmp[0].Trim());
            string data = tmp[1];
            if(tmp.Length > 2) {
                for(int i = 2; i < tmp.Length; i++) {
                    data += tmp[i];
                }
            }
            return new Event(tick,data.Trim());
        }
    }
}

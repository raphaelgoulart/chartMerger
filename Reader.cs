using System;
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
                    if(line == "[EasySingle]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.single[0].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[MediumSingle]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.single[1].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[HardSingle]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.single[2].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[ExpertSingle]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.single[3].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[EasyDoubleGuitar]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.doubleGuitar[0].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[MediumDoubleGuitar]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.doubleGuitar[1].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[HardDoubleGuitar]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.doubleGuitar[2].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[ExpertDoubleGuitar]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.doubleGuitar[3].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[EasyDoubleBass]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.doubleBass[0].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[MediumDoubleBass]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.doubleBass[1].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[HardDoubleBass]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.doubleBass[2].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[ExpertDoubleBass]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.doubleBass[3].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[EasyEnhancedGuitar]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.enhancedGuitar[0].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[MediumEnhancedGuitar]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.enhancedGuitar[1].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[HardEnhancedGuitar]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.enhancedGuitar[2].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[ExpertEnhancedGuitar]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.enhancedGuitar[3].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[EasyCoopLead]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.coopLead[0].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[MediumCoopLead]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.coopLead[1].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[HardCoopLead]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.coopLead[2].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[ExpertCoopLead]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.coopLead[3].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[EasyCoopBass]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.coopBass[0].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[MediumCoopBass]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.coopBass[1].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[HardCoopBass]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.coopBass[2].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[ExpertCoopBass]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.coopBass[3].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[Easy10KeyGuitar]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.tenKeyGuitar[0].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[Medium10KeyGuitar]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.tenKeyGuitar[1].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[Hard10KeyGuitar]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.tenKeyGuitar[2].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[Expert10KeyGuitar]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.tenKeyGuitar[3].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[EasyDrums]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.drums[0].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[MediumDrums]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.drums[1].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[HardDrums]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.drums[2].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[ExpertDrums]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.drums[3].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[EasyDoubleDrums]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.doubleDrums[0].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[MediumDoubleDrums]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.doubleDrums[1].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[HardDoubleDrums]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.doubleDrums[2].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[ExpertDoubleDrums]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.doubleDrums[3].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[EasyVocals]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.vocals[0].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[MediumVocals]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.vocals[1].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[HardVocals]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.vocals[2].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[ExpertVocals]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.vocals[3].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[EasyKeyboard]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.keyboard[0].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[MediumKeyboard]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.keyboard[1].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[HardKeyboard]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.keyboard[2].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                    if(line == "[ExpertKeyboard]") {
                        line = file.ReadLine();
                        line = file.ReadLine();
                        while(line != "}") {
                            var tmp = line.Split('=');
                            s.keyboard[3].Add(CreateEvent(tmp));
                            line = file.ReadLine();
                        }
                    }
                } catch(Exception e) {
                    if(line != "}") Console.WriteLine("Error parsing line {0} - ignoring it",line);
                }
                
            }
            return s;
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

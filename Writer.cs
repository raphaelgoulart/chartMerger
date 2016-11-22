using System;
using System.Collections.Generic;
using System.IO;

namespace chartMerger {
    class Writer {
        public static void WriteChart(Song s) {
            using(var output = new FileStream("chartMerger_output.chart",FileMode.Create,FileAccess.Write,FileShare.ReadWrite)) {
                using(var file = new StreamWriter(output)) {
                    file.WriteLine("[Song]");
                    file.WriteLine("{");
                    file.WriteLine("\tName = \"Made with chartMerger\"");
                    file.WriteLine("\tArtist = \"raphaelgoulart aka GoulartGH\"");
                    file.WriteLine("\tYear = \", " + DateTime.Now.Year.ToString() + "\"");
                    file.WriteLine("\tCharter = \"chartMerger\"");
                    file.WriteLine("\tOffset = 0");
                    file.WriteLine("\tResolution = 192");
                    file.WriteLine("\tPlayer2 = bass");
                    file.WriteLine("\tDifficulty = 0");
                    file.WriteLine("\tPreviewStart = 0.00");
                    file.WriteLine("\tPreviewEnd = 0.00");
                    file.WriteLine("\tGenre = \"rock\"");
                    file.WriteLine("\tMediaType = \"cd\"");
                    file.WriteLine("\tMusicStream = \"song.ogg\"");
                    file.WriteLine("\tGuitarStream = \"guitar.ogg\"");
                    file.WriteLine("\tBassStream = \"rhythm.ogg\"");
                    file.WriteLine("}");
                    file.WriteLine("[SyncTrack]");
                    file.WriteLine("{");
                    foreach(Event e in s.sync) {
                        file.WriteLine("\t" + e.tick + " = " + e.data);
                    }
                    file.WriteLine("}");
                    file.WriteLine("[Events]");
                    file.WriteLine("{");
                    foreach(Event e in s.events) {
                        file.WriteLine("\t" + e.tick + " = " + e.data);
                    }
                    file.WriteLine("}");
                    if(s.single[0].Count > 0) {
                        file.WriteLine("[EasySingle]");
                        file.WriteLine("{");
                        foreach(Event e in s.single[0]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.single[1].Count > 0) {
                        file.WriteLine("[MediumSingle]");
                        file.WriteLine("{");
                        foreach(Event e in s.single[1]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.single[2].Count > 0) {
                        file.WriteLine("[HardSingle]");
                        file.WriteLine("{");
                        foreach(Event e in s.single[2]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.single[3].Count > 0) {
                        file.WriteLine("[ExpertSingle]");
                        file.WriteLine("{");
                        foreach(Event e in s.single[3]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.doubleGuitar[0].Count > 0) {
                        file.WriteLine("[EasyDoubleGuitar]");
                        file.WriteLine("{");
                        foreach(Event e in s.doubleGuitar[0]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.doubleGuitar[1].Count > 0) {
                        file.WriteLine("[MediumDoubleGuitar]");
                        file.WriteLine("{");
                        foreach(Event e in s.doubleGuitar[1]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.doubleGuitar[2].Count > 0) {
                        file.WriteLine("[HardDoubleGuitar]");
                        file.WriteLine("{");
                        foreach(Event e in s.doubleGuitar[2]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.doubleGuitar[3].Count > 0) {
                        file.WriteLine("[ExpertDoubleGuitar]");
                        file.WriteLine("{");
                        foreach(Event e in s.doubleGuitar[3]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.doubleBass[0].Count > 0) {
                        file.WriteLine("[EasyDoubleBass]");
                        file.WriteLine("{");
                        foreach(Event e in s.doubleBass[0]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.doubleBass[1].Count > 0) {
                        file.WriteLine("[MediumDoubleBass]");
                        file.WriteLine("{");
                        foreach(Event e in s.doubleBass[1]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.doubleBass[2].Count > 0) {
                        file.WriteLine("[HardDoubleBass]");
                        file.WriteLine("{");
                        foreach(Event e in s.doubleBass[2]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.doubleBass[3].Count > 0) {
                        file.WriteLine("[ExpertDoubleBass]");
                        file.WriteLine("{");
                        foreach(Event e in s.doubleBass[3]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.enhancedGuitar[0].Count > 0) {
                        file.WriteLine("[EasyEnhancedGuitar]");
                        file.WriteLine("{");
                        foreach(Event e in s.enhancedGuitar[0]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.enhancedGuitar[1].Count > 0) {
                        file.WriteLine("[MediumEnhancedGuitar]");
                        file.WriteLine("{");
                        foreach(Event e in s.enhancedGuitar[1]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.enhancedGuitar[2].Count > 0) {
                        file.WriteLine("[HardEnhancedGuitar]");
                        file.WriteLine("{");
                        foreach(Event e in s.enhancedGuitar[2]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.enhancedGuitar[3].Count > 0) {
                        file.WriteLine("[ExpertEnhancedGuitar]");
                        file.WriteLine("{");
                        foreach(Event e in s.enhancedGuitar[3]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.coopLead[0].Count > 0) {
                        file.WriteLine("[EasyCoopLead]");
                        file.WriteLine("{");
                        foreach(Event e in s.coopLead[0]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.coopLead[1].Count > 0) {
                        file.WriteLine("[MediumCoopLead]");
                        file.WriteLine("{");
                        foreach(Event e in s.coopLead[1]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.coopLead[2].Count > 0) {
                        file.WriteLine("[HardCoopLead]");
                        file.WriteLine("{");
                        foreach(Event e in s.coopLead[2]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.coopLead[3].Count > 0) {
                        file.WriteLine("[ExpertCoopLead]");
                        file.WriteLine("{");
                        foreach(Event e in s.coopLead[3]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.coopBass[0].Count > 0) {
                        file.WriteLine("[EasyCoopBass]");
                        file.WriteLine("{");
                        foreach(Event e in s.coopBass[0]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.coopBass[1].Count > 0) {
                        file.WriteLine("[MediumCoopBass]");
                        file.WriteLine("{");
                        foreach(Event e in s.coopBass[1]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.coopBass[2].Count > 0) {
                        file.WriteLine("[HardCoopBass]");
                        file.WriteLine("{");
                        foreach(Event e in s.coopBass[2]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.coopBass[3].Count > 0) {
                        file.WriteLine("[ExpertCoopBass]");
                        file.WriteLine("{");
                        foreach(Event e in s.coopBass[3]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.tenKeyGuitar[0].Count > 0) {
                        file.WriteLine("[Easy10KeyGuitar]");
                        file.WriteLine("{");
                        foreach(Event e in s.tenKeyGuitar[0]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.tenKeyGuitar[1].Count > 0) {
                        file.WriteLine("[Medium10KeyGuitar]");
                        file.WriteLine("{");
                        foreach(Event e in s.tenKeyGuitar[1]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.tenKeyGuitar[2].Count > 0) {
                        file.WriteLine("[Hard10KeyGuitar]");
                        file.WriteLine("{");
                        foreach(Event e in s.tenKeyGuitar[2]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.tenKeyGuitar[3].Count > 0) {
                        file.WriteLine("[Expert10KeyGuitar]");
                        file.WriteLine("{");
                        foreach(Event e in s.tenKeyGuitar[3]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.drums[0].Count > 0) {
                        file.WriteLine("[EasyDrums]");
                        file.WriteLine("{");
                        foreach(Event e in s.drums[0]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.drums[1].Count > 0) {
                        file.WriteLine("[MediumDrums]");
                        file.WriteLine("{");
                        foreach(Event e in s.drums[1]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.drums[2].Count > 0) {
                        file.WriteLine("[HardDrums]");
                        file.WriteLine("{");
                        foreach(Event e in s.drums[2]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.drums[3].Count > 0) {
                        file.WriteLine("[ExpertDrums]");
                        file.WriteLine("{");
                        foreach(Event e in s.drums[3]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.doubleDrums[0].Count > 0) {
                        file.WriteLine("[EasyDoubleDrums]");
                        file.WriteLine("{");
                        foreach(Event e in s.doubleDrums[0]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.doubleDrums[1].Count > 0) {
                        file.WriteLine("[MediumDoubleDrums]");
                        file.WriteLine("{");
                        foreach(Event e in s.doubleDrums[1]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.doubleDrums[2].Count > 0) {
                        file.WriteLine("[HardDoubleDrums]");
                        file.WriteLine("{");
                        foreach(Event e in s.doubleDrums[2]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.doubleDrums[3].Count > 0) {
                        file.WriteLine("[ExpertDoubleDrums]");
                        file.WriteLine("{");
                        foreach(Event e in s.doubleDrums[3]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.vocals[0].Count > 0) {
                        file.WriteLine("[EasyVocals]");
                        file.WriteLine("{");
                        foreach(Event e in s.vocals[0]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.vocals[1].Count > 0) {
                        file.WriteLine("[MediumVocals]");
                        file.WriteLine("{");
                        foreach(Event e in s.vocals[1]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.vocals[2].Count > 0) {
                        file.WriteLine("[HardVocals]");
                        file.WriteLine("{");
                        foreach(Event e in s.vocals[2]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.vocals[3].Count > 0) {
                        file.WriteLine("[ExpertVocals]");
                        file.WriteLine("{");
                        foreach(Event e in s.vocals[3]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.keyboard[0].Count > 0) {
                        file.WriteLine("[EasyKeyboard]");
                        file.WriteLine("{");
                        foreach(Event e in s.keyboard[0]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.keyboard[1].Count > 0) {
                        file.WriteLine("[MediumKeyboard]");
                        file.WriteLine("{");
                        foreach(Event e in s.keyboard[1]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.keyboard[2].Count > 0) {
                        file.WriteLine("[HardKeyboard]");
                        file.WriteLine("{");
                        foreach(Event e in s.keyboard[2]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                    if(s.keyboard[3].Count > 0) {
                        file.WriteLine("[ExpertKeyboard]");
                        file.WriteLine("{");
                        foreach(Event e in s.keyboard[3]) {
                            file.WriteLine("\t" + e.tick + " = " + e.data);
                        }
                        file.WriteLine("}");
                    }
                }
            }
        }
    }
}
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
                    WriteDiff(file,s.single[0],"[EasySingle]");
                    WriteDiff(file,s.single[1],"[MediumSingle]");
                    WriteDiff(file,s.single[2],"[HardSingle]");
                    WriteDiff(file,s.single[3],"[ExpertSingle]");
                    WriteDiff(file,s.doubleGuitar[0],"[EasyDoubleGuitar]");
                    WriteDiff(file,s.doubleGuitar[1],"[MediumDoubleGuitar]");
                    WriteDiff(file,s.doubleGuitar[2],"[HardDoubleGuitar]");
                    WriteDiff(file,s.doubleGuitar[3],"[ExpertDoubleGuitar]");
                    WriteDiff(file,s.doubleBass[0],"[EasyDoubleBass]");
                    WriteDiff(file,s.doubleBass[1],"[MediumDoubleBass]");
                    WriteDiff(file,s.doubleBass[2],"[HardDoubleBass]");
                    WriteDiff(file,s.doubleBass[3],"[ExpertDoubleBass]");
                    WriteDiff(file,s.enhancedGuitar[0],"[EasyEnhancedGuitar]");
                    WriteDiff(file,s.enhancedGuitar[1],"[MediumEnhancedGuitar]");
                    WriteDiff(file,s.enhancedGuitar[2],"[HardEnhancedGuitar]");
                    WriteDiff(file,s.enhancedGuitar[3],"[ExpertEnhancedGuitar]");
                    WriteDiff(file,s.coopLead[0],"[EasyCoopLead]");
                    WriteDiff(file,s.coopLead[1],"[MediumCoopLead]");
                    WriteDiff(file,s.coopLead[2],"[HardCoopLead]");
                    WriteDiff(file,s.coopLead[3],"[ExpertCoopLead]");
                    WriteDiff(file,s.coopBass[0],"[EasyCoopBass]");
                    WriteDiff(file,s.coopBass[1],"[MediumCoopBass]");
                    WriteDiff(file,s.coopBass[2],"[HardCoopBass]");
                    WriteDiff(file,s.coopBass[3],"[ExpertCoopBass]");
                    WriteDiff(file,s.tenKeyGuitar[0],"[Easy10KeyGuitar]");
                    WriteDiff(file,s.tenKeyGuitar[1],"[Medium10KeyGuitar]");
                    WriteDiff(file,s.tenKeyGuitar[2],"[Hard10KeyGuitar]");
                    WriteDiff(file,s.tenKeyGuitar[3],"[Expert10KeyGuitar]");
                    WriteDiff(file,s.drums[0],"[EasyDrums]");
                    WriteDiff(file,s.drums[1],"[MediumDrums]");
                    WriteDiff(file,s.drums[2],"[HardDrums]");
                    WriteDiff(file,s.drums[3],"[ExpertDrums]");
                    WriteDiff(file,s.doubleDrums[0],"[EasyDoubleDrums]");
                    WriteDiff(file,s.doubleDrums[1],"[MediumDoubleDrums]");
                    WriteDiff(file,s.doubleDrums[2],"[HardDoubleDrums]");
                    WriteDiff(file,s.doubleDrums[3],"[ExpertDoubleDrums]");
                    WriteDiff(file,s.vocals[0],"[EasyVocals]");
                    WriteDiff(file,s.vocals[1],"[MediumVocals]");
                    WriteDiff(file,s.vocals[2],"[HardVocals]");
                    WriteDiff(file,s.vocals[3],"[ExpertVocals]");
                    WriteDiff(file,s.keyboard[0],"[EasyKeyboard]");
                    WriteDiff(file,s.keyboard[1],"[MediumKeyboard]");
                    WriteDiff(file,s.keyboard[2],"[HardKeyboard]");
                    WriteDiff(file,s.keyboard[3],"[ExpertKeyboard]");
                }
            }
        }

        private static void WriteDiff(StreamWriter file,List<Event> diff,string diffName) {
            if(diff.Count > 0) {
                file.WriteLine(diffName);
                file.WriteLine("{");
                foreach(Event e in diff) {
                    file.WriteLine("\t" + e.tick + " = " + e.data);
                }
                file.WriteLine("}");
            }
        }
    }
}

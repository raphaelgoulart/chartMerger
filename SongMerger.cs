using System;
using System.Collections.Generic;

namespace chartMerger {
    class SongMerger {
        public static Song Merge(List<Song> charts) {
            Song song = new Song();
            long finalLength = 0;
            foreach(Song s in charts) {
                song = Add(song,s,finalLength);
                finalLength += (s.end - s.start);
            }
            return song;
        }

        private static Song Add(Song song,Song s,long finalLength) {
            song.sync = IncludeSync(song.sync,s.sync,s.start,s.end,finalLength);
            song.events = IncludeEvents(song.events,s.events,s.start,s.end,finalLength,s.name);
            song.single = Include(song.single,s.single,s.start,s.end,finalLength);
            song.doubleGuitar = Include(song.doubleGuitar,s.doubleGuitar,s.start,s.end,finalLength);
            song.doubleBass = Include(song.doubleBass,s.doubleBass,s.start,s.end,finalLength);
            song.enhancedGuitar = Include(song.enhancedGuitar,s.enhancedGuitar,s.start,s.end,finalLength);
            song.coopLead = Include(song.coopLead,s.coopLead,s.start,s.end,finalLength);
            song.coopBass = Include(song.coopBass,s.coopBass,s.start,s.end,finalLength);
            song.tenKeyGuitar = Include(song.tenKeyGuitar,s.tenKeyGuitar,s.start,s.end,finalLength);
            song.drums = Include(song.drums,s.drums,s.start,s.end,finalLength);
            song.doubleDrums = Include(song.doubleDrums,s.doubleDrums,s.start,s.end,finalLength);
            song.vocals = Include(song.vocals,s.vocals,s.start,s.end,finalLength);
            song.keyboard = Include(song.keyboard,s.keyboard,s.start,s.end,finalLength);
            return song;
        }

        private static List<Event> IncludeSync(List<Event> song,List<Event> s,long start,long end,long finalLength) {
            if(!HasSyncAtStart(s,start,"TS")) {
                song.Add(new Event(finalLength,GetLatestSync(s,start,"TS")));
            }
            if(!HasSyncAtStart(s,start,"B")) {
                song.Add(new Event(finalLength,GetLatestSync(s,start,"B")));
            }
            foreach(Event e in s) {
                if(e.tick >= end) {
                    break;
                }
                if(e.tick >= start && e.tick < end) {
                    e.tick = e.tick - start + finalLength;
                    song.Add(e);
                }
            }
            return song;
        }

        private static string GetLatestSync(List<Event> s,long start,string v) {
            string sync = "";
            switch(v) {
                case "TS": sync = "TS 4"; break;
                case "B": sync = "B 120000"; break;
            }
            foreach(Event e in s) {
                if(e.tick > start) break;
                if(e.data.Contains(v)) {
                    sync = v + " " + e.data.Split(' ')[1];
                }
            }
            return sync;
        }

        private static bool HasSyncAtStart(List<Event> s,long start,string v) {
            foreach(Event e in s) {
                if(e.tick == start && e.data.Contains(v)) return true;
                if(e.tick > start) return false;
            }
            return false;
        }

        private static List<Event> IncludeEvents(List<Event> song,List<Event> s,long start,long end,long finalLength,string name) {
            if(!HasSectionAtStart(s,start)) {
                song.Add(new Event(finalLength,GetLatestSectionName(s,start,name)));
            }
            foreach(Event e in s) {
                if(e.tick >= end) {
                    break;
                }
                if(e.tick >= start && e.tick < end) {
                    if(e.data.Contains("E \"section ")) {
                        e.data = FixSectionName(e.data,name);
                    }
                    e.tick = e.tick - start + finalLength;
                    song.Add(e);
                }
            }
            return song;
        }

        private static string GetLatestSectionName(List<Event> sections,long start,string name) {
            string section = "E \"section " + name + "\"";
            foreach(Event e in sections) {
                if(e.tick > start) break;
                if(e.data.Contains("E \"section ")) {
                    section = FixSectionName(e.data,name);
                }
            }
            return section;
        }

        private static string FixSectionName(string data,string name) {
            var tmp = data.Split(' ');
            var section = "E \"section " + name + " ";
            for(int i = 2; i < tmp.Length; i++) {
                section += tmp[i];
            }
            return section;
        }

        private static bool HasSectionAtStart(List<Event> sections,long start) {
            foreach(Event e in sections) {
                if(e.tick == start&&e.data.Contains("E \"section ")) return true;
                if(e.tick > start) return false;
            }
            return false;
        }

        private static List<Event>[] Include(List<Event>[] song,List<Event>[] s,long start,long end,long finalLength) {
            for(int i=0; i<4; i++) {
                song[i] = Include(song[i],s[i],start,end,finalLength);
            }
            return song;
        }

        private static List<Event> Include(List<Event> song,List<Event> s,long start,long end,long finalLength) {
            foreach(Event note in s) {
                if(note.tick >= end) {
                    break;
                }
                if(note.tick >= start && note.tick < end) {
                    note.data = FixSustain(note.data,note.tick,end);
                    note.tick = note.tick - start + finalLength;
                    song.Add(note);
                }
            }
            return song;
        }

        private static string FixSustain(string data,long tick,long end) {
            var tmp = data.Split(' ');
            if(tmp.Length < 3) return data;
            long sus = Convert.ToInt64(tmp[2]);
            if(tick + sus > end) {
                sus = sus - (tick + sus - end);
            }
            return tmp[0] + " " + tmp[1] + " " + sus.ToString();
        }
    }
}

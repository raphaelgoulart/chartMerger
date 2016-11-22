using System.Collections.Generic;

namespace chartMerger {
    class Song {
        public string name;
        public List<Event> sync = new List<Event>();
        public List<Event> events = new List<Event>();
        public long start, end;
        public List<Event>[] single = new List<Event>[4];
        public List<Event>[] doubleGuitar = new List<Event>[4];
        public List<Event>[] doubleBass = new List<Event>[4];
        public List<Event>[] enhancedGuitar = new List<Event>[4];
        public List<Event>[] coopLead = new List<Event>[4];
        public List<Event>[] coopBass = new List<Event>[4];
        public List<Event>[] tenKeyGuitar = new List<Event>[4];
        public List<Event>[] drums = new List<Event>[4];
        public List<Event>[] doubleDrums = new List<Event>[4];
        public List<Event>[] vocals = new List<Event>[4];
        public List<Event>[] keyboard = new List<Event>[4];

        public Song() {
            single = Initialize(single);
            doubleGuitar = Initialize(doubleGuitar);
            doubleBass = Initialize(doubleBass);
            enhancedGuitar = Initialize(enhancedGuitar);
            coopLead = Initialize(coopLead);
            coopBass = Initialize(coopBass);
            tenKeyGuitar = Initialize(tenKeyGuitar);
            drums = Initialize(drums);
            doubleDrums = Initialize(doubleDrums);
            vocals = Initialize(vocals);
            keyboard = Initialize(keyboard);
        }

        private List<Event>[] Initialize(List<Event>[] array) {
            for (int i = 0; i < 4; i++) {
                array[i] = new List<Event>();
            }
            return array;
        }
    }
}

namespace chartMerger {
    class Event {
        public long tick;
        public string data;

        public Event(long tick, string data) {
            this.tick = tick;
            this.data = data;
        }
    }
}
namespace ParagonPingSystem {

    public class PingTree {

        public string Name { get; set; }

        public string Phrase { get; set; }

        public PingTree[] Pings { get; set; }

        public string[] Texts => new[] {Pings[0].Name, Pings[1].Name, Pings[2].Name, Pings[3].Name};
    }
}
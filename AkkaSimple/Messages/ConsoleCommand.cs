namespace AkkaSimple.Messages {
    public class ConsoleCommand {
        public string Text { get; set; }

        public ConsoleCommand(string text) {
            Text = text;
        }
    }
}
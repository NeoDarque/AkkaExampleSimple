using System;
using Akka.Actor;
using AkkaSimple.Messages;

namespace AkkaSimple.Actors {
    public class ConsoleOutputActor : ReceiveActor {

        public ConsoleOutputActor() {
            Receive<ConsoleCommand>(cmd => {
                if(String.IsNullOrWhiteSpace(cmd.Text))
                    throw new Exception("no input!");
                Console.WriteLine("\nConsoleOutputActor received text: {0}\n", cmd.Text);
            });
        }

        protected override void PreRestart(Exception reason, object message) {
            Console.WriteLine("Restarting ConsoleOutputActor");
            base.PreRestart(reason, message);
        }
    }
}
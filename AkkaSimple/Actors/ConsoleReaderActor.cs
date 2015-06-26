using System;
using Akka.Actor;
using AkkaSimple.Messages;

namespace AkkaSimple.Actors {
    public class ConsoleReaderActor : ReceiveActor {

        private ActorSelection _output;

        protected override void PreStart() {
            _output = Context.System.ActorSelection("/user/output");
        }

        public ConsoleReaderActor() {
            Receive<StartReadingInput>(cmd => {
                Console.Write("ConsoleReaderActor is awaiting input: ");
                var input = Console.ReadLine();
                _output.Tell(new ConsoleCommand(input));
                Self.Tell(new StartReadingInput());
            });
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka;
using Akka.Actor;
using AkkaSimple.Actors;
using AkkaSimple.Messages;

namespace AkkaSimple {
    class Program {
        static void Main(string[] args) {
            using(var system = ActorSystem.Create("MySystem")) {
                var reader = system.ActorOf<ConsoleReaderActor>("reader");
                var output = system.ActorOf<ConsoleOutputActor>("output");

                reader.Tell(new StartReadingInput());

                system.AwaitTermination();
            }
        }
    }
}

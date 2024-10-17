using System;
using System.Collections.Generic;
using System.Linq;

namespace Ass2 {
    public class Trace {
        private Command[] commands;

        public void add(Command step) {
            commands.Append(step);
        }

        public int getLength() {
            return commands.Length;
        }

        public int getMaxDepth() {
            return Depth(commands);
        }

        private static int Depth(Command[] cs) {
            int  acc        = 0;
            
            if (cs == Array.Empty<Command>()) return 0;
            foreach (var step in cs) {
                if (step is Repeat) {
                    Repeat c         = step as Repeat;
                    int    d         = Depth(c.children);
                    if (d > acc) acc = d;
                } 
            }

            return acc;
        }

        public int getRepeats() {
            int acc = 0;
            foreach (var step in commandsToList(commands)) {
                if (step is Repeat) acc++;
            }

            return acc;
        }

        private static System.Collections.IEnumerable commandsToList(Command[] cs) {
            foreach (var step in cs) {
                yield return step;
                if (step is Repeat) {
                    Repeat c = step as Repeat;
                    foreach (var substep in commandsToList(c.children)) {
                        yield return substep;
                    }
                }
            }
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Ass2;

public class Trace {
    private List<Command> _commands = new List<Command>();

    public Trace() { }

    public Trace(List<Command> commands) {
        _commands = commands;
    }

    public  void          add(Command step) => _commands.Add(step);

    public int getLength() => _commands.Count;

    public int getMaxDepth() => depth(_commands);

    private static int depth(IList<Command> cs) {
        int acc = 0;

        if (cs == new List<Command>()) return 0;
        foreach (var step in cs) {
            if (step is Repeat repeat) {
                int d            = depth(repeat.cg.children);
                if (d > acc) acc = d;
            }
        }

        return acc;
    }

    public int getRepeats() => commandsToList(_commands).OfType<Repeat>().Count();

    private static IEnumerable commandsToList(IList<Command> cs) {
        foreach (var step in cs) {
            yield return step;
            if (step is Repeat repeat) {
                foreach (var substep in commandsToList(repeat.cg.children)) {
                    yield return substep;
                }
            }
        }
    }
}
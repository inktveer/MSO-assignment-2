using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Ass2;

public class Trace {
    private ImmutableList<Command> commands;

    public void add(Command step) => commands.Add(step);

    public int getLength() => commands.Count;

    public int getMaxDepth() => depth(commands);

    private static int depth(ImmutableList<Command> cs) {
        int acc = 0;

        if (cs == new ImmutableList<Command>()) return 0;
        foreach (var step in cs) {
            if (step is Repeat repeat) {
                int d            = depth(repeat.children);
                if (d > acc) acc = d;
            }
        }

        return acc;
    }

    public int getRepeats() => commandsToList(commands).OfType<Repeat>().Count();

    private static IEnumerable commandsToList(List<Command> cs) {
        foreach (var step in cs) {
            yield return step;
            if (step is Repeat repeat) {
                foreach (var substep in commandsToList(repeat.children)) {
                    yield return substep;
                }
            }
        }
    }
}
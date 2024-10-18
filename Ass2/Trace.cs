using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Ass2;

public class Trace : IEnumerable {
    private List<Command> _commands = [];

    public Trace() { }

    public Trace(List<Command> commands) {
        _commands = commands;
    }

    public void Add(Command step) => _commands.Add(step);

    public int GetLength() => _commands.Count;

    public int GetMaxDepth() => depth(_commands);
    
    public int GetRepeats() => commandsToList(_commands).OfType<Repeat>().Count();

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }

    public TraceEnumerator GetEnumerator() {
        return new TraceEnumerator(_commands);
    }

    private static int depth(IList<Command> cs) {
        int acc = 0;

        if (cs == new List<Command>()) return 0;
        foreach (var step in cs) {
            if (step is Repeat repeat) {
                int d            = depth(repeat.Children);
                if (d > acc) acc = d;
            }
        }

        return acc;
    }

    private static IEnumerable commandsToList(IList<Command> cs) {
        foreach (var step in cs) {
            yield return step;
            if (step is Repeat repeat) {
                foreach (var substep in commandsToList(repeat.Children)) {
                    yield return substep;
                }
            }
        }
    }
}

public class TraceEnumerator(IList<Command> commands) : IEnumerator {
    private int pos = -1;

    public bool MoveNext() {
        return (pos < commands.Count);
    }

    public void Reset() {
        pos = -1;
    }
    
    object IEnumerator.Current => Current;

    public Command Current {
        get {
            try {
                return commands[pos];
            }
            catch (IndexOutOfRangeException) {
                throw new InvalidOperationException();
            }
        }
    }
}
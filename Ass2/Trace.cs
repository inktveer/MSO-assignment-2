using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Backend;

public class Trace : IEnumerable {
    private List<Command> _commands = [];

    public Trace() { }

    public Trace(List<Command> commands) => _commands = commands;

    public void Add(Command step) => _commands.Add(step);

    public int GetLength() => _commands.Count;

    public int GetMaxDepth() => Depth(_commands);
    
    public int GetRepeats() => CommandsToList(_commands).OfType<Repeat>().Count();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public TraceEnumerator GetEnumerator() => new(_commands);

    private static int Depth(IList<Command> cs) {
        int acc = 0;

        if (cs == new List<Command>()) return 0;
        foreach (var step in cs) {
            if (step is Repeat repeat) {
                int d            = Depth(repeat.Children);
                if (d > acc) acc = d;
            }
        }

        return acc;
    }

    // This method is an implementation of IEnumerable, to see how this works and if this works. 
    private static IEnumerable CommandsToList(IList<Command> cs) {
        foreach (var step in cs) {
            yield return step;
            if (step is Repeat repeat) {
                foreach (var substep in CommandsToList(repeat.Children)) {
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
    
    // This implementation of the IEnumerator inheriting class was made in accordance with the example on 
    // https://learn.microsoft.com/en-us/dotnet/api/system.collections.ienumerable?view=net-8.0
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
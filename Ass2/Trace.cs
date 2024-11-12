using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Backend;

public class Trace : IEnumerable {
    public List<(int,int)> visited = [];

    public IEnumerator GetEnumerator() => visited.GetEnumerator();
    public void add((int,int) point) => visited.Add(point);
}


/*
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
*/
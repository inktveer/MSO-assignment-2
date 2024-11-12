using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Backend;

public class Sequence(List<Command> commands): IEnumerable<Command> {
    public readonly List<Command>        commands = commands;
    public          int                  length                         => commands.Count;
    public          int                  maxDepth                       => Depth(commands);
    public          int                  amountOfRepeats                => CommandsToList(commands).OfType<Repeat>().Count();
    public static   Sequence             Create(List<Command> commands) => new(commands);
    public          void                 Add(Command          step)     => commands.Add(step);
    public          IEnumerator<Command> GetEnumerator()                => commands.GetEnumerator();

    public void execute(Avatar avatar, Grid grid) {
        foreach (var c in commands) {
            c.execute(avatar, grid);
        }
    }

    private static int Depth(IList<Command> cs) {
        int acc = 0;

        if (Equals(cs, (List<Command>) [])) return 0;
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

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
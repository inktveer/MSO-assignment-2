using System.Collections.Immutable;
using System.Data;
using System.Linq;

namespace Backend;

public interface Command {
    public void   execute(Avatar avatar, Grid grid, Trace trace);
    public string ToString();
}

public class Repeat(int iterations, ImmutableList<Command> children): Command {
    public readonly ImmutableList<Command> Children = children;

    public void execute(Avatar avatar, Grid grid, Trace trace) {
        for (var i = 0; i < iterations; i++) {
            foreach (var c in Children) {
                c.execute(avatar, grid, trace);
            }
        }
    }

    public static Repeat Create(int iterations, ImmutableList<Command> children) => new(iterations, children);

    public override string ToString() {
        string subcommands = "";
        foreach (var child in children) {
            subcommands += "\n    " + child.ToString();
        }

        return "Repeat " + iterations.ToString() + " times" + subcommands;
    }
}

public class RepeatUntil(Predicate predicate, ImmutableList<Command> children): Command {
    public void execute(Avatar avatar, Grid grid, Trace trace) {
        while (!predicate.evaluate(avatar, grid))
            foreach (var command in children)
                command.execute(avatar, grid, trace);
    }

    public RepeatUntil Create(Predicate predicate, ImmutableList<Command> children) => new(predicate, children);

    public override string ToString() {
        string subcommands = "";
        foreach (var child in children) {
            subcommands += "\n    " + child.ToString();
        }

        return "RepeatUntil " + predicate.ToString() + subcommands;
    }
}

public class Move(int steps): Command {
    public void execute(Avatar avatar, Grid _, Trace trace) {
        avatar.Move(steps);
        trace.add(avatar.position);
    }

    public static Move Create(int steps) => new(steps);

    public override string ToString() {
        return "Move " + steps.ToString();
    }
}

public class Turn(Lateral lateral): Command {
    public void execute(Avatar avatar, Grid _, Trace trace) => avatar.Turn(lateral);

    public static Turn Create(Lateral lateral) => new(lateral);

    public override string ToString() {
        return "Turn " + lateral.ToString().ToLower();
    }
}
using System.Collections.Immutable;
using System.Data;

namespace Backend;

public interface Command {
    public abstract void execute(Avatar avatar, Grid grid);
}

public class Repeat(int iterations, ImmutableList<Command> children): Command {
    public readonly ImmutableList<Command> Children = children;

    public void execute(Avatar avatar, Grid grid) {
        for (var i = 0; i < iterations; i++) {
            foreach (var c in Children) {
                c.execute(avatar, grid);
            }
        }
    }

    public static Repeat Create(int iterations, ImmutableList<Command> children) => new(iterations, children);
}

public class RepeatUntil(Predicate predicate, ImmutableList<Command> children): Command {
    public void execute(Avatar avatar, Grid grid) {
        while (!predicate.evaluate(avatar, grid))
            foreach (var command in children)
                command.execute(avatar, grid);
    }

    public RepeatUntil Create(Predicate predicate, ImmutableList<Command> children) => new RepeatUntil(predicate, children);
}

public class Move(int steps): Command {
    public void execute(Avatar avatar, Grid _) => avatar.Move(steps);

    public static Move Create(int steps) => new(steps);
}

public class Turn(Lateral lateral): Command {
    public void execute(Avatar avatar, Grid _) => avatar.Turn(lateral);

    public static Turn Create(Lateral lateral) => new(lateral);
}
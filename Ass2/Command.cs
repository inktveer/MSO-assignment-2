using System.Collections.Immutable;

namespace Ass2;

public abstract class Command {
    public abstract void execute(Avatar avatar);
}

public class Repeat(int iterations, ImmutableList<Command> children) : Command {
    public readonly ImmutableList<Command> Children = children;

    public override void execute(Avatar avatar) {
        for (var i = 0; i < iterations; i++) {
            foreach (var c in Children) {
                c.execute(avatar);
            }
        }
    }

    public static Repeat Create(int iterations, ImmutableList<Command> children) {
        return new Repeat(iterations, children);
    }
}

public class Move(int steps) : Command {
    public override void execute(Avatar avatar) {
        avatar.Move(steps);
    }

    public static Move Create(int steps) {
        return new Move(steps);
    }
}

public class Turn(Lateral lateral) : Command {
    public override void execute(Avatar avatar) {
        avatar.Turn(lateral);
    }

    public static Turn Create(Lateral lateral) {
        return new Turn(lateral);
    }
}
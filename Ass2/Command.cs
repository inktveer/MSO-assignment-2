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

    public static Repeat CreateRepeat(int iterations, ImmutableList<Command> children) => new(iterations, children);
}

public class Move(int steps) : Command {
    public override void execute(Avatar avatar) {
        avatar.Move(steps);
    }

    public static Move CreateMove(int steps) => new(steps);
}

public class Turn(Lateral lateral) : Command {
    public override void execute(Avatar avatar) {
        avatar.Turn(lateral);
    }

    public static Turn CreateTurn(Lateral lateral) => new(lateral);
}
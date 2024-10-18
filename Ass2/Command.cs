using System.Collections.Immutable;

namespace Ass2;

public abstract class Command {
    public abstract void execute(Avatar avatar);
}

public class Repeat(int iterations, CommandGroup commandGroup): Command {
    public readonly CommandGroup CommandGroup = commandGroup;

    public override void execute(Avatar avatar) {
        for (var i = 0; i < iterations; i++) {
            CommandGroup.execute(avatar);
        }
    }
}

public class Move(int steps): Command {
    public override void execute(Avatar avatar) {
        avatar.Move(steps);
    }
}

public class Turn(Lateral lateral): Command {
    public override void execute(Avatar avatar) {
        avatar.Turn(lateral);
    }
}

public class CommandGroup(ImmutableList<Command> children) : Command {
    public readonly ImmutableList<Command> children = children;

    public override void execute(Avatar avatar) {
        foreach (var c in children) {
            c.execute(avatar);
        }
    }
}
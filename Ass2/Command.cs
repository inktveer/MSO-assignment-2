using System.Collections.Immutable;

namespace Ass2;

public abstract class Command {
    public abstract void execute(Avatar avatar);
}

public class Repeat( int iterations, CommandGroup command_group): Command {
    public readonly CommandGroup cg = command_group;

    public override void execute(Avatar avatar) {
        for (var i = 0; i < iterations; i++) {
            cg.execute(avatar);
        }
    }
}

public class CommandGroup(ImmutableList<Command> children): Command {
    public readonly ImmutableList<Command> children = children;

    public override void execute(Avatar avatar) {
        foreach (var c in children) {
            c.execute(avatar);
        }
    }
}
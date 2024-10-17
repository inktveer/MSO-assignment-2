using System.Collections.Generic;
using System.Collections.Immutable;

namespace Ass2;

public abstract class Command {
    public abstract void execute(Avatar avatar);
}

public class Repeat : Command {
    public ImmutableList<Command> children;

    public override void execute(Avatar avatar) {
        foreach (var c in children) {
            c.execute(avatar);
        }
    }
}
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

    public class Move(int steps) : Command {
        public override void execute(Avatar avatar) {
            avatar.Move(steps);
        }
    }

    public class Turn(Lateral lateral) : Command {
        public override void execute(Avatar avatar) {
            avatar.Turn(lateral);
        }
    }
    
}
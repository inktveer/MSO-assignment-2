using System.Collections.Generic;

namespace Backend;

public abstract class Sequence(Trace commands) {
    public Trace Commands = commands;

    public void Load(Avatar avatar, Grid grid) {
        foreach (var c in Commands) {
            c.execute(avatar, grid);
        }
    }
}

public class BasicSequence(Trace commands) : Sequence(commands) {
    public static BasicSequence Create(List<Command> list) {
        return new BasicSequence(new Trace(list));
    }
}

public class MediumSequence(Trace commands) : Sequence(commands) {
    public static MediumSequence Create(List<Command> list) {
        return new MediumSequence(new Trace(list));
    }
}

public class AdvancedSequence(Trace commands) : Sequence(commands) {
    public static AdvancedSequence Create(List<Command> list) {
        return new AdvancedSequence(new Trace(list));
    }
}

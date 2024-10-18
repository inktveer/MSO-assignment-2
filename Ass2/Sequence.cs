using System.Collections.Generic;
using System.Collections.Immutable;

namespace Ass2;

public abstract class Sequence(Trace commands) {
    public Trace Commands = commands;
}

public class BasicSequence(Trace commands) : Sequence(commands) {
    public static BasicSequence CreateSequence(List<Command> list) {
        return new BasicSequence(new Trace(list));
    }
}

public class MediumSequence(Trace commands) : Sequence(commands) {
    public static MediumSequence CreateSequence(List<Command> list) {
        return new MediumSequence(new Trace(list));
    }
}

public class AdvancedSequence(Trace commands) : Sequence(commands) {
    public static AdvancedSequence CreateSequence(List<Command> list) {
        return new AdvancedSequence(new Trace(list));
    }
}

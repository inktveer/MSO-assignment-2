namespace Ass2;

public abstract class Sequence(Trace commands) {
    public Trace Commands = commands;
}

public class BasicSequence(Trace commands) : Sequence(commands);
public class MediumSequence(Trace commands) : Sequence(commands);
public class AdvancedSequence(Trace commands) : Sequence(commands);
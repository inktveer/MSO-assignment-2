using System.Collections.Generic;

namespace Backend;

public class Sequence(List<Command> commands) {
    public List<Command> Commands = commands;

    public void Load(Avatar avatar, Grid grid) {
        foreach (var c in Commands) {
            c.execute(avatar, grid);
        }
    }

    public static Sequence Create(List<Command> commands) => new Sequence(commands);
}
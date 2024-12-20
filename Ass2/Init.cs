using System.Collections.Generic;

namespace Backend;

public class Init {
    // This class holds the different microprograms, instances of the sequence abstract class. This is called 
    // when the program starts to load in all the microprograms so the user can call them. 

    private List<Sequence> microPrograms = [];

    public Init() {
        microPrograms.Add(Sequence.Create(Square));
        microPrograms.Add(Sequence.Create(Random));
    }

    public void Load(Avatar avatar, Grid grid, Trace trace, int index) => microPrograms[index].execute(avatar, grid, trace);

    private List<Command> Square = [
        Repeat.Create(4, [
            Move.Create(10),
            Turn.Create(Lateral.Right),
        ]),
    ];

    private List<Command> Random = [
        Move.Create(5),
        Turn.Create(Lateral.Left),
        Turn.Create(Lateral.Left),
        Move.Create(3),
        Turn.Create(Lateral.Right),
        Repeat.Create(3, [
            Move.Create(1),
            Turn.Create(Lateral.Right),
            Repeat.Create(5, [
                Move.Create(2),
            ]),
        ]),
        Turn.Create(Lateral.Left),
    ];
}
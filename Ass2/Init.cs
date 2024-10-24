using System.Collections.Generic;
using System.Collections.Immutable;

namespace Ass2;

public class Init {
    // This class holds the different micro programs, instances of the sequence abstract class. This is called 
    // when the program starts to load in all of the micro programs so the user can call them. 

    private List<Sequence> microPrograms = [];

    public Init() {
        microPrograms.Add(BasicSequence.Create(Square));
        microPrograms.Add(MediumSequence.Create(Random));
    }

    public void Load(Avatar avatar, int index) { microPrograms[index].Load(avatar); }

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
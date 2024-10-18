using System.Collections.Generic;

namespace Ass2;

public class Init {
    // This class holds the different micro programs, instances of the sequence abstract class. This is called 
    // when the program starts to load in all of the micro programs so the user can call them. 

    private List<Sequence> microPrograms = [];
    
    public Init() {
        microPrograms.Add(BasicSequence.CreateSequence());
    }
    
    private List<Command> Rectangle = []
}
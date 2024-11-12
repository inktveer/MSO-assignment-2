using System.Collections.Generic;
using Backend;

namespace Backend;

public class Compiler {
    static void Main() {
        
    }
    public Importer Importer  = new FileImporter("program");
    public Trace    MainTrace = new Trace();
    public Avatar   Character = new Character();
    public Init     Sequences = new Init();
}
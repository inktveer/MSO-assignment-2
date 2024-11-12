using System.Collections.Generic;
using Backend;

namespace Backend;

public class Compiler {
    static void Main() {
        
    }
    
    public Importer Importer  = new StringImporter("program");
    public Trace    MainTrace = new Trace();
    //public Log      Log       = new Log();
    public Avatar   Character = new Character();
    public Init     Sequences = new Init();
}
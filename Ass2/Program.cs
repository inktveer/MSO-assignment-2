using System.Collections.Generic;
using Backend;

namespace Backend;

public class Compiler {
    public Importer Importer  = new StringImporter();
    public Trace    MainTrace = new Trace();
    //public Log      Log       = new Log();
    public Avatar   Character = new Character();
    public Init     Sequences = new Init();
}
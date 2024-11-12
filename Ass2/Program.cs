using System.Collections.Generic;
using Backend;

namespace Backend;

public class Compiler {
    public Importer Importer  = new FileImporter();
    public Trace    MainTrace = new Trace();
    public Avatar   Character = new Character();
    public Init     Sequences = new Init();
}
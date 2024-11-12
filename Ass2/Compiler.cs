using System.Collections.Generic;
using Backend;

namespace Backend;

public class Compiler {
    public Importer Importer = new StringImporter();
    public Exporter Exporter = new StringExporter();
    public Trace    Trace = new Trace();
    public Init     Sequences = new Init();
}
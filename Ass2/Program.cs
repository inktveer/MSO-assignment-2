﻿using System.Collections.Generic;

namespace Ass2;

public class Program {
    static void Main() {
        
    }
    public Importer importer  = new FileImporter("program");
    public Trace    mainTrace = new Trace();
    public Avatar   character = new Character();
    public Init     sequences = new Init();
}
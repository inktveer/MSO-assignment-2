namespace Ass2;

public class Program(IList<Command> program) {
    private Importer importer  = new FileImporter("program");
    private Trace    mainTrace = new Trace();
    private Avatar   character = new Character();
    private Init     sequences = new Init();
}
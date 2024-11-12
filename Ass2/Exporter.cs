using System;

namespace Backend;

public interface Exporter {
    public string Export(Sequence sequence);
}

public class StringExporter : Exporter {
    public string Export(Sequence sequence) {
        string res = "";
        foreach (var command in sequence) {
            res += command.ToString();
        }

        return res;
    }
}
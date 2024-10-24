using System;
using System.Collections.Generic;
using System.IO;

namespace Ass2;

public abstract class Importer {
    public abstract Program compile();

    // WIP
    protected List<Command> _compile(IEnumerator<string> program_text, int indent = 0) {
        var program = new List<Command>();
        while (program_text.MoveNext()) {
            if (!program_text.Current!.StartsWith(replicate(indent, "    "))) return program;
            var split = program_text.Current!.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
            switch (split[0]) {
            case "Move":
                program.Add(new Move(int.Parse(split[1])));
                break;
            case "Turn":
                program.Add(new Turn(parse(split[1])));
                break;
            case "Repeat":
                program.Add(new Repeat(int.Parse(split[1]), [])); // TODO: Compile the inner part of the Repeat statement
                break;
            default:
                throw new Exception($"Unknown command: {split[0]}");
            }
        }

        return program;
    }

    static string replicate(int n, string s) {
        if (n == 0) return string.Empty;
        return replicate(n - 1, s) + s;
    }

    static Lateral parse(string s) =>
        s switch {
            "Left"  => Lateral.Left,
            "Right" => Lateral.Right,
            _       => throw new Exception(),
        };
}

public class StringImporter(string text): Importer {
    public override Program compile() => 
        new Program(_compile(text.Split('\n', StringSplitOptions.RemoveEmptyEntries).GetEnumerator() as IEnumerator<string>));
}

public class FileImporter(string filename): Importer {
    public override Program compile() =>
        new Program(_compile(new StreamReader(filename).ReadToEnd().Split('\n', StringSplitOptions.RemoveEmptyEntries).GetEnumerator() as IEnumerator<string>));
}
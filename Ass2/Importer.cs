using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;

namespace Backend;

public abstract class Importer {
    public abstract Sequence compile(string text);

    // WIP
    protected static List<Command> _compile(IEnumerator<string> program_text, int indent = 0) {
        var program = new List<Command>();
        while (program_text.MoveNext()) {
            if (!program_text.Current.StartsWith(replicate(indent, "    "))) return program;
            var split = program_text.Current!.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
            switch (split[0]) {
            case "Move":
                program.Add(new Move(int.Parse(split[1])));
                break;
            case "Turn":
                program.Add(new Turn(parse(split[1])));
                break;
            case "Repeat":
                program.Add(new Repeat(int.Parse(split[1]),
                                       _compile(program_text, indent + 1).ToImmutableList())); // TODO: Compile the inner part of the Repeat statement
                break;
            case "RepeatUntil":
                program.Add(new RepeatUntil(split[1] switch {
                    "WallAhead" => new WallAhead(),
                    "GridEdge"  => new GridEdge(),
                    _           => throw new UnknownPredicateException(split[1]),
                }, _compile(program_text, indent + 1).ToImmutableList()));
                break;
            default:
                throw new UnknownCommandException(split[0]);
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
        };
}

public class StringImporter: Importer {
    public override Sequence compile(string text) =>
        BasicSequence.Create(_compile(text.Split('\n', StringSplitOptions.RemoveEmptyEntries).GetEnumerator() as IEnumerator<string>));
}

public class FileImporter: Importer {
    public override Sequence compile(string text) =>
        BasicSequence.Create(_compile(new StreamReader(text).ReadToEnd().Split('\n', StringSplitOptions.RemoveEmptyEntries).GetEnumerator() as IEnumerator<string>));
}

public class UnknownCommandException(string command): Exception {
    public override string ToString() => $"Unknown command: {command}";
}

public class UnknownPredicateException(string predicate): Exception {
    public override string ToString() => $"Unknown predicate: {predicate}";
}
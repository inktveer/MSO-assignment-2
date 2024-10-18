using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;

namespace Ass2;

class Program {
    private Trace _trace = new();

    public static void Main(string[] args) { importFile(args[1]); }

    public static CommandGroup importFile(string path) {
        using StreamReader sr = new(path);
        return import(sr.ReadToEnd().Split('\n').GetEnumerator<string>());
    }

    static CommandGroup import(IEnumerator<string> program_text, int indent = 0) {
        var program = new List<Command>();
        while (program_text.MoveNext()) {
            if (!program_text.Current!.StartsWith(replicate(indent, "    "))) return new CommandGroup(program.ToImmutableList());
            var split = program_text.Current!.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
            switch (split[0]) {
            case "Move":
                program.Add(new Move(int.Parse(split[1])));
                break;
            case "Turn":
                program.Add(new Turn(parse(split[1])));
                break;
            case "Repeat":
                program.Add(new Repeat(import()));
            }
        }
    }

    static string replicate(int n, string s) {
        if (n ==0) return string.Empty;
        return replicate(n - 1, s) + s;
    }

    static Lateral parse(string s) =>
        s switch {
            "Left"  => Lateral.Left,
            "Right" => Lateral.Right,
            _       => throw new Exception(),
        };

    public void LoadSequence() { }
}
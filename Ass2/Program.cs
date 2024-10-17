using System.IO;

namespace Ass2;

class Program {
    private Trace _trace = new();

    public static void Main(string[] args) {
        import(args[1]);
    }

    public static CommandGroup import(string path) {
         var sr = new StreamReader(path);
         while (true) {
             if (sr.ReadLine() is not { } line) {
                 break;
             }

             var split = line.Split(" ");
             switch (split[0]) {
                     case "Move":

         }
    }

    public void LoadSequence() {
            
    }
}
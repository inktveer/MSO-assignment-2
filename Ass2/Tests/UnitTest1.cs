using System.Collections.Immutable;
using Ass2;

namespace Tests;

public class UnitTest1 {
    [Fact]
    public void CompileTest1() {
        var program = new StringImporter("Move 5").compile();
        Assert.Equal(program, new Program(new List<Command> { new Move(5) }));
    }

    [Fact]
    public void CompileTest2() {
        var program = new StringImporter("Turn Left").compile();
        Assert.Equal(program, new Program(new List<Command> { new Turn(Lateral.Left) }));
    }

    [Fact]
    public void CompileTest3() {
        var program = new StringImporter("Turn Right").compile();

        Assert.Equal(program, new Program(new List<Command> { new Turn(Lateral.Right) }));
    }

    [Fact]
    public void CompileTest4() {
        var program = new StringImporter("Repeat 5 times\n    Move 5").compile();
        Assert.Equal(program, new Program(new List<Command> { new Repeat(5, ImmutableList.Create<Command>(new Move(5))) }));
    }

    [Fact]
    public void CompileTest5() {

    }
}
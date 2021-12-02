namespace Dive;

record struct SubmarineInstruction
{
    public string direction { get; init; }
    public readonly int value { get; init; }
}
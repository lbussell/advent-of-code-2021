namespace Dive;

class Submarine
{
    public int horizontalPosition { get; private set; }
    public int depth { get; private set; }

    private int aim { get; set; }

    public Submarine()
    {
        this.horizontalPosition = 0;
        this.depth = 0;
    }

    public void ApplyInstruction(SubmarineInstruction instruction)
    {
        if (instruction.direction == "forward")
        {
            this.horizontalPosition += instruction.value;
            this.depth += this.aim * instruction.value;
        }
        else if (instruction.direction == "up")
        {
            this.aim -= instruction.value;
        }
        else if (instruction.direction == "down")
        {
            this.aim += instruction.value;
        }
    }
}
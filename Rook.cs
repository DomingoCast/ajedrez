public class Rook:Piece
{
    protected bool hasMoved = false;

    public Rook(string color)
    {
        this.color = color;
        this.name = "Rook";
        this.state = "alive";
        this.points = 5;
    }

    override public bool CheckMove(int[] pos1, int[] pos2, bool capture, Piece[,] map)
    {
        return true;
    }

    public override string ToString()
    {
        if(color == "white")
            return "r";
        else
            return "R";

    }
}

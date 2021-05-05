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

    override public bool CheckMove()
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

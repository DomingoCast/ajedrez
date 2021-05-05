public class Pawn:Piece
{
    //string name;
    //protected string state;
    //protected string color;
    //protected int points;
    protected bool hasMoved = false;

    public Pawn(string color)
    {
        this.color = color;
        this.name = "pawn";
        this.state = "alive";
        this.points = 1;
    }

    override public bool CheckMove()
    {
        return true;
    }

    public override string ToString()
    {
        if(color == "white")
            return "p";
        else
            return "P";

    }
}

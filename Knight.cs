public class Knight:Piece
{
    protected bool hasMoved = false;

    public Knight(string color)
    {
        this.color = color;
        this.name = "knight";
        this.state = "alive";
        this.points = 3;
    }

    override public bool CheckMove()
    {
        return true;
    }

    public override string ToString()
    {
        if(color == "white")
            return "n";
        else
            return "N";

    }
}

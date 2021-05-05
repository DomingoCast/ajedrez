public class Bishop:Piece
{
    //string name;
    //protected string state;
    //protected string color;
    //protected int points;

    public Bishop(string color)
    {
        this.color = color;
        this.name = "Bishop";
        this.state = "alive";
        this.points = 3;
    }

    override public bool CheckMove(int[] pos1, int[] pos2, bool capture, Piece[,] map)
    {
        return true;
    }

    public override string ToString()
    {
        if(color == "white")
            return "b";
        else
            return "B";

    }
}

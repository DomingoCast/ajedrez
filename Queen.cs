public class Queen:Piece
{
    //string name;
    //protected string state;
    //protected string color;
    //protected int points;

    public Queen(string color)
    {
        this.color = color;
        this.name = "Queen";
        this.state = "alive";
        this.points = 10;
    }

    override public bool CheckMove(int[] pos1, int[] pos2, bool capture, Piece[,] map)
    {
        return true;
    }

    public override string ToString()
    {
        if(color == "white")
            return "q";
        else
            return "Q";

    }
}

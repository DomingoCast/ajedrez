public class King:Piece
{
    //string name;
    //protected string state;
    //protected string color;
    //protected int points;

    public King(string color)
    {
        this.color = color;
        this.name = "King";
        this.state = "alive";
        this.points = 0;
    }

    override public bool CheckMove(int[] pos1, int[] pos2, bool capture, Piece[,] map)
    {
        return true;
    }

    public override string ToString()
    {
        if(color == "white")
            return "k";
        else
            return "K";

    }
}

using System;

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
        int dist1 = Math.Abs(pos1[0]-pos2[0]);
        int dist2 = Math.Abs(pos1[1]-pos2[1]);
        if((dist1 > 0 || dist2 > 0) && (dist1 <= 1 && dist2 <= 1))
            return ClearPath(pos1, pos2, map);

        return false;
    }

    public override string ToString()
    {
        if(color == "white")
            return "k";
        else
            return "K";

    }
}

using System;
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
        int dist = Math.Abs(pos1[0] - pos2[0]);
        if(dist != 0 && Math.Abs(pos1[1] - pos2[1]) == dist && ClearPath(pos1, pos2, capture, map))
        {
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        if(color == "white")
            return "b";
        else
            return "B";

    }
}

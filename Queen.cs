using System;

public class Queen:Piece
{

    public Queen(string color)
    {
        this.color = color;
        this.name = "Queen";
        this.state = "alive";
        this.points = 10;
    }

    override public bool CheckMove(int[] pos1, int[] pos2, bool capture, Piece[,] map)
    {
        //Rook move
        if((pos1[0] == pos2[0] && pos1[1] != pos2[1]) || (pos1[1] == pos2[1] && pos1[0] != pos2[0]))
        {
            if(ClearPath(pos1, pos2, capture,  map))
            {
                return true;
            }
        }
        //Bishop move
        else {
            int dist = Math.Abs(pos1[0] - pos2[0]);
            if(dist != 0 && Math.Abs(pos1[1] - pos2[1]) == dist && ClearPath(pos1, pos2, capture, map))
            {
                return true;
            }
            return false;
        }
        return false;
    }

    public override string ToString()
    {
        if(color == "white")
            return "q";
        else
            return "Q";

    }
}

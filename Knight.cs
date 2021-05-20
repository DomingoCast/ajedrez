using System;

public class Knight:Piece
{
    public Knight(string color)
    {
        this.color = color;
        this.name = "knight";
        this.state = "alive";
        this.points = 3;
        this.shape = "N";
    }

    override public bool CheckMove(int[] pos1, int[] pos2, bool capture, Piece[,] map)
    {
        int dist1 = Math.Abs(pos1[0]-pos2[0]);
        int dist2 = Math.Abs(pos1[1]-pos2[1]);
        
        if((dist1 == 2 && dist2 == 1) || (dist1 == 1 && dist2 == 2))
        {
            bool empty = map[pos2[0], pos2[1]] is null;
            if(capture)
                empty = !empty;

            return empty;
        }
        
        return false;
    }

}

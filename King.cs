using System;

public class King:Piece
{
    private bool hasMoved;

    public King(string color)
    {
        this.color = color;
        this.name = "King";
        this.state = "alive";
        this.points = 0;
        hasMoved = false;
        this.shape = "K";
    }

    override public bool CheckMove(int[] pos1, int[] pos2, bool capture, Piece[,] map)
    {
        int dist1 = Math.Abs(pos1[0]-pos2[0]);
        int dist2 = Math.Abs(pos1[1]-pos2[1]);
        if((dist1 > 0 || dist2 > 0) && (dist1 <= 1 && dist2 <= 1) && ClearPath(pos1, pos2, capture, map))
        {
            hasMoved = true;
            return true;
        }
        else
            return false;

        return false;
    }

    public bool GetHasMoved()
    {
        return hasMoved;
    }
}

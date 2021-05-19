public class Rook:Piece
{
    protected bool hasMoved = false;

    public Rook(string color)
    {
        this.color = color;
        this.name = "Rook";
        this.state = "alive";
        this.points = 5;
        this.shape = "R";
    }

    override public bool CheckMove(int[] pos1, int[] pos2, bool capture, Piece[,] map)
    {
        if((pos1[0] == pos2[0] && pos1[1] != pos2[1]) || (pos1[1] == pos2[1] && pos1[0] != pos2[0]))
        {
            if(ClearPath(pos1, pos2, capture, map))
            {
                hasMoved = true;
                return true;
            }
        }
        return false;
    }

    public bool GetHasMoved()
    {
        return hasMoved;
    }
}

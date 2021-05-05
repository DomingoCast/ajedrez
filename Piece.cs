public abstract class Piece
{
    protected string name;
    protected string state;
    protected string color;
    protected int points;

    public abstract bool CheckMove(int[] pos1, int[] pos2, bool capture, Piece[,] map);

    public abstract override string ToString();
    public string GetName()
    {
        return name;
    }
    public string GetState()
    {
        return state;
    }
    public string GetColor()
    {
        return color;
    }
    public int GetPoints()
    {
        return points;
    }
}

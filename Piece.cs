public abstract class Piece
{
    protected string name;
    protected string state;
    protected string color;
    protected int points;

    public abstract bool CheckMove();

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

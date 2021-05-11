using System;
public abstract class Piece
{
    protected string name;
    protected string state;
    protected string color;
    protected int points;

    public abstract bool CheckMove(int[] pos1, int[] pos2, bool capture, Piece[,] map);
    protected bool ClearPath(int[] pos1, int[]pos2, Piece[,]map)
    {
        bool clearPath = true; //no hay nada en el camino
        
        int dist1 = (pos2[0]- pos1[0]);
        if(dist1 != 0)
            dist1 /= Math.Abs(pos2[0] - pos1[0]);

        int dist2 = (pos2[1]- pos1[1]) ;
        if(dist2 != 0)
            dist2 /= Math.Abs(pos2[1] - pos1[1]);

        int x = pos1[0] + dist1;
        int y = pos1[1] + dist2;

        for(int i = 0; i<= Math.Max(Math.Abs(pos1[0] - pos2[0]), Math.Abs(pos1[0] - pos2[0])) - 1; i++ )
        {
            //Console.WriteLine("CAMINITO: " + x + " " + y);
            if(map[x, y] is null)
            {
            }
            else
            {
                clearPath = false;
            }

            x += dist1;
            y += dist2;
        }

        return clearPath;
    }

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

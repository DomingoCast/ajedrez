using System;
public class Pawn:Piece
{
    //string name;
    //protected string state;
    //protected string color;
    //protected int points;
    private bool enPassant = false;

    public Pawn(string color)
    {
        this.color = color;
        this.name = "pawn";
        this.state = "alive";
        this.points = 1;
    }

    override public bool CheckMove(int[] pos1, int[] pos2, bool capture, Piece[,] map)
    {
        bool clearPath = ClearPath(pos1, pos2, map); //Comprobar si funciona
        int j = -1;
        if(color == "black")
            j = -j;

        if(capture)
        {
            return (pos1[1] == pos2[1] - 1 || pos1[1] == pos2[1] + 1) && pos1[0] == pos1[0] + j; //diagonal
        }
        else if(clearPath)
        {

            if(color == "white" && pos1[0] == 1 || color == "black" && pos1[0] == 6 ) //mov inicial
            {
                return pos1[1] == pos2[1]  && (pos1[0] == pos2[0] + 2*j ||pos1[0] == pos2[0] + 1*j);
            }
            else
            {
                return pos1[0] == pos2[0] + j  && pos1[1] == pos2[1] && clearPath; // se mueve 1

            }
        }
        else
        {
            return false;
        }
    }

    public override string ToString()
    {
        if(color == "white")
            return "p";
        else
            return "P";

    }
}

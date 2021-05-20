using System;
public class Pawn:Piece
{
    public Pawn(string color)
    {
        this.color = color;
        this.name = "pawn";
        this.state = "alive";
        this.points = 1;
        this.shape = "P";
    }

    override public bool CheckMove(int[] pos1, int[] pos2, bool capture, Piece[,] map)
    {
        int j = -1;
        if(color == "black")
            j = -j;

        if(capture)
        {
            return (pos1[1] == pos2[1] - 1 || pos1[1] == pos2[1] + 1) && pos1[0] == pos2[0] + j; //diagonal
        }
        else
        {

            if(color == "white" && pos1[0] == 1 || color == "black" && pos1[0] == 6 ) //mov inicial
            {
                if(pos1[1] == pos2[1]  && (pos1[0] == pos2[0] + 2*j ||pos1[0] == pos2[0] + 1*j))
                    return ClearPath(pos1, pos2, false, map);
                else
                    return false;
            }
            else
            {
                if(pos1[0] == pos2[0] + j  && pos1[1] == pos2[1])
                    return ClearPath(pos1, pos2, false, map); //Comprobar si funciona
                else
                    return false;
            }
        }
    }
}

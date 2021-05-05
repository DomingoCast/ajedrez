using System;
public class Board
{
    protected Piece[,] map;
    public Board()
    {
        map = new Piece[8,8];

        FillBoard();

    }

    public void FillBoard()
    {
        for(int j = 0; j<8; j++)
        {
            map[1,j] = new Pawn("white");
            map[6,j] = new Pawn("black");
        }
        map[0,0] = new Rook("white");
        map[0,1] = new Bishop("white");
        map[0,2] = new Knight("white");
        map[0,3] = new Queen("white");
        map[0,4] = new King("white");
        map[0,5] = new Knight("white");
        map[0,6] = new Bishop("white");
        map[0,7] = new Rook("white");
        
        map[7,0] = new Rook("black");
        map[7,1] = new Bishop("black");
        map[7,2] = new Knight("black");
        map[7,3] = new Queen("black");
        map[7,4] = new King("black");
        map[7,5] = new Knight("black");
        map[7,6] = new Bishop("black");
        map[7,7] = new Rook("black");
    }

    public bool Move(int[] pos1, int[] pos2, string color)
    {
        if(map[pos1[0], pos1[1]] is null || map[pos1[0], pos1[1]].GetColor() != color)
            return false;
        else 
        {
            map[pos2[0], pos2[1]] = map[pos1[0], pos1[1]];
            map[pos1[0], pos1[1]] = null;
            return true;
        }
    }

    public void Draw(/*string color*/)
    {
        int[] array = {7,6,5,4,3,2,1,0};
        //if(color == "black")
            //array = {7,6,5,4,3,2,1,0};

        int count = 8;
        foreach(int i in array)
        {
            //aux += "--------\n";
            Console.Write(count+") ");
            for(int j = 0; j<8; j++)
            {
                Console.Write("|");
                if(map[i, j] is null)
                {
                    //Console.Write(i+" "+j);
                    if((i%2 == 0 && j%2 ==0) ||(i%2 != 0 && j%2 !=0))
                    {
                        Console.Write("*");

                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                else
                {
                    Console.Write(map[i, j]);
                }
            }
            Console.Write("|\n");
            count -- ;
        }
        Console.WriteLine("\n   |a|b|c|d|e|f|g|h|");
    }
    public override string ToString()
    {
        string aux = "";
        for(int i = 0; i<8; i++)
        {
            //aux += "--------\n";
            for(int j = 0; j<8; j++)
            {
                aux +="|";
                if(map[i, j] is null)
                {
                    if(i%2 == 0 && j%2 ==0)
                    {
                        aux +="*";

                    }
                    else
                    {
                        aux +=" ";
                    }
                }
                else
                {
                    aux += map[i, j];
                }
            }
            aux += "|\n";
        }
        return aux;
    }
}

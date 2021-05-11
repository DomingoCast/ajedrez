using System;
public class Board
{
    private Piece[,] map;
    private Piece[] whitePieces;
    private Piece[] blackPieces;
    public Board()
    {
        map = new Piece[8,8];
        whitePieces = new Piece[16];
        blackPieces = new Piece[16];

        createPieces();

        fillBoard();

    }

    private void createPieces()
    {
        whitePieces[0] = new Rook("white");
        whitePieces[1] = new Knight("white");
        whitePieces[2] = new Bishop("white");
        whitePieces[3] = new Queen("white");
        whitePieces[4] = new King("white");
        whitePieces[5] = new Bishop("white");
        whitePieces[6] = new Knight("white");
        whitePieces[7] = new Rook("white");
        
        blackPieces[0] = new Rook("black");
        blackPieces[1] = new Knight("black");
        blackPieces[2] = new Bishop("black");
        blackPieces[3] = new Queen("black");
        blackPieces[4] = new King("black");
        blackPieces[5] = new Bishop("black");
        blackPieces[6] = new Knight("black");
        blackPieces[7] = new Rook("black");

        for(int j = 8; j<16; j++)
        {
            whitePieces[j] = new Pawn("white");
            blackPieces[j] = new Pawn("black");
        }

    }
    private void fillBoard()
    {
        for(int j = 0; j<8; j++)
        {
            map[0,j] = whitePieces[j];
            map[7,j] = blackPieces[j];
        }
        for(int j = 0; j<8; j++)
        {
            map[1,j] = whitePieces[j+8];
            map[6,j] = blackPieces[j+8];
        }
        //map[0,0] = new Rook("white");
        //map[0,1] = new Knight("white");
        //map[0,2] = new Bishop("white");
        //map[0,3] = new Queen("white");
        //map[0,4] = new King("white");
        //map[0,5] = new Bishop("white");
        //map[0,6] = new Knight("white");
        //map[0,7] = new Rook("white");
        
        //map[7,0] = new Rook("black");
        //map[7,1] = new Knight("black");
        //map[7,2] = new Bishop("black");
        //map[7,3] = new Queen("black");
        //map[7,4] = new King("black");
        //map[7,5] = new Bishop("black");
        //map[7,6] = new Knight("black");
        //map[7,7] = new Rook("black");
    }

    private void checkChecks()
    {
        
    }

    public bool Move(int[] pos1, int[] pos2, string color)
    {
        //if(map[pos1[0], pos1[1]] is null || map[pos1[0], pos1[1]].GetColor() != color)
            //return false;
        if(false)
            Console.Write("ESTO ES UNA PRUEBA PARA PODER MOVER");
        else 
        {
            if(map[pos1[0], pos1[1]].CheckMove(pos1, pos2, false, map))
            {
                map[pos2[0], pos2[1]] = map[pos1[0], pos1[1]];
                map[pos1[0], pos1[1]] = null;
                return true;
            }
            else
                return false;
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

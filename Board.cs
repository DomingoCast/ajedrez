using System;
using System.Collections.Generic;
public class Board
{
    private Piece[,] map;
    private Piece[] whitePieces;
    private Piece[] blackPieces;
    private Dictionary<string, int[]> kingPos;
    protected Dictionary<string, int> points;

    public Board()
    {
        map = new Piece[8,8];
        whitePieces = new Piece[16];
        blackPieces = new Piece[16];
        points = new Dictionary<string, int>()
        {
            ["white"] = 0,
            ["black"] = 0

        };

        createPieces();

        fillBoard();

        kingPos = new Dictionary<string, int[]>(){
            ["white"] = new int[2]{0, 4},
            ["black"] = new int[2]{7, 4},
        };


    }
    
    public Dictionary<string, int> GetPoints()
    {
        return points;
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
    }

    private bool checkChecks(string color)
    {
        bool check = false;
        for(int i = 0; i < 8; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                if(map[i, j] is Piece && map[i, j].GetColor() != color)
                {
                    Console.Write("["+ i +","+j+"] ");
                    Console.Write(" x ");
                    check = map[i, j].CheckMove(new int[2]{i, j}, kingPos[color], true, map);
                    Console.WriteLine(check+ " ");
                }
            }
        }
        Console.WriteLine(check + " HEMOS VISTO");

        return check;
        
    }

    public bool Move(int[] pos1, int[] pos2, bool capture, string color)
    {
        //Check if the square is void or if the color of the piece is correct
        if(map[pos1[0], pos1[1]] is null || map[pos1[0], pos1[1]].GetColor() != color || (capture && map[pos2[0], pos2[1]] is null )) 
            return false;
        else 
        {
            //Check if the piece can move there
            if(map[pos1[0], pos1[1]].CheckMove(pos1, pos2, capture, map)) 
            {
                Piece piece1 = map[pos1[0], pos1[1]];
                Piece piece2 = map[pos2[0], pos2[1]];

                //If it's a king store the position
                if(piece1 is King)
                {
                    kingPos[color] = pos2;
                }

                map[pos2[0], pos2[1]] = piece1;
                map[pos1[0], pos1[1]] = null;

                // check if there are checks to your king, if illegal, restore the position
                if(checkChecks(color))
                {
                    Console.Write("YOUVE BEEN CHECKED");
                    map[pos1[0], pos1[1]] = piece1;
                    map[pos2[0], pos2[1]] = piece2;
                    
                    if(piece1 is King)
                    {
                        kingPos[color] = pos2;
                    }

                    return false;
                }
                else
                {
                    if(capture)
                        points[color]+= piece2.GetPoints();
                    return true;
                }
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
            Console.Write(count+") ");
            for(int j = 0; j<8; j++)
            {
                Console.Write("|");
                if(map[i, j] is null)
                {
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

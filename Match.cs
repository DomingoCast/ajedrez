using System;
using System.Collections.Generic;
public class Match
{
    public static void Start()
    {
        Board board = new Board();
        //Console.Write(board);
        //bool pieceMoved;
        string turn = "white";
        bool error = false;
        while(true)
        {
            //Console.Clear();
            if(error)
            {
                Console.WriteLine("Ilegal move");
            }

            Console.WriteLine(turn.ToUpper()+" TO MOVE");
            Console.WriteLine($"PUNTOS : blancas = {board.GetPoints()["white"]} | negras = {board.GetPoints()["black"]}");
            board.Draw();

            Console.Write("Enter move(y,x y,x (x for capture)): " );
            string input = Console.ReadLine();
            string[] move = input.Split(" "); //cortar por x o " "
            try
            {
                bool capture = false;
                if(input.Split("x").Length == 2)
                {
                    capture = true;

                }
                int[] pos1 = {Convert.ToInt32(move[0].Substring(1)) - 1, Convert.ToInt32(Convert.ToChar(move[0].Substring(0,1)) - 'a')};
                int[] pos2 = {Convert.ToInt32(move[move.Length - 1].Substring(1)) - 1, Convert.ToInt32(Convert.ToChar(move[move.Length - 1].Substring(0,1)) - 'a')};
                //int[] pos2 = {Convert.ToInt32(move[1].Split(",")[1]) - 1, Convert.ToInt32(Convert.ToChar(move[1].Split(",")[0]) - 'a'))};
                Console.WriteLine("HOLA 2");
                error = !board.Move(pos1, pos2, capture, turn);
                if(!error)
                {
                    if(turn == "white")
                    {
                        turn = "black";

                    }
                    else 
                    {
                        turn = "white";
                    }
                }
            }
            catch
            {
                error = true;
            }
        }
    }
}

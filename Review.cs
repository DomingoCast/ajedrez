using System;
using System.IO;
//using System.Collections.Generic;

public class Review
{
    string nombre;

    public Review(string nombre)
    {
        this.nombre = nombre;
    }

    public void Start()
    {
        Board board = new Board();

        string[] filas= File.ReadAllLines(nombre);

        string turn = "white";
        bool error = false;
        for(int i = 3; i< filas.Length; i++)
        {
            Console.Clear();

            Console.WriteLine(turn.ToUpper()+" TO MOVE");
            Console.WriteLine($"PUNTOS : blancas = {board.GetPoints()["white"]} | negras = {board.GetPoints()["black"]}");
            board.Draw();

            Console.Write("Arrow key");
            ConsoleKeyInfo input = Console.ReadKey();

            string[] move = filas[i].Split(" "); //cortar por x o " "
            try
            {
                bool capture = false;
                if(filas[i].Split("x").Length == 2)
                {
                    capture = true;
                }
                int[] pos1 = {Convert.ToInt32(move[0].Substring(1)) - 1, Convert.ToInt32(Convert.ToChar(move[0].Substring(0,1)) - 'a')};
                int[] pos2 = {Convert.ToInt32(move[move.Length - 1].Substring(1)) - 1, Convert.ToInt32(Convert.ToChar(move[move.Length - 1].Substring(0,1)) - 'a')};

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
        board.Draw();
    }
}

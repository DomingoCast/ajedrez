using System;
using System.IO;
//using System.Collections.Generic;

public class Multiplayer:Match
{
    DateTime fecha;
    string nombre;
    string tipo;

    public Multiplayer(string nombre, string tipo)
    {
        this.nombre = nombre;
        this.tipo = tipo;
        this.fecha = DateTime.Now;
    }

    override public void Start()
    {
        Board board = new Board();

        StreamWriter fileW = new StreamWriter("games/" + fecha.ToString("yyyyMMdd-hhmmss") + "-f-" + nombre);
        fileW.WriteLine(nombre);
        fileW.WriteLine(fecha);
        fileW.WriteLine(tipo);

        string turn = "white";
        bool error = false;
        string input = "";
        while(input != "ff")
        {
            displayUI(error, turn, board);

            Console.SetCursorPosition(40, 15);
            Console.Write("Enter move(y,x y,x (x for capture)): " );
            input = Console.ReadLine();

            handleMovement(input, ref error, ref turn, board);

            if(!error)
            {
                try
                {
                    fileW.WriteLine(input);
                }
                catch(IOException)
                {
                }
            }
        }

        fileW.Close(); 
    }

    //public void Start()
    //{
        //Board board = new Board();

        //StreamWriter fileW = new StreamWriter("games/" + fecha.ToString("yyyyMMdd-hhmmss") + "-f-" + nombre);
        //fileW.WriteLine(nombre);
        //fileW.WriteLine(fecha);
        //fileW.WriteLine(tipo);

        //string turn = "white";
        //bool error = false;
        //string input = "";
        //while(input != "ff")
        //{
            //Console.Clear();
            //if(error)
            //{
                //Console.SetCursorPosition(40, 10);
                //Console.ForegroundColor = ConsoleColor.Red;
                //Console.WriteLine("Ilegal move");
                //Console.ResetColor();
            //}

            //Console.SetCursorPosition(40, 2);
            //Console.WriteLine(turn.ToUpper()+" TO MOVE");

            //Console.SetCursorPosition(40, 5);
            //Console.WriteLine($"PUNTOS : blancas = {board.GetPoints()["white"]} | negras = {board.GetPoints()["black"]}");

            //Console.SetCursorPosition(0, 0);
            //board.Draw();

            //Console.SetCursorPosition(40, 15);
            //Console.Write("Enter move(y,x y,x (x for capture)): " );
            //input = Console.ReadLine();

            //string[] move = input.Split(" ");

            //try
            //{
                //bool capture = false;
                //if(move.Length == 1) // Casteling 0-0 0-0-0
                //{
                    //if(move[0] == "0-0")
                        //error = !board.Castle("king", turn);
                    //else if(move[0] == "0-0-0")
                        //error = !board.Castle("queen", turn);
                    //else
                        //error = true;
                //}

                //else
                //{
                    //if(input.Split("x").Length == 2)
                    //{
                        //capture = true;
                    //}

                    //int[] pos1 = {Convert.ToInt32(move[0].Substring(1)) - 1, Convert.ToInt32(Convert.ToChar(move[0].Substring(0,1)) - 'a')};
                    //int[] pos2 = {Convert.ToInt32(move[move.Length - 1].Substring(1)) - 1, Convert.ToInt32(Convert.ToChar(move[move.Length - 1].Substring(0,1)) - 'a')};

                    //error = !board.Move(pos1, pos2, capture, turn);
                //}

                //if(!error)
                //{
                    //fileW.WriteLine(input);
                    //if(turn == "white")
                    //{
                        //turn = "black";
                    //}
                    //else 
                    //{
                        //turn = "white";
                    //}
                //}
            //}
            //catch
            //{
                //error = true;
            //}
        //}
        //fileW.Close();
    //}
}

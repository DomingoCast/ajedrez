using System;
using System.IO;

public class Review:Match
{
    public Review(string nombre)
    {
        this.nombre = nombre;
        board = new Board();
    }

    override public void Start()
    {

        string[] filas= File.ReadAllLines(nombre);

        string turn = "white";
        bool error = false;
        for(int i = 3; i< filas.Length; i++)
        {
            displayUI(error, turn);

            Console.SetCursorPosition(40, 15);
            Console.Write("Press for next move...");
            Console.ReadKey();

            string move = filas[i];
            handleMovement(move, ref error , ref turn);
        }
        displayUI(error, turn);

        Console.SetCursorPosition(40, 15);
        Console.Write("Press enter to exit...");
        Console.ReadKey();
    }
}

using System;
using System.IO;

public class Multiplayer:Match
{
    private DateTime fecha;
    private string tipo;

    public Multiplayer(string nombre, string tipo)
    {
        this.nombre = nombre;
        this.tipo = tipo;
        this.fecha = DateTime.Now;
        this.board = new Board();
    }

    override public void Start()
    {
        if(!Directory.Exists("./games/"))
            Directory.CreateDirectory("./games/");

        StreamWriter fileW = new StreamWriter("games/" + fecha.ToString("yyyyMMdd-hhmmss") + "-f-" + nombre+".txt");
        fileW.WriteLine(nombre);
        fileW.WriteLine(fecha);
        fileW.WriteLine(tipo);


        string turn = "white";
        bool error = false;
        string input = "";
        while(input != "ff")
        {
            displayUI(error, turn);

            Console.SetCursorPosition(40, 15);
            Console.Write("Enter move(y,x y,x (x for capture)): " );
            input = Console.ReadLine();

            handleMovement(input, ref error, ref turn);

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
}

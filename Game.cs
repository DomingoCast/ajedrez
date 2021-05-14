using System;
public class Game
{
    public static void Start()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();
        Match partida = new Match("prueba", "unlimited 1v1");
        partida.Start();
    }
}

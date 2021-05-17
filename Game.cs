using System;
public class Game
{
    public static void Start()
    {
        //Console.WriteLine("Press any key to continue...");
        Console.WriteLine("WELCOME TO TERMINAL CHESS");
        Console.WriteLine();
        Console.Write("Press 1 for new game 2 for review: ");
        string input = Console.ReadLine();
        if(input == "1")
        {
            Match partida = new Match("prueba", "unlimited 1v1");
            partida.Start();

        }
        else if (input == "2")
        {
            Review partida = new Review("prueba.txt"); //fijo mientras
            partida.Start();
        }
        else
        {
            Console.WriteLine("U damn fuck, don't even know how to follow the rules''");
        }
    }
}

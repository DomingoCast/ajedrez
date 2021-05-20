using System;
using System.IO;

public class Game
{
    private static string newMultiplayer()
    {
        Console.Clear();
        Console.SetCursorPosition(15, 15);
        Console.Write("Introduce nombre partida: ");
        return Console.ReadLine();

    }

    private static string reviewMenu()
    {
        string[] array = Directory.GetFiles("./games", "*-f-*");
        
        int pos = 0;
        ConsoleKeyInfo tecla;
        while(true)
        {
            Console.Clear();

            for(int i = 0; i< array.Length; i++)
            {
                if(i == pos)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(array[i].Split("-f-")[1]);
                    Console.ResetColor();
                }
                else
                    Console.WriteLine(array[i].Split("-f-")[1]);
            }

            tecla = Console.ReadKey();
            if(tecla.Key == ConsoleKey.UpArrow)
            {
                if(pos > 0)
                    pos--;

            }
            else if(tecla.Key == ConsoleKey.DownArrow)
            {
                if(pos < array.Length)
                    pos++;
            }
            else if(tecla.Key == ConsoleKey.Enter)
            {
                return array[pos];
            }
        }
    }

    public static void Start()
    {
        //Console.WriteLine("Press any key to continue...");
        Console.Clear();
        Console.SetCursorPosition(18, 13);
        Console.WriteLine("WELCOME TO TERMINAL CHESS");
        Console.WriteLine();
        Console.SetCursorPosition(13, 15);
        Console.Write("Press 1 for new game 2 for review: ");

        string input = Console.ReadLine();
        if(input == "1")
        {
            
            Multiplayer partida = new Multiplayer(newMultiplayer(), "unlimited 1v1");
            Console.Clear();
            partida.Start();

        }
        else if (input == "2")
        {
            Review partida = new Review(reviewMenu()); //fijo mientras
            Console.Clear();
            partida.Start();
        }
        else
        {
            Console.WriteLine("U damn fuck, don't even know how to follow the rules''");
        }
    }
}

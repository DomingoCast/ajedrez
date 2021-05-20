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
        Array.Sort(array);
        Array.Reverse(array);
        
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
                    Console.WriteLine(array[i].Split("-f-")[1].Split(".txt")[0]);
                    Console.ResetColor();
                }
                else
                    Console.WriteLine(array[i].Split("-f-")[1].Split(".txt")[0]);
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

    private static void exit()
    {
        Console.Clear();
        Console.Write("Goodbye...");
        Console.ReadKey();
    }

    private static void showMenu()
    {
        Console.Clear();
        Console.SetCursorPosition(18, 13);
        Console.WriteLine("WELCOME TO TERMINAL CHESS");
        Console.WriteLine();
        Console.SetCursorPosition(13, 15);
        Console.Write("Press 1 for multiplayer 2 for review (E for exit): ");
    }

    public static void Start()
    {
        string input= "";
        while(input.ToLower() != "e")
        {
            showMenu();
            input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    
                    Multiplayer partidaMult = new Multiplayer(newMultiplayer(), "unlimited 1v1");
                    Console.Clear();
                    partidaMult.Start();
                    break;

                case "2":
                    Review partidaRev = new Review(reviewMenu()); 
                    Console.Clear();
                    partidaRev.Start();
                    break;
                case "e":
                case "E":
                    exit();
                    break;
                default:
                    break;
            }
        }
    }
}

using System;

public abstract class Match
{
    protected string nombre;
    protected Board board;

    protected void displayUI(bool error, string turn)
    {
            Console.Clear();
            if(error)
            {
                Console.SetCursorPosition(40, 10);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ilegal move");
                Console.ResetColor();
            }

            Console.SetCursorPosition(40, 2);
            Console.WriteLine(turn.ToUpper()+" TO MOVE");

            Console.SetCursorPosition(40, 5);
            Console.WriteLine($"PUNTOS : blancas = {board.GetPoints()["white"]} | negras = {board.GetPoints()["black"]}");

            Console.SetCursorPosition(0, 0);
            board.Draw();
    }

    protected void handleMovement(string input, ref bool error, ref string turn)
    {
        string[] move = input.Split(" ");
        bool capture = false;

        if(move.Length == 1) // Casteling 0-0 0-0-0
        {
            if(move[0] == "0-0")
                error = !board.Castle("king", turn);
            else if(move[0] == "0-0-0")
                error = !board.Castle("queen", turn);
            else
                error = true;
        }

        else
        {
            if(input.Split("x").Length == 2)
            {
                capture = true;
            }

            int[] pos1 = {Convert.ToInt32(move[0].Substring(1)) - 1, Convert.ToInt32(Convert.ToChar(move[0].Substring(0,1)) - 'a')};
            int[] pos2 = {Convert.ToInt32(move[move.Length - 1].Substring(1)) - 1, Convert.ToInt32(Convert.ToChar(move[move.Length - 1].Substring(0,1)) - 'a')};

            error = !board.Move(pos1, pos2, capture, turn);
        }

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

    public abstract void Start();
}

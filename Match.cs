using System;
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
            board.Draw();

            Console.Write("Enter move(y,x y,x): " );
            string[] move = Console.ReadLine().Split(" ");
            try
            {
                int[] pos1 = {Convert.ToInt32(move[0].Substring(1)) - 1, Convert.ToInt32(Convert.ToChar(move[0].Substring(0,1)) - 'a')};
                int[] pos2 = {Convert.ToInt32(move[1].Substring(1)) - 1, Convert.ToInt32(Convert.ToChar(move[1].Substring(0,1)) - 'a')};
                //int[] pos2 = {Convert.ToInt32(move[1].Split(",")[1]) - 1, Convert.ToInt32(Convert.ToChar(move[1].Split(",")[0]) - 'a'))};
                error = !board.Move(pos1, pos2, turn);
                if(!error)
                {
                    if(turn == "white")
                        turn = "black";
                    else 
                        turn = "white";
                }
            }
            catch
            {
                error = true;
            }
        }
    }
}

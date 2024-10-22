using System;

public class game
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        char[,] board = new char[3, 3];
        char currentPlayer = 'X';
        bool isGameOver = false;
        int movesCount = 0;

       
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = ' ';  
            }
        }

        
        while (!isGameOver)
        {
      
            Console.Clear();
            Console.WriteLine("    0   1   2");
            Console.WriteLine("  -----------");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(i + " | ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j]);
                    if (j < 2) Console.Write(" | ");
                }
                Console.WriteLine(" |");
                Console.WriteLine("  -----------");
            }

       
            int row, col;
            Console.WriteLine($" {currentPlayer} -ის ჯერია, შეიყვანეთ არჩეული სვლის სტრიქონი და სვეტი(0, 1, or 2): ");

          
            while (true)
            {
                row = int.Parse(Console.ReadLine());
                col = int.Parse(Console.ReadLine());

                if (row >= 0 && row < 3 && col >= 0 && col < 3 && board[row, col] == ' ')
                {
                    board[row, col] = currentPlayer;
                    movesCount++;
                    break;
                }
                else
                {
                    Console.WriteLine("არავალიდური სვლა! კიდევ სცადეთ.");
                }
            }

  
            for (int i = 0; i < 3; i++)
            {
             
                if ((board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer) ||
                    (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer))
                {
                    Console.Clear();
                    Console.WriteLine($"მოთამაშე {currentPlayer}-მა მოიგო!");
                    isGameOver = true;
                    break;
                }
            }

           
            if ((board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) ||
                (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer))
            {
                Console.Clear();
                Console.WriteLine($"მოთამაშე {currentPlayer}-მა მოიგო!");
                isGameOver = true;
            }

           
            if (movesCount == 9 && !isGameOver)
            {
                Console.Clear();
                Console.WriteLine("ფრე!");
                isGameOver = true;
            }

           
            if (!isGameOver)
            {
                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            }
        }
    }
}

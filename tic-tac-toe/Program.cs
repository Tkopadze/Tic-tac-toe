using System;
using System.Security.Cryptography.X509Certificates;

public class game
{

    private static char currentPlayer = 'X';
    private static bool isGameOver = false;
    private static int movesCount = 0;
    private static char[,] board = new char[3, 3];


    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        createBoard();

        while (!isGameOver)
        {
            Console.Clear();
            printBoard();
            chooseMove();
            chooseWinner();
            switchPlayer();

        }
    }

    private static void printBoard()
    {
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
    }

    private static void chooseMove()
    {
        int row, col;
        while (true)

        {
            try
            {
                Console.WriteLine($"{currentPlayer} -ის ჯერია, შეიყვანეთ არჩეული სვლის სტრიქონი და სვეტი (0, 1, ან 2): ");

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
            catch (FormatException)
            {
                Console.WriteLine("გთხოვთ, შეიყვანოთ რიცხვი.");
            }
        }

    }

    private static void chooseWinner()
    {
        for (int i = 0; i < 3; i++)
        {

            if ((board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer) ||
                (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer))
            {

                announceWinner();
                return;
            }
        }


        if ((board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) ||
            (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer))
        {

            announceWinner();
            return;
        }

        if (movesCount == 9)
        {
            Console.Clear();
            printBoard();
            Console.WriteLine("ფრე!");
            isGameOver = true;
        }
    }

    private static void createBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = ' ';
            }
        }

    }
    private static void announceWinner()
    {
        Console.Clear();
        printBoard();
        Console.WriteLine($"მოთამაშე {currentPlayer}-მა მოიგო!");
        isGameOver = true;
    }


    private static void switchPlayer()
    {
        {
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
        }
    }

}



using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] ticTacToeBoard =
            {
                //0   1   2   3    4   
                {'.','|','.','|', '.',' ', '1' },//0
                {'-','+','-','+', '-','-', '-' },//1
                {'.','|','.','|', '.',' ', '2' },//2
                {'-','+','-','+', '-','-', '-' },//3
                {'.','|','.','|', '.',' ', '3' },//4
                {'1','|','2','|', '3',' ', ' ' },
            };
            for (int turns = 0; turns < 9; turns++)
            {
                View(ticTacToeBoard);
                char player = 'X';
                if (turns % 2 == 1)
                    player = 'O';
                int r; int c; //initializing row and column
                do
                {
                    Console.Write($"Player {player} Enter Row (1-3): ");
                    r = (int.Parse(Console.ReadLine()) - 1) * 2 ; //this algebra equation converts user input to usable rows 
                    Console.Write("Enter Column (1-3): ");        //(x - 1) * 2= r 
                    c = (int.Parse(Console.ReadLine()) - 1) * 2 ;
                    if (r >= 0 && r <= 4 && c >= 0 && c <= 4 && ticTacToeBoard[r, c] == '.')
                    {
                        ticTacToeBoard[r, c] = player;
                    }
                    else Console.WriteLine("Enter a valid space");
                }
                while (r < 0 || r > 4 || c < 0 || c > 4 || ticTacToeBoard[r, c] != player);
                if (CheckWin(ticTacToeBoard, player) == true)
                {
                    Console.WriteLine($"Congrats player {player}! You won!");
                    break;
                }
            }
        }

        public static void View(char[,] board)
        {
            Console.WriteLine();
            for (int j = 0; j < 6; j++)
            {
                for (int k = 0; k < 7; k++)
                {
                    Console.Write(board[j, k]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static bool CheckWin(char[,] board, char p)
        {
            bool win = false;
            int i = 0;
            for (int r = 0; r < 5; r+=2)
            {
                for (int c = 0; c < 5; c+=2)
                {
                    if (board[r, c] == p)
                    {
                        i++;
                        if (i == 3) win = true;
                    }
                    else
                    {
                        i = 0;
                        break;
                    }
                }
            }
            for (int c = 0; c < 5; c+=2)
            {
                for (int r = 0; r < 5; r+=2)
                {
                    if (board[r, c] == p)
                    {
                        i++;
                        if (i == 3) win = true;
                    }
                    else
                    {
                        i = 0;
                        break;
                    }
                }
            }
            char[] diag1 = { board[0, 0], board[2, 2], board[4, 4] };
            char[] diag2 = { board[0, 4], board[2, 2], board[4, 0] };
            foreach (char place in diag1)
            {
                if (place != p)
                {
                    i = 0;
                    break;
                }
                i++;
                if (i == 3) win = true;
            }
            foreach (char place in diag2)
            {
                if (place != p)
                {
                    i = 0;
                    break;
                }
                i++;
                if (i == 3) win = true;
            }
            return win;
        }
    }
}

using System;

namespace TicTacToe {
    class Program {
        static void Main() {

            PaintConsole();
            //Here we are initiating the player
            char player = 'X';
            char[,] board = new char[3, 3];
            bool playAgain = true;


            int moovesPlayed = 0;

            while (playAgain == true) {

                Console.Clear();
                DrawBoard(board);
                Console.WriteLine("\n");

                int row, col;
                //This method just validate somethings
                addData(out row, out col);
                //We paint the board in the position given
                if (board[row, col] == 'X' || board[row,col] == 'O') {
                    Console.WriteLine("Already exist");
                   
                    Console.ReadKey();
                }
                else {
                    board[row, col] = player;
                    moovesPlayed++;
                }

                //We need to check if the player has won

                //Horizontal
                if (player == board[0, 0] && player == board[0, 1] && player == board[0, 2]
                    || player == board[1, 0] && player == board[1, 1] && player == board[1, 2]
                    || player == board[2, 0] && player == board[2, 1] && player == board[2, 2]

                    //Vertical
                    || player == board[0, 0] && player == board[1, 0] && player == board[2, 0]
                    || player == board[0, 1] && player == board[1, 1] && player == board[2, 1]
                    || player == board[0, 2] && player == board[1, 2] && player == board[2, 2]

                    //Diagonal
                    || player == board[0, 0] && player == board[1, 1] && player == board[2, 2] 
                    || player == board[0, 2] && player == board[1, 1] && player == board[2, 0]) {


                    Console.WriteLine($" {player} has won");
                    Console.WriteLine("Play again? N" + "/" + "Y" );
                    string input = Console.ReadLine();

                    if (input.ToLower() == "y") {
                        playAgain = true;
                        Main();
         
                    }
                    else if (input.ToLower() == "n") {
                        playAgain = false;
                    }
                }

                

                if (moovesPlayed == 9) {

                    Console.WriteLine("Is a Draw");
                    break;
                }

                //Here we switch the players symbol
                player = ChangeTurn(player);

                DrawBoard(board);

            }

        }

        private static void ResetBoard(char[,] board) {

            board = new char[3, 3]; 

        }

        private static void addData(out int row, out int col) {

            Console.Write("Enter row: ");
            string inputRow = Console.ReadLine();
            while (!int.TryParse(inputRow, out row)) {

                Console.Write("Enter row: ");
                inputRow = Console.ReadLine();
            }
            Console.Write("Enter column: ");
            string inputColunm = Console.ReadLine();
            while (!int.TryParse(inputColunm, out col)) {

                Console.Write("Enter column: ");
                inputColunm = Console.ReadLine();
            }
        }

        private static char ChangeTurn(char currentPlayer) {

            if (currentPlayer == 'X') {
                return 'O';
            }
            else {
                return 'X';
            }
        }

        private static void PaintConsole() {

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void DrawBoard(char[,] board) {

            Console.Write("     0   1   2  ");
            Console.WriteLine("\n");

            //Loop through rows, because our game have 3 rows, we loop until 3
            for (int row = 0; row < 3; row++) {

                Console.Write($"{row}  | ");
                //Loop through column, because our game have 3 column, we loop until 3
                for (int colnum = 0; colnum < 3; colnum++) {

                    //We are painting the board with the values
                    Console.Write(board[row, colnum]);
                    Console.Write(" | ");
                }
                Console.WriteLine();
            }
        }
    }
}

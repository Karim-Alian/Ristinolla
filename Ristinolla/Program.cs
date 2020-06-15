using System;

namespace Ristinolla
{
    class Program
    {
        static String[] board = new String[9];
        static String playsAgain = "Y";
        static int counter = 0;

        static void initializeVariable()
        {
            for (int i = 0; i < 9; i++)
            {
                board[i] = i.ToString();
            }
        }

        static void playAgainMsg(String message)
        {
            Console.WriteLine(message + "\nHaluatko pelata uudelleen? y/n");
            if (Console.ReadLine().Equals("Y"))
                playsAgain.Equals("Y");
            else
                playsAgain.Equals("N");
        }

        static void Main(string[] args)
        {
            introduction();
            while (playsAgain.Equals("Y"))
            {
                initializeVariable();
                while (hasWon() == false && counter < 9)
                {
                    askData("X");
                    if (hasWon() == true)
                        break;
                    askData("O");
                }
                if (hasWon() == true)
                    playAgainMsg("Onneksi olkoon! Voitit!");
                else
                    playAgainMsg("Tasapeli!");
            }
            goodBye();
        }

        static void goodBye()
        {
            Console.WriteLine("Kiitos peluusta");
            Console.ReadLine();

        }

        static void askData(String player)
        {
            Console.Clear();

            Console.WriteLine("Sinun vuorosi, " + player);
            int selection;

            while (true)
            {
                Console.WriteLine("Valitse ruutu:");
                drawBoard();
                selection = Convert.ToInt32(Console.ReadLine());
                if (selection < 0 || selection > 9 || (board[selection].Equals("X") || board[selection].Equals("O")))
                    Console.WriteLine("Vain 0:n ja 8:n väliltä");
                else
                    break;
            }
            board[selection] = player;


        }

        static void drawBoard()
        {
            for (int i = 0; i < 7; i += 3) 
                Console.WriteLine(board[i] + "|" + board[i + 1] + "|" + board[i + 2]);
        }

        static Boolean hasWon()
        {
            for (int i = 0; i < 7; i += 3)
            {
                if (board[i].Equals(board[i + 1]) && board[i + 1].Equals(board[i + 2]))
                {
                    return true;
                }
            }
            if (board[0].Equals(board[3]) && board[3].Equals(board[6]))
                return true;
            if (board[1].Equals(board[4]) && board[4].Equals(board[7]))
                return true;
            if (board[2].Equals(board[5]) && board[3].Equals(board[8]))
                return true;
            if (board[2].Equals(board[4]) && board[4].Equals(board[6]))
                return true;
            if (board[0].Equals(board[4]) && board[4].Equals(board[8]))
                return true;
            return false;
        }


        static void introduction()
        {
            Console.Title = ("Ristinolla");
            Console.WriteLine("Tervetuloa pelaamaan ristinollaa.\n");
            Console.WriteLine("Aloita painamalla mitä tahansa näppäintä.");
            Console.ReadLine();
            Console.Clear();
        }

    }
}

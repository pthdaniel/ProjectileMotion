using System;

namespace Projectile
{

    class Canvas
    {
        char[,] board;

        #region getterek
        public char[,] Board { get => board; }
        #endregion

        public Canvas(int height, int width)
        {
            board = new char[height + 1, width + 1]; //indexing needs more space

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    board[i, 0] = '|';
                    board[height, j] = '-';
                }
            }
            board[height, 0] = 'O';

            board[height - (int)Math.Round(Program.p.Y0), 0] = '+'; // starting point
            board[height, (int)Math.Floor(Program.p.Xmax)] = '+'; // landing point

            int index;
            for (int i = 1; i < width; i++)
            {
                index = Program.p.OtherPosition(i);
                if (index <= height) // needed because of rounding
                {
                    board[index, i] = '+';
                }
            }
        }


        public void Out()
        {
            Console.Clear();
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == '+')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(board[i, j]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(board[i, j]);
                    }

                    if (i == board.GetLength(0) - 1 && j < board.GetLength(1) - 1)
                    {
                        Console.Write("--");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.Write("A kezdősebeség nagysága: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(Program.p.V0);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("m/s");
            Console.ResetColor();
            Console.WriteLine();

            Console.Write(">>> x irányú komponensének nagysága: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(Program.p.V0x);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("m/s");
            Console.ResetColor();
            Console.WriteLine();

            Console.Write(">>> y irányú komponensének nagysága: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(Program.p.V0y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("m/s");
            Console.ResetColor();
            Console.WriteLine();

            Console.Write("A kezdőmagasság: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(Program.p.Y0);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("m");
            Console.ResetColor();
            Console.WriteLine();

            Console.Write("A hajítási szög: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(Program.p.A * 180 / Math.PI);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("°");
            Console.ResetColor();
            Console.WriteLine();

            Console.Write("A hajítás időtartama: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(Program.p.Tall);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("s");
            Console.ResetColor();
            Console.WriteLine();

            Console.Write("Az emelkedési idő: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(Program.p.Tascension);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("s");
            Console.ResetColor();
            Console.WriteLine();

            Console.Write("A maximális magasság: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(Program.p.Ymax);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("m");
            Console.ResetColor();
            Console.WriteLine();

            Console.Write("A hajítás távolsága: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(Program.p.Xmax);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("m");
            Console.ResetColor();
            Console.WriteLine();

            Console.WriteLine();

        }
    }
}

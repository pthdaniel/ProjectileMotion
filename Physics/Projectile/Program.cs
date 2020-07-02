using System;

namespace Projectile
{
    class Program
    {
        public static Projectile p;
        public static Canvas board;

        static void Main()
        {
            Run();
        }

        static void Input()
        {
            double v0;
            double a;
            double y0;

            Console.Clear();
            Console.WriteLine("Kérem, adja meg az adatokat!");
            string seged;
            do
            {
                Console.Write("Kezdősebesség (m/s): "); //initial velocity
                seged = Console.ReadLine();
            } while (!double.TryParse(seged, out v0));

            do
            {
                Console.Write("Magasság (m): "); // initial height
                seged = Console.ReadLine();
            } while (!double.TryParse(seged, out y0));

            do
            {
                Console.Write("Hajítási szög (fok): "); // initial angle (degree)
                seged = Console.ReadLine();
            } while (!double.TryParse(seged, out a));

            p = new Projectile(v0, y0, a);
        }

        static void GenerateCanvas()
        {
            int height = (int)Math.Round(p.Ymax, 5);
            int width = (int)Math.Round(p.Xmax, 5);
            board = new Canvas(height, width);
        }

        static void Run()
        {
            Input();
            GenerateCanvas();
            TimeInput();
        }

        static void TimeInput()
        {
            board.Out();

            string input;

            do
            {
                Console.Write("Adjon meg egy időpillanatot (s), vagy kilépéshez írja be 'exit': ");
                input = Console.ReadLine();
                if (input == "exit")
                {
                    Environment.Exit(0);
                }
                else if (double.TryParse(input, out double t) && double.Parse(input) < p.Tall)
                {
                    p.Momentary(t);
                    p.MomentaryOut();
                }
            } while (true);
        }
    }
}

using System;

namespace Projectile
{
    class Projectile
    {
        private double v0;
        private double y0; // starting height
        private double a; // Alpha starting angle
        private double v0x; // constant, = vx
        private double v0y;
        private double tall;
        private double g = 9.81;
        private double xmax;
        private double ymax;
        private double tascension;

        private double v;
        private double x;
        private double y;
        private double vy;
        private double b; // Beta angle momentary
        private double t;

        #region getter-setter
        public double V0 { get => v0; }
        public double Y0 { get => y0; }
        public double A { get => a; }
        public double V0x { get => v0x; }
        public double V0y { get => v0y; }
        public double Tall { get => tall; }
        public double G { get => g; }
        public double Xmax { get => xmax; }
        public double Ymax { get => ymax; }
        public double V { get => v; }
        public double X { get => x; }
        public double Y { get => y; }
        public double Tascension { get => tascension; }
        public double Vy { get => vy; }
        public double B { get => b; }
        public double T { get => t; }
        #endregion

        public Projectile(double v0, double y0, double a)
        {
            this.v0 = v0;
            this.y0 = y0;
            this.a = a * Math.PI / 180; // this.a is in radian
            v0x = Math.Cos(this.a) * v0;
            v0y = Math.Sin(this.a) * v0;
            tall = (v0y + Math.Sqrt(Math.Pow(v0y, 2) + 2 * g * this.y0)) / g;
            ymax = y0 + Math.Pow(v0y, 2) / (2 * g);
            xmax = tall * v0x;
            tascension = (v0 * Math.Sin(this.a)) / g;
            if (tascension < 0) { tascension = 0; }
        }
        public void Momentary(double t)
        {
            this.t = t;
            vy = Math.Abs(v0 * Math.Sin(a) - g * t);
            v = Math.Sqrt(Math.Pow(v0x, 2) + Math.Pow(vy, 2));
            b = Math.Atan(vy / v0x) * 180 / Math.PI; // degree
            if (t > tall / 2)
            {
                b = -b;
            }
            x = t * v0x;
            y = y0 + v0y * t - (g / 2) * Math.Pow(t, 2);
        }

        public void MomentaryOut()
        {
            Console.Clear();

            Program.board.Out();

            Console.Write("Idő: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(t);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("s");
            Console.ResetColor();
            Console.WriteLine();

            Console.WriteLine();

            Console.Write("A pillanatnyi sebesség nagysága: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(v);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("m/s");
            Console.ResetColor();
            Console.WriteLine();

            Console.Write(">>> x irányú komponensének nagysága: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(v0x);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("m/s");
            Console.ResetColor();
            Console.WriteLine();

            Console.Write(">>> y irányú komponensének nagysága: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(vy);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("m/s");
            Console.ResetColor();
            Console.WriteLine();

            Console.Write("A pillanatnyi sebesség iránya: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(b);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("°");
            Console.ResetColor();
            Console.WriteLine();

            Console.Write("Az x irányú elmozdulás: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(x);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("m");
            Console.ResetColor();
            Console.WriteLine();

            Console.Write("Az tömegpont magassága: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("m");
            Console.ResetColor();
            Console.WriteLine();
        }

        public int OtherPosition(int position)
        {
            double t = position / v0x;

            y = y0 + v0y * t - (g / 2) * Math.Pow(t, 2);

            return (int)Math.Round(ymax, 1) + 1
                - (int)Math.Round(y); // 'reverse' because array counts downwards
        }
    }
}

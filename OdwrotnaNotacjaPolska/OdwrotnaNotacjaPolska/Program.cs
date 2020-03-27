using System;
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
    
            Zm(args[0], args[1]);

            Console.WriteLine();

            Prz(args[0], args[1], double.Parse(args[2]), double.Parse(args[3]), double.Parse(args[4]));

            Console.WriteLine("");
        }
        static void Prz(string wyr, string x, double pp, double kp, double n)
        {
            double w = 0.0;
            Mat.OdwrotnaNotacjaPolska rpn = new Mat.OdwrotnaNotacjaPolska();
            double o, d, o1;

            o = kp - pp;
            o1 = Math.Abs(o);

            Console.WriteLine();

            d = o1 / (n - 1);
            w = 0;
            int ind = wyr.IndexOf('x');
            wyr = wyr.Remove(ind, Convert.ToInt32(x));
            string l;
            for (double i = pp; i <= kp; i += d)
            {
                l = i.ToString();
                l = l.Replace(',', '.');
                wyr = wyr.Insert(ind, l);

                rpn.Parse(wyr);
                w = rpn.Ocenianie();
                Console.WriteLine("Wersja Poczatkowa: {0}", rpn.OrygnialneWyrazenie);
                Console.WriteLine();
                Console.WriteLine("zamiana: {0}", rpn.ZamianaWyrazenia);
                Console.WriteLine();
                Console.WriteLine("postfix: {0}", rpn.WyrazeniePostfixowe);
                Console.WriteLine();
                Console.WriteLine("Wynik: {0}", w);
                Console.WriteLine();
                wyr = wyr.Remove(ind, l.Length);


            }


        }
        static void Zm(string wyr, string x)
        {
            double w = 0;



            Console.WriteLine();

            Console.WriteLine();

            int ind = wyr.IndexOf('x');
            wyr = wyr.Remove(ind, 1);
            wyr= wyr.Insert(ind, x);

            Mat.OdwrotnaNotacjaPolska rpn = new Mat.OdwrotnaNotacjaPolska();
            Console.WriteLine();
            rpn.Parse(wyr);
            w = rpn.Ocenianie();
            Console.WriteLine("Wersja Poczatkowa: {0}", rpn.OrygnialneWyrazenie);
            Console.WriteLine("");
            Console.WriteLine("Zamiana: {0}", rpn.ZamianaWyrazenia);
            Console.WriteLine("");
            Console.WriteLine("Postfix: {0}", rpn.WyrazeniePostfixowe);
            Console.WriteLine("");
            Console.WriteLine("Wynik: {0}", w);
            Console.WriteLine("");

        }
    }
}
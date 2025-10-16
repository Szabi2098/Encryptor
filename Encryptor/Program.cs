using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace feladat2
{
    internal class Program
    {
        static int kodSzam = 2459;
        static void Main(string[] args)
        {
            Console.WriteLine("Adja meg a titkosítandó szöveget:");
            string szoveg = Console.ReadLine();

            string encrypted = Encryptor(szoveg, kodSzam);
            Console.WriteLine($"Titkosított szöveg: {encrypted}");
            Console.ReadLine();
        }
        static string Encryptor(string szoveg, int kodSzam)
        {
            string abc = "abcdefghijklmnopqrstuvwxyz";
            string kodString = kodSzam.ToString().PadLeft(4, '0');

            string eredmeny = "";

            for (int i = 0; i < szoveg.Length; i++)
            {
                char betu = char.ToLower(szoveg[i]);
                int eltol = kodString[i % 4] - '0';

                if (abc.Contains(betu))
                {
                    int eredetiIndex = abc.IndexOf(betu);
                    int ujIndex = (eredetiIndex + eltol) % abc.Length;
                    eredmeny += abc[ujIndex];
                }
                else
                {
                    eredmeny += szoveg[i];
                }
            }

            return eredmeny;
        }

    }
}

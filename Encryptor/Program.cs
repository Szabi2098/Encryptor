using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Encryptor
{
    internal class Program
    {
        static int kodSzam = 2459;

        static void Main()
        {
            Console.Clear();
            Console.Title = "Encryptor/Decryptor";
            Console.WriteLine("---- Encryptor/Decryptor ---- \n");
            Console.WriteLine("1 - Enkriptálás");
            Console.WriteLine("2 - Dekriptálás");
            Console.WriteLine("3 - Kilépés");
            Console.WriteLine("Menüpont számával választhat");
            string valasz = Console.ReadLine();

            if (valasz == "1")
            {
                EncryptMenu();
            }
            else if (valasz == "2")
            {
                DecryptMenu();
            }
            else if (valasz == "3")
            {
                Console.WriteLine("Biztosan ki szeretne lépni? (i/n)");
                valasz = Console.ReadLine();
                if (valasz.ToLower() == "i")
                {
                    Environment.Exit(0);
                }
                else{
                    Main()
                }
            }
        }

        static void EncryptMenu()
        {
            Console.Clear();
            Console.WriteLine("Adja meg a titkosítandó szöveget:");
            string szoveg = Console.ReadLine();

            string encrypted = Encryptor(szoveg, kodSzam);
            Console.WriteLine($"\nTitkosított szöveg: \n{encrypted} \n \n");

            Console.WriteLine("1 - Újra");
            Console.WriteLine("2 - Kilépés");
            string valasz = Console.ReadLine();

            if (valasz == "1")
            {
                EncryptMenu();
            }
            else if (valasz == "2")
            {
                Main();
            }
        }

        static void DecryptMenu()
        {
            Console.Clear();
            Console.WriteLine("Adja meg a titkosíott szöveget:");
            string szoveg = Console.ReadLine();

            string decrypted = Decryptor(szoveg, kodSzam);
            Console.WriteLine($"\nMegfejtettt szöveg: \n{decrypted} \n \n");

            Console.WriteLine("1 - Újra");
            Console.WriteLine("2 - Kilépés");
            string valasz = Console.ReadLine();

            if (valasz == "1")
            {
                DecryptMenu();
            }
            else if (valasz == "2")
            {
                Main();
            }
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

        static string Decryptor(string szoveg, int kodSzam)
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

                    // Visszafelé toljuk el, figyelve, hogy ha negatív lesz, akkor az abc végéről induljon
                    int ujIndex = (eredetiIndex - eltol) % abc.Length;
                    if (ujIndex < 0)
                        ujIndex += abc.Length;

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

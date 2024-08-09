using System.Diagnostics;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string test = "";

            for (int i = 0; i < 15000; i++)
            {
                test += "d";
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //string s = test[0].ToString().ToUpper();
            //string p = test.Substring(1);

            char[] Caractere = new char[test.Length];
            Caractere[0] = (char)(test[0] & ~(32));
            for (int Index = 1; Index < test.Length; Index++)
            {
                Caractere[Index] = (char)(test[Index] | 32);
            }

            var Prenom = new string(Caractere);

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }
    }
}

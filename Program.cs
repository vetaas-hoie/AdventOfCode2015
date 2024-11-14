using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace AdventOfCode
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Console.WriteLine("Reading File: ");
            //string[] a = (string[])File.ReadAllLines("C:\\Users\\avetaash\\source\\repos\\AdventOfCode\\text.txt");
            //string[] a = (string[])File.ReadAllLines(Directory.GetCurrentDirectory() + "\\..\\..\\text.txt");
            //Console.WriteLine("Total lines: " + a.Length);
            Console.Write("Type secret key: ");
            string a = Console.ReadLine();
            Console.WriteLine("Lowest hash with five leading zeros: " + a + FindHash(a));

            Console.ReadKey();
        }

        private static int FindHash(string a)
        {
            int i = 0;
            string hexhash = "";
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                while (!hexhash.StartsWith("000000")) //changed to 6 zeroes for part 2
                {
                    byte[] input = System.Text.Encoding.ASCII.GetBytes(a + i.ToString());
                    byte[] hashbytes = md5.ComputeHash(input);

                    hexhash = Convert.ToHexString(hashbytes);
                    if (i % 10000 == 0)
                    {
                        Console.WriteLine(i);
                    }
                    i++;
                }
            }



            return i - 1;
        }

    }
}
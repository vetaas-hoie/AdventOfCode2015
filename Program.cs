
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace AdventOfCode
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Reading File: ");
            //string[] a = (string[])File.ReadAllLines("C:\\Users\\avetaash\\source\\repos\\AdventOfCode\\text.txt");
            string[] a = (string[])File.ReadAllLines(Directory.GetCurrentDirectory() + "\\..\\..\\..\\text.txt");
            Console.WriteLine("Total lines: " + a.Length);
            int total = 0;
            int total2 = 0;
            foreach (string s in a) {
                total += Count(s);
                total -= CountParsed(s);

                total2 += CountExpanded(s)+2;
                total2 -= Count(s);
                
            }

            Console.WriteLine("Part1 Total: " + total);
            Console.WriteLine("Part2 Total: " + total2);
          
        }


        static int Count(string a) {
            Console.WriteLine("Raw: " + a + " " + a.Length);
            return a.Length;
        }

        static int CountParsed(string a) {
            string b = Regex.Unescape(a.Substring(1,a.Length-2));
            Console.WriteLine("Parsed: " + b + " - " + b.Length);
            return b.Length;

        }

        static int CountExpanded(string a)
        {
            var sb = new StringBuilder();

            foreach (char c in a)
            {
                switch (c)
                {
                    case '\n':
                        sb.Append("\\n");
                        break;
                    case '\t':
                        sb.Append("\\t");
                        break;
                    case '\r':
                        sb.Append("\\r");
                        break;
                    case '\\':
                        sb.Append("\\\\");
                        break;
                    case '\"':
                        sb.Append("\\\"");
                        break;
                    case '\'':
                        sb.Append("\\\'");
                        break;
                    default:
                        if (char.IsControl(c)) // Handle other control characters as Unicode
                        {
                            sb.Append($"\\u{(int)c:X4}");
                        }
                        else
                        {
                            sb.Append(c);
                        }
                        break;
                }
            }
            Console.WriteLine("Expanded: " + sb + " - " + sb.Length);
            return sb.Length;
        }

    }

   

}

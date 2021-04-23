using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppGC
{
    public class Program
    {
        private static IEnumerable<int> GetNumbers(int numbers)
        {
            for (int i = 0; i < numbers; i++) yield return i;
        }

        public string[] Strings;

        private static void Main(string[] args)
        {
            var p = new Program
            {
                Strings = GetNumbers(200000)
                    .Select(v => $"{v:X}")
                    .ToArray()
            };
            Console.WriteLine("Start!");

            //var item1 = p.AllocByStringContact();
            //var item2 = p.AllocByStringBuilderConcat();
            //var item3 = p.AllocByStringBuilderConcatAndExcpt();

            Console.WriteLine("Klart!");
        }

        public string AllocByStringContact()
        {
            string anewstring = string.Empty;
            
            for (int i = 0; i < 100000; i++)
            {
                anewstring += Strings[i];
            }

            return anewstring;
        }

        public string AllocByStringBuilderConcat()
        {
            StringBuilder anewstring = new StringBuilder();

            for (int i = 0; i < 200000; i++)
            {
                anewstring.Append(Strings[i]);
            }
            return anewstring.ToString();
        }

        public string AllocByStringBuilderConcatAndExcpt()
        {
            StringBuilder anewstring = new StringBuilder();

            for (int i = 0; i < 2000; i++)
            {
                try
                {
                    anewstring.Append(Strings[i]);
                    throw new Exception("AAAAAAAAAAAAAAAAAAAAAA!!!!!!");
                }
                catch
                {
                    // ignored
                }
            }

            return anewstring.ToString();
        }
    }
}

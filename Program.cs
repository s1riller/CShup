using System;
using System.Text.RegularExpressions;

namespace program
{
    class Program
    {
        static void Main(string[] args)
        {
            Program.Calc("4+32+6 51");
        }
         static void Calc(string str) {
            string[] data = toData(str);
            foreach (string s in data)
            {
                //Console.WriteLine(s, "\n");
            }
        }

        static string[] toData(string str)
        {
            string[] data = str.Split("");

          
            foreach (string el in data)
            {
                
                    Console.WriteLine(el+" el");
            
            }
            //" /[^+\\d] / g"
            return data;

        }

     
    }
}
using System;
using System.Text.RegularExpressions;

namespace program
{
    class Program
    {
        public static bool zeroMessageFlag = true;
        public static ConsoleKey key = ConsoleKey.Enter;

        static void Main(string[] args)
        {
            while (key == ConsoleKey.Enter)
            {
                Run();
                Console.Clear();
            }
            Console.ReadKey();
        }

        static void Run()
        {
            var obj = Console.ReadLine().Split(' ');
            var elems = new List<object>();

            foreach (var elem in obj) elems.Add(elem);
            for(int i = 0; i<obj.Length; i++)
            {
                double num = 0;
                bool isDigit = double.TryParse(obj[i], out num);
                if (isDigit) elems[i] = num;
            }
            HardMoveLoop(elems);
            EasyMoveLoop(elems);
            Console.WriteLine("Результат: {0}", elems[0]);
            Console.WriteLine("Нажмите Enter чтобы продолжить");
            key = Console.ReadKey().Key;
        }

        private static void HardMoveLoop(List<object> elems)
        {
            while (true)
            {
                if (elems.Contains("*") || elems.Contains("/"))
                {
                    if (elems.Contains("*") && elems.Contains("/"))
                    {
                        if (elems.IndexOf("*") > elems.IndexOf("/")) Division(elems);
                        else if (elems.IndexOf("*") < elems.IndexOf("/")) Multiplication(elems);
                    }
                    else if (elems.Contains("*")) Multiplication(elems);
                    else if (elems.Contains("/")) Division(elems);
                    continue;
                }
                else break;
                }
        }


        private static void EasyMoveLoop(List<object> elems)
        {
            while (true) {
                if (elems.Contains("+") || elems.Contains("-"))
                {
                    if (elems.Contains("+") && elems.Contains("-"))
                    {
                        if (elems.IndexOf("+") > elems.IndexOf("-")) Substraction(elems);
                        else if (elems.IndexOf("+") < elems.IndexOf("-")) Addition(elems);
                    }
                    else if (elems.Contains("+")) Addition(elems);
                    else if (elems.Contains("-")) Substraction(elems);
                    continue;
                }
                else break;
            }
        }

       

        private static void Multiplication(List<object> elems)
        {
            double addNum = (double)elems[(elems.IndexOf("*")) - 1] * (double)elems[(elems.IndexOf("*")) + 1];
            elems.Insert(elems.IndexOf("*") - 1, addNum);
            elems.RemoveAt(elems.IndexOf("*") - 1);
            elems.RemoveAt(elems.IndexOf("*") + 1);
            elems.RemoveAt(elems.IndexOf("*"));
        }

        private static void Division(List<object> elems)
        {
            if ((double)elems[elems.IndexOf("/")+1]== 0 && zeroMessageFlag)
            {
                Console.WriteLine("На ноль делить нельзя!");
                zeroMessageFlag = false;
            }
            else
            {
                double addNum = (double)elems[(elems.IndexOf("/")) - 1] / (double)elems[(elems.IndexOf("/")) + 1];
                elems.Insert(elems.IndexOf("/") - 1, addNum);
                elems.RemoveAt(elems.IndexOf("/") - 1);
                elems.RemoveAt(elems.IndexOf("/") + 1);
                elems.RemoveAt(elems.IndexOf("/"));
            }
        }

        private static void Addition(List<object> elems)
        {
            double addNum = (double)elems[(elems.IndexOf("+")) - 1] + (double)elems[(elems.IndexOf("+")) + 1];
            elems.Insert(elems.IndexOf("+") - 1, addNum);
            elems.RemoveAt(elems.IndexOf("+") - 1);
            elems.RemoveAt(elems.IndexOf("+") + 1);
            elems.RemoveAt(elems.IndexOf("+"));
        }

        private static void Substraction(List<object> elems)
        {
            double addNum = (double)elems[(elems.IndexOf("-")) - 1] - (double)elems[(elems.IndexOf("-")) + 1];
            elems.Insert(elems.IndexOf("-") - 1, addNum);
            elems.RemoveAt(elems.IndexOf("-") - 1);
            elems.RemoveAt(elems.IndexOf("-") + 1);
            elems.RemoveAt(elems.IndexOf("-"));
        }
    }


     
       
    
}
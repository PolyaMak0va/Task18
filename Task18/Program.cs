using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task18
{
    class Program
    {
        // Дана строка, содержащая скобки трёх видов(круглые, квадратные и фигурные) и любые другие символы.
        // Проверить, корректно ли в ней расставлены скобки. Например, в строке ] скобки расставлены корректно, а в строке([]] — нет.
        // Указание: задача решается однократным проходом по символам заданной строки слева направо; для каждой открывающей скобки в строке
        // в стек помещается соответствующая закрывающая, каждая закрывающая скобка в строке должна соответствовать скобке из вершины стека
        // (при этом скобка с вершины стека снимается); в конце прохода стек должен быть пуст.
        static void Main(string[] args)
        {
            Console.Write("Введите последовательность скобок: ");
            string s = Convert.ToString(Console.ReadLine());
            Stack<string> myStack = new Stack<string>();
            myStack.Push("(");
            myStack.Push("{");
            myStack.Push("[");
            myStack.Push(")");
            myStack.Push("}");
            myStack.Push("]");
            Console.WriteLine("\nmyStack: ");
            Console.WriteLine("\tCount:    {0}", myStack.Count);
            Console.Write("\tValues:");
            PrintValues(myStack);
            Console.WriteLine(Brackets(s) == -1 ? "\nСкобки расставлены корректно" : Brackets(s).ToString());
            Console.ReadKey();
        }
        public static void PrintValues(IEnumerable myCollection)
        {
            foreach (Object obj in myCollection)
            {
                Console.Write("    {0}", obj);               
            }
            Console.WriteLine();
        }
        static int Brackets(string s)
        {
            string brackets = "[{(]})";
            Stack<char> myStack2 = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                int f = brackets.IndexOf(s[i]);

                if (f >= 0 && f <= 2)
                    myStack2.Push(s[i]);

                if (f > 2)
                {
                    if (myStack2.Count == 0 || myStack2.Pop() != brackets[f - 3])
                    {
                        return i;
                    }                       
                }
            }
            if (myStack2.Count != 0)
            {
                return s.LastIndexOf(myStack2.Pop());
            }
            else
            {
                return -1;
            }
        }
    }
}

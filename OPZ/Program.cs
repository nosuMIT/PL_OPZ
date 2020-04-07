using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OPZ
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> d = new Dictionary<char, int>();
            d.Add('+', 1);
            d.Add('-', 1);
            d.Add('*', 2);
            d.Add('/', 2);
            d.Add('^', 3);
            /*foreach(var el in d)
                Console.WriteLine(el + " d[" + el.Key+"]="+ el.Value);
            if (d.ContainsKey('^'))
                Console.WriteLine(d['^']);
            else
                Console.WriteLine("не такого");
                */
            // string s = "(3+8*4)/(7*4-2)";
            string s = Console.ReadLine();
            Console.WriteLine(s);
            Queue<char> q = new Queue<char>();
            Stack<char> st = new Stack<char>();
            foreach (var c in s)
            {
                if (c >= '0' && c <= '9')
                {
                    q.Enqueue(c);
                }
                else
                {
                    if (c == '(')
                        st.Push(c);
                    else if (c == ')')
                    {
                        while (st.Peek() != '(')
                        {
                            q.Enqueue(st.Pop());
                        }
                        // удаляем скобку 
                        st.Pop();
                    }
                    else
                    // приоритет операций
                    {
                        while(st.Count != 0 && (d[st.Peek()] >= d[c]))
                                q.Enqueue(st.Pop());
                        st.Push(c);  
                    }
                }
            }
            while (st.Count != 0)
                q.Enqueue(st.Pop());
            foreach(var el in q)
                Console.Write(el);
               
        }
    }
}

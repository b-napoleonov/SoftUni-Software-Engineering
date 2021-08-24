using System;
using System.Collections.Generic;
using System.Text;

namespace _09._SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> num = new Stack<int>();
            Stack<string> txt = new Stack<string>();
            StringBuilder text = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split();
                int command = int.Parse(commands[0]);

                switch (command)
                {
                    case 1:

                        num.Push(1);
                        string sub = commands[1];
                        txt.Push(sub);
                        text.Append(sub);

                        break;

                    case 2:

                        num.Push(2);
                        int count = int.Parse(commands[1]);
                        txt.Push(text.ToString().Substring(text.Length - count, count));
                        text.Remove(text.Length - count, count);

                        break;

                    case 3:

                        int index = int.Parse(commands[1]);
                        Console.WriteLine(text[index - 1]);

                        break;

                    case 4:

                        int buffer = 0;

                        if (num.TryPop(out buffer))
                        {
                            if (buffer == 1)
                            {
                                text.Remove(text.Length - txt.Peek().Length, txt.Pop().Length);
                            }
                            else
                            {
                                text.Append(txt.Pop());
                            }
                        }
                        else
                        {
                            continue;
                        }

                        break;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputList = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            string input = Console.ReadLine();

            while (input != "3:1")
            {
                string action = input.Split()[0];
                int startIndex = int.Parse(input.Split()[1]);
                int endIndex = int.Parse(input.Split()[2]);

                switch (action)
                {
                    case "merge":

                        if (startIndex < 0)
                        {
                            startIndex = 0;
                        }
                        if (endIndex > inputList.Count - 1)
                        {
                            endIndex = inputList.Count - 1;
                        }

                        for (int i = startIndex + 1; i <= endIndex; i++)
                        {
                            inputList[startIndex] += inputList[startIndex + 1];
                            inputList.RemoveAt(startIndex + 1);
                        }
                        break;

                    case "divide":

                        string devidedElement = inputList[startIndex];
                        inputList.RemoveAt(startIndex);

                        int partSize = devidedElement.Length / endIndex;
                        int reminder = devidedElement.Length % endIndex;

                        List<string> tmpData = new List<string>();

                        for (int i = 0; i < endIndex; i++)
                        {
                            string tmpString = "";

                            for (int j = 0; j < partSize; j++)
                            {
                                tmpString += devidedElement[(i * partSize) + j];
                            }

                            if (i == endIndex - 1 && reminder != 0)
                            {
                                tmpString += devidedElement.Substring(devidedElement.Length - reminder);
                            }

                            tmpData.Add(tmpString);
                        }

                        inputList.InsertRange(startIndex, tmpData);


                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', inputList));
        }
    }
}

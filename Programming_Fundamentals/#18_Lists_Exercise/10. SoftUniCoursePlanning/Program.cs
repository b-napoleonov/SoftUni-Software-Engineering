using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            while (input != "course start")
            {

                string command = input.Split(":")[0];
                string lessonTitle = input.Split(":")[1];

                switch (command)
                {
                    case "Add":

                        if (!lessons.Contains(lessonTitle))
                        {
                            lessons.Add(lessonTitle);
                        }

                        break;

                    case "Insert":

                        int index = int.Parse(input.Split(":")[2]);

                        if (!lessons.Contains(lessonTitle))
                        {
                            lessons.Insert(index, lessonTitle);
                        }

                        break;

                    case "Remove":

                        lessons.Remove(lessonTitle);

                        break;

                    case "Exercise":

                        string buffer = lessonTitle + "-Exercise";

                        if (lessons.Contains(lessonTitle))
                        {
                            if (!lessons.Contains(buffer))
                            {
                                int currentIndex = lessons.IndexOf(lessonTitle);
                                lessons.Insert(currentIndex + 1, buffer);
                            }
                            else
                            {
                                input = Console.ReadLine();
                                continue;
                            }
                        }
                        else
                        {
                            lessons.Add(lessonTitle);
                            int currentIndex = lessons.IndexOf(lessonTitle);
                            lessons.Insert(currentIndex + 1, buffer);
                        }

                        break;

                    case "Swap":

                        string secondLesson = input.Split(":")[2];
                        int firstIndex = lessons.IndexOf(lessonTitle);
                        int secondIndex = lessons.IndexOf(secondLesson);

                        if (lessons.Contains(lessonTitle) && lessons.Contains(secondLesson))
                        {
                            lessons[firstIndex] = secondLesson;
                            lessons[secondIndex] = lessonTitle;
                        }
                        if (lessons.Contains(lessonTitle + "-Exercise") && lessons.Contains(lessons[firstIndex]))
                        {
                            firstIndex = lessons.IndexOf(lessonTitle);
                            lessons.Remove(lessonTitle + "-Exercise");
                            lessons.Insert(firstIndex + 1, lessonTitle + "-Exercise");
                        }
                        else if (lessons.Contains(secondLesson + "-Exercise") && lessons.Contains(lessons[secondIndex]))
                        {
                            secondIndex = lessons.IndexOf(secondLesson);
                            lessons.Remove(secondLesson + "-Exercise");
                            lessons.Insert(secondIndex + 1, secondLesson + "-Exercise");
                        }

                        break;

                }

                input = Console.ReadLine();
            }

            for (int i = 0; i < lessons.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{lessons[i]}");
            }
        }
    }
}

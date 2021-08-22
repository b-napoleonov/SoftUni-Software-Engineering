using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Articles2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Article> list = new List<Article>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");

                string title = input[0];
                string content = input[1];
                string author = input[2];

                list.Add(new Article(title, content, author));
            }

            string command = Console.ReadLine();

            switch (command)
            {
                case "title":

                    list = list.OrderBy(x => x.Title).ToList();

                    break;

                case "content":

                    list = list.OrderBy(x => x.Content).ToList();

                    break;

                case "author":

                    list = list.OrderBy(x => x.Author).ToList();

                    break;
            }

            foreach (var article in list)
            {
                Console.WriteLine(article);
            }
        }
    }
    public class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}

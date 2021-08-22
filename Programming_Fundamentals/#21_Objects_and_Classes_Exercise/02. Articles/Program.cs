using System;

namespace _02._Articles
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine().Split(", ");

            Article article = new Article(input[0], input[1], input[2]);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split(": ");

                string command = commands[0];
                string value = commands[1];

                switch (command)
                {
                    case "Edit":

                        article.Edit(value);

                        break;

                    case "ChangeAuthor":

                        article.ChangeAuthor(value);

                        break;

                    case "Rename":

                        article.Rename(value);

                        break;
                }
            }

            Console.WriteLine(article);
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

        public void Edit(string content)
        {
            Content = content;
        }

        public void ChangeAuthor(string author)
        {
            Author = author;
        }

        public void Rename(string title)
        {
            Title = title;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}

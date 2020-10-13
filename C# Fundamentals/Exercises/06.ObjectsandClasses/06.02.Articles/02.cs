using System;

namespace _06._02.Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] article = Console.ReadLine().Split(", ");

            Article art = new Article(article[0], article[1], article[2]);

            int numCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numCommands; i++)
            {
                string[] command = Console.ReadLine().Split(": ");

                if (command[0] == "Edit")
                {
                    art.Edit(command[1]);
                }
                else if (command[0] == "ChangeAuthor")
                {
                    art.ChangeAuthor(command[1]);
                }
                else if (command[0] == "Rename")
                {
                    art.Rename(command[1]);
                }
                else
                {
                    Console.WriteLine("Unknown Command");
                }
            }

            Console.WriteLine(art.ToString());

        }
    }


    class Article
    {
        public Article(string _Title, string _Content, string _Author)
        {
            this.Title = _Title;
            this.Content = _Content;
            this.Author = _Author;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public void Edit(string newContent) { Content = newContent; }
        public void ChangeAuthor(string newAuthor) { Author = newAuthor; }

        public void Rename(string newTitle) { Title = newTitle; }

        public override string ToString()
        {
            return $"{Title} - { Content}: {Author}";
        }

    }

}

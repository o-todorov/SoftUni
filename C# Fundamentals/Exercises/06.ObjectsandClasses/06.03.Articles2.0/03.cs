using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._03.Articles2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int articlesCount = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();

            for (int i = 0; i < articlesCount; i++)
            {
                string[] article = Console.ReadLine().Split(", ");

                articles.Add(new Article( article[0], article[1], article[2] ));
            }

            string compare = Console.ReadLine();

            List<Article> res = new List<Article>();

            if (compare == "title")
            {
                res = articles.OrderBy(art => art.Title).ToList();
            }
            else if (compare == "content")
            {
                res = articles.OrderBy(art => art.Content).ToList();
            }
            else if (compare == "author")
            {
                res = articles.OrderBy(art => art.Author).ToList();
            }

            foreach (var art in res)
            {
                Console.WriteLine(art.ToString());
            }


        }
    }


    class Article
    {
        public Article(string _Title,string _Content,string _Author) 
        {
            this.Title      = _Title;
            this.Content    = _Content;
            this.Author     = _Author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public override string ToString()
        {
            return $"{Title} - { Content}: {Author}";
        }

    }

}

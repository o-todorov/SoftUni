using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._10.SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            var users   = new Dictionary<string, User>();
            var langs   = new Dictionary<string, int>();

            string[] input;

            while((input=Console.ReadLine().Split("-"))[0]!= "exam finished")
            {
                string  user    = input[0];

                if (input[1] == "banned")
                {
                    users[user].banned = true;
                }
                else
                {
                    string  lang    = input[1];
                    int     points  = int.Parse(input[2]);

                    if (!users.ContainsKey(user))
                    {
                        users[user] = new User(user, new Exam(lang, points));
                    }
                    else
                    {
                        users[user].AddExam(new Exam(lang, points));
                    }

                    if (!langs.ContainsKey(lang))
                    {
                        langs[lang] = 1;
                    }
                    else
                    {
                        langs[lang]++;
                    }
                }
            }

            Console.WriteLine("Results:");

            var toPrint = users.Values.Where(u => !u.banned)
                                     .ToDictionary(u => u.Name, u => u.GetPoints)
                                     .OrderByDescending(u => u.Value)
                                     .ThenBy(u => u.Key);

            foreach (var user in toPrint)
            {
                Console.WriteLine($"{user.Key} | {user.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var lang in langs.OrderByDescending(l => l.Value).ThenBy(l => l.Key))
            {
                Console.WriteLine($"{lang.Key} - {lang.Value}");
            }

        }
    }
    class Exam
    {
        public string  Language;
        public int     Points;
        public Exam(string language, int points)
        {
            Language = language;
            Points   = points;
        }
    }
    class User
    {
        public User(string name, Exam exam)
        {
            Name        = name;
            this.Exams  = new List<Exam>() { exam };
            banned      = false;
        }

        private List<Exam>   Exams;
        public string       Name;
        public bool         banned;
        public int          GetPoints
        {
            get
            {
                return Exams.Sum(e => e.Points);
            }
        }

        public void AddExam(Exam exam)
        {
            var ex = this.Exams.Find(e => e.Language == exam.Language);

            if (ex != null)
            {
                ex.Points = Math.Max(ex.Points, exam.Points);
            }
            else
            {
                this.Exams.Add(exam);
            }
        }
    }
}

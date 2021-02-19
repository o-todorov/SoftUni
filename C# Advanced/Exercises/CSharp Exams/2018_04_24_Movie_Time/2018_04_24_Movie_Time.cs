using System;
using System.Collections.Generic;
using System.Linq;

namespace _2018_04_24_Movie_Time
{
    class Program
    {
        static void Main(string[] args)
        {
            string genre = Console.ReadLine();
            string duration = Console.ReadLine();
            var movies = new List<Movie>();
            string movieInfo;

            while ((movieInfo = Console.ReadLine()) != "POPCORN!")
            {
                var info = movieInfo.Split("|");
                movies.Add(new Movie(info[0], info[1], GetSeconds(info[2])));
            }

            string totalPlayTime = GetTimeFormated(movies.Sum(m => m.Duration));
            var comp = new MovieComparer(duration == "Short");
            movies = movies.Where(m => m.Genre == genre)
                           .OrderBy(m => m, comp)
                           .ToList();
            Movie chosenMovie = new Movie();

            foreach (var movie in movies)
            {
                Console.WriteLine(movie.Name);

                if (Console.ReadLine() == "Yes")
                {
                    chosenMovie = movie;
                    break;
                }
            }

            Console.WriteLine($"We're watching {chosenMovie.Name} - {GetTimeFormated(chosenMovie.Duration)}");
            Console.WriteLine($"Total Playlist Duration: {totalPlayTime}");
        }

        private static string GetTimeFormated(int time)
        {
            int h = time / 3600;
            time = time % 3600;
            int m = time / 60;
            int s = time % 60;

            var ret = $"{h:d2}:{m:d2}:{s:d2}";
            return $"{h:d2}:{m:d2}:{s:d2}";
        }

        private static int GetSeconds(string time)
        {
            return int.Parse(time[0..2]) * 3600 +
                   int.Parse(time[3..5]) * 60 +
                   int.Parse(time[6..8]);
        }
    }

    public class Movie
    {
        public Movie() { }
        public Movie(string name, string jenre, int duration)
        {
            Name = name;
            Genre = jenre;
            Duration = duration;
        }

        public string Name { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
        public override string ToString()
        {
            return $"{Name} - {Duration}";
        }
    }
    public class MovieComparer : IComparer<Movie>
    {
        public bool Ascending { get; private set; }
        public MovieComparer(bool asc)
        {
            Ascending = asc;
        }
        public int Compare(Movie x, Movie y)
        {
            var l = x as Movie;
            var r = y as Movie;
            var result = Ascending ? l.Duration.CompareTo(r.Duration) :
                                     r.Duration.CompareTo(l.Duration);
            return result != 0 ? result : l.Name.CompareTo(r.Name);
        }
    }
}

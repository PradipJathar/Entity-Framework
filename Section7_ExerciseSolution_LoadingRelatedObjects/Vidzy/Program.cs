

using System;
using System.Linq;
using System.Data.Entity;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            VidzyContext db = new VidzyContext();


            // Note: Inspect the queries ran by Entity Framework using SQL Profiler to see results.


            // Lazy Loading:

            // To enable lazy loading, you need to declare navigation properties as virtual. Look at the Video class.
            // Lazy Loading creates N + 1 problem. It exicutes N no (no. of Genre) of queries to load Genre and 1 query to load videos.

            Console.WriteLine("Lazy Loading:");

            var videos = db.Videos.ToList();

            foreach (var video in videos)
            {
                Console.WriteLine($"{video.Name} - {video.Genre.Name}");
            }


            // Eager Loading:

            // Use Include to solve the N + 1 problem. It use Inner Join on Genre table and give result in one query.

           Console.WriteLine("\nEager Loading:");

            var videosWithEagerLoading = db.Videos.Include(v => v.Genre).ToList();

            foreach (var video in videosWithEagerLoading)
            {
                Console.WriteLine($"{video.Name} - {video.Genre.Name}");
            }


            // Expect Loading:

            // Use Load on Genres after retrieving the Videos. It exicutes 2 queries 1 for retrieve Videos and 1 for load Genres.
            // want to see expicit loading in action, comment out the lazy loading and eager loading.

            Console.WriteLine("\nExpect Loading:");

            var videosWithExpectLoading = db.Videos.ToList();

            db.Genres.Load();

            foreach (var video in videosWithExpectLoading)
            {
                Console.WriteLine($"{video.Name} - {video.Genre.Name}");
            }

        }
    }
}

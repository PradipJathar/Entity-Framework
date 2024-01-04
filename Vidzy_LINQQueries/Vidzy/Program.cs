using System;
using System.Linq;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            VidzyContext db = new VidzyContext();


            // Action movies sorted by name:

            Console.WriteLine("1. Action movies sorted by name:");

            var actionMovies = db.Videos.Where(m => m.Genre.Name == "Action").OrderBy(m => m.Name);

            foreach (var movie in actionMovies)
            {
                Console.WriteLine(movie.Name);
            }



            // Gold drama movies sorted by release date (newest first):

            Console.WriteLine("\n2. Gold drama movies sorted by release date (newest first):");

            var goldDramaMovies = db.Videos.Where(m => m.Genre.Name == "Drama" && m.Classification == Classification.Gold)
                                           .OrderByDescending(m => m.ReleaseDate);

            foreach (var movie in goldDramaMovies)
            {
                Console.WriteLine(movie.Name);
            }



            // All movies projected into an anonymous type with two properties (MovieName and Genre):

            Console.WriteLine("\n3. All movies projected into an anonymous type with two properties (MovieName and Genre):");

            var allMovies = db.Videos.Select(m => new { MovieName = m.Name, Genre = m.Genre});

            foreach (var movie in allMovies)
            {
                Console.WriteLine(movie.MovieName);
            }



            // All movies grouped by their classification:

            Console.WriteLine("\n4. All movies grouped by their classification:");

            var moviesGroups = db.Videos.GroupBy(m => m.Classification)
                                        .Select(g => new
                                        {
                                            classification = g.Key.ToString(),
                                            movies = g.OrderBy(m => m.Name)
                                        });

            foreach (var group in moviesGroups)
            {
                Console.WriteLine($"Classification: {group.classification}");

                foreach (var movie in group.movies)
                {
                    Console.WriteLine($"\t{movie.Name}");
                }
            }



            // List of classifications sorted alphabetically and count of videos in them:

            Console.WriteLine("\n5. List of classifications sorted alphabetically and count of videos in them:");

            var classifications = db.Videos.GroupBy(m => m.Classification)
                                                         .Select(g => new
                                                         {
                                                             classification = g.Key.ToString(),
                                                             moviesCount = g.Count()
                                                         }).OrderBy(c => c.classification);

            foreach (var group in classifications)
            {
                Console.WriteLine($"{group.classification} ({group.moviesCount})");
            }



            // List of genres and number of videos they include, sorted by the number of videos:

            Console.WriteLine("\n6. List of genres and number of videos they include, sorted by the number of videos:");

            var genres = db.Genres.GroupJoin(db.Videos, gen => gen.Id, m => m.GenreId, (genre, movies) => new 
                                  {
                                      name = genre.Name,
                                      moviesCount = movies.Count()
                                  }).OrderByDescending(g => g.moviesCount);

            foreach (var genre in genres)
            {
                Console.WriteLine($"{genre.name} ({genre.moviesCount})");
            }
        }
    }
}

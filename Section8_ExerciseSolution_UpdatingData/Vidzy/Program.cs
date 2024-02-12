
using System;
using System.Linq;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {

            // 1 - Add a new video called “Terminator 1” with genre Action, release date 26 Oct, 1984, and Silver classification. Ensure the Action genre is not duplicated in the Genres table.

            Video video = new Video
            {
                Name = "Terminator 1",
                GenreId = 2,
                Classification = Classification.Silver,
                ReleaseDate = new DateTime(1984, 10, 26)
            };

            AddVideo(video);


            // 2 - Add two tags “classics” and “drama” to the database. Ensure if your method is called twice, these tags are not duplicated.

            AddTags("classics", "drama");


            // 3 - Add three tags “classics”, “drama” and “comedy” to the video with Id 1 (The Godfather).
            // Ensure the “classics” and “drama” tags are not duplicated in the Tags table. Also, ensure that if your method is called twice, these tags are not duplicated in VideoTags table.

            AddTagsToVideo(1, "classics", "drama", "comedy");


            // 4 - Remove the “comedy” tag from the the video with Id 1 (The Godfather).

            RemoveTagsFormVideo(1, "comedy");


            // 5 - Remove the video with Id 1 (The Godfather).

            RemoveVideo(1);


            // 6 - Remove the genre with Id 2 (Action). Ensure all courses with this genre are deleted from the database.

            //RemoveGenre(2, true);

        }


        public static void AddVideo(Video video)
        {
            using (var db = new VidzyContext())
            {
                db.Videos.Add(video);
                db.SaveChanges();
            }
        }


        public static void AddTags(params string[] tagNames)
        {
            using (var db =  new VidzyContext())
            {
                var tags = db.Tags.Where(t => tagNames.Contains(t.Name)).ToList();

                foreach (var tagName in tagNames)
                {
                    if (!tags.Any(t => t.Name.Equals(tagName, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        db.Tags.Add(new Tag { Name = tagName });
                    }
                }

                db.SaveChanges();
            }
        }


        public static void AddTagsToVideo(int videoId, params string[] tagNames)
        {
            using (var db = new VidzyContext())
            {
                var tags = db.Tags.Where(t => tagNames.Contains(t.Name)).ToList();

                foreach (var tagName in tagNames)
                {
                    if (!tags.Any(t => t.Name.Equals(tagName, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        db.Tags.Add(new Tag { Name = tagName });
                    }
                }

                var video = db.Videos.Single(v => v.Id == videoId);

                tags.ForEach(t => video.AddTag(t));

                db.SaveChanges();
            }
        }
    
    
        public static void RemoveTagsFormVideo(int videoId, params string[] tagNames)
        {
            using (var db = new VidzyContext())
            {
                var tags = db.Tags.Where(t => tagNames.Contains(t.Name)).ToList();

                var video = db.Videos.Single(v => v.Id == videoId);

                foreach (var tagName in tagNames)
                {
                    video.RemoveTag(tagName);
                }

                db.SaveChanges();
            }
        }
    
        
        public static void RemoveVideo(int videoId)
        {
            using (var db = new VidzyContext())
            {
                var video = db.Videos.Single(v => v.Id == videoId);

                if (video != null)
                {
                    db.Videos.Remove(video);
                    db.SaveChanges(); 
                }
            }
            
        }
    
    
        //public static void RemoveGenre(int genreId, bool enforceDeletingVideos)
        //{
        //    using (var db = new VidzyContext())
        //    {
        //        var genre = db.Genres.Include(g => g.Videos).SingleOrDefault(g => g.Id == genreId);

        //        if (genre != null)
        //        {
        //            if (enforceDeletingVideos)
        //            {
        //                db.Videos.RemoveRange(genre.Videos);
        //            }

        //            db.Genres.Remove(genre);
        //            db.SaveChanges();
        //        }
        //    }
        //}

    }
}

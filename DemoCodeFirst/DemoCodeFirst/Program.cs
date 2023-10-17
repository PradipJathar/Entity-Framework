using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCodeFirst
{

    class Program
    {
        static void Main(string[] args)
        {
            BlogDbContext db = new BlogDbContext();

            Post post = new Post()
            {
                DatePublished = DateTime.Now,
                Title = "Title",
                Body = "Body"
            };

            db.Posts.Add(post);
            db.SaveChanges();
        }
    }
}

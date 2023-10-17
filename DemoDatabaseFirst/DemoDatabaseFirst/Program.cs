using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDatabaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseFirstDemoEntities db = new DatabaseFirstDemoEntities();

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

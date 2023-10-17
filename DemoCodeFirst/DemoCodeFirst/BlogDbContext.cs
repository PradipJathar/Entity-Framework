using System.Data.Entity;

namespace DemoCodeFirst
{
    public class BlogDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
    }
}

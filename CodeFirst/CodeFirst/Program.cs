using System;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class PlutoCodeFirstDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public PlutoCodeFirstDbContext() : base("name=DefaultConnection")
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

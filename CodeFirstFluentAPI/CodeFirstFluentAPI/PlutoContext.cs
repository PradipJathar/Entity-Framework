using CodeFirstFluentAPI.Configurations;
using System.Data.Entity;

namespace CodeFirstFluentAPI
{
    public class PlutoContext : DbContext
    {
        public PlutoContext() : base("name=PlutoContext")
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Tag> Tags { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CourseConfigurations());
        }

    }
}
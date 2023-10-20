using System.Data.Entity;

namespace Section4_And_5_ExerciseSolution_CodeFirst
{
    public class VidzyCodeFirstDbContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public VidzyCodeFirstDbContext() : base("name=DefaultConnection")
        {

        }
    }
}

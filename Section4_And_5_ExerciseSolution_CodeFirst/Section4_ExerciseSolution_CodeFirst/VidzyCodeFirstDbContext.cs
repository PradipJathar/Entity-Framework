using Section4_And_5_ExerciseSolution_CodeFirst.EntityConfigurations;
using System.Data.Common;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new VideoConfiguratitons());
            modelBuilder.Configurations.Add(new GenreConfiguratitons());
        }
    }
}

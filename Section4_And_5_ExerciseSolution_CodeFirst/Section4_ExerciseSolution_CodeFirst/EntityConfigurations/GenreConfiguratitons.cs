using System.Data.Entity.ModelConfiguration;

namespace Section4_And_5_ExerciseSolution_CodeFirst.EntityConfigurations
{
    public class GenreConfiguratitons : EntityTypeConfiguration<Genre>
    {
        public GenreConfiguratitons()
        {
            Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section4_And_5_ExerciseSolution_CodeFirst.EntityConfigurations
{
    public class VideoConfiguratitons : EntityTypeConfiguration<Video>
    {
        public VideoConfiguratitons()
        {
            Property(v => v.Name)
                .IsRequired()
                .HasMaxLength(255);

            HasRequired(v => v.Genre)
                .WithMany(g => g.Videos)
                .HasForeignKey(v => v.GenreId);

            HasMany(v => v.Tags)
            .WithMany(t => t.Videos)
            .Map(m =>
            {
                m.ToTable("VideoTags");
                m.MapLeftKey("VideoId");
                m.MapRightKey("TagId");
            });

        }
    }
}

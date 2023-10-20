using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstFluentAPI.Configurations
{
    class CourseConfigurations : EntityTypeConfiguration<Course>
    {
        public CourseConfigurations()
        {
            // Convention for organizing Configurations
            // 1. Table override       --> eg. ToTable("tbl_Course");
            // 2. Primary key override --> eg. HasKay(c => c.Id);
            // 3. Property override
            // 4. Relationships 

            // Note: Sort each by alphabetical.


            // Property override

            Property(t => t.Description)
            .IsRequired()
            .HasMaxLength(2000);

            Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(255);


            // Relationships

            HasRequired(c => c.Author)
            .WithMany(a => a.Courses)
            .HasForeignKey(a => a.AuthorId)
            .WillCascadeOnDelete(false);

            HasRequired(c => c.Cover)
            .WithRequiredPrincipal(cv => cv.Course);

            HasMany(c => c.Tags)
            .WithMany(t => t.Courses)
            .Map(m =>
            {
                m.ToTable("CourseTags");
                m.MapLeftKey("CourseId");
                m.MapRightKey("TagId");
            });
        }
    }
}

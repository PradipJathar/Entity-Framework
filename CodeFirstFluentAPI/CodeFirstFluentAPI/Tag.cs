using System.Collections.Generic;

namespace CodeFirstFluentAPI
{
    public class Tag
    {

        public int Id { get; set; }

        public string Name { get; set; }      

        public ICollection<Course> Courses { get; set; }


        public Tag()
        {
            Courses = new HashSet<Course>();
        }
    }
}
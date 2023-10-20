using System.Collections.Generic;

namespace CodeFirstFluentAPI
{
    public class Author
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Course> Courses { get; set; }


        public Author()
        {
            Courses = new HashSet<Course>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            PlutoDbContext db = new PlutoDbContext();

            var courses = db.GetCourses();

            foreach (var course in courses)
            {
                Console.WriteLine(course.Title);
            }


            // Course course1 = new Course();
            // course1.Level = CourseLevel.Advanced;    // Enum 'CourseLevel' added as datatype of Course.Level in edmx

            Course course2 = new Course();
            course2.Level = Level.Advanced;             // Enum 'Level' added as datatype of Course.Level in edmx using external file. 
        }
    }
}

using System;
using System.Linq;
namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new PlutoContext();

            Introduction(db);

            LINQSyntax(db);

            LINQSyntax_Joins(db);

            LINQExtensionMethods(db);

            LINQExtensionMethods_Joins(db);

        }


        /***** Introduction to LINQ *****/
        public static void Introduction(PlutoContext db)
        {            
            Console.WriteLine("Introduction to LINQ");


            // LINQ Syntax

            Console.WriteLine("\nUsing LINQ Syntax:");

            var courses = from c in db.Courses
                          where c.Name.Contains("c#")
                          orderby c.Name
                          select c;

            foreach (var course in courses)
            {
                Console.WriteLine(course.Name);
            }


            // Extension Methods

            Console.WriteLine("\nUsing Extension Methods:");

            var courseList = db.Courses.Where(c => c.Name.Contains("c#"))
                                       .OrderBy(c => c.Name);

            foreach (var course in courseList)
            {
                Console.WriteLine(course.Name);
            }

            Console.WriteLine("\n****************************\n");
        }


        /***** LINQ Syntax *****/
        public static void LINQSyntax(PlutoContext db)
        {  
            Console.WriteLine("LINQ Syntax");


            Console.WriteLine("\nRestriction, Sorting, And Projection:");

            var courses1 = from c in db.Courses
                           where c.Author.Id == 1                                                // Restriction
                           orderby c.Level descending, c.Name                                    // Sorting
                           select new { Name = c.Name, Author = c.Author.Name };                 // Projection

            foreach (var course in courses1)
            {
                Console.WriteLine($"Course Name: {course.Name}, Author Name: {course.Author}");
            }


            Console.WriteLine("\nGrouping:");

            var groups = from c in db.Courses
                         group c by c.Level                                                     // Grouping                                
                         into g
                         select g;

            foreach (var group in groups)
            {
                Console.WriteLine($"Leval: {group.Key}, No. of Courses: {group.Count()}");      // Count - Aggregate Function
            }
        }


        /***** LINQ Syntax - Joins *****/
        public static void LINQSyntax_Joins(PlutoContext db)
        {
            // LINQ Joins:
            // 1. Inner Join
            // 2. Group Join    (Not using in SQL)
            // 3. Cross Join

            Console.WriteLine("\nLINQ Joins");

            // 1. Inner Join

            Console.WriteLine("\n1. Inner Join:");

            var courses = from c in db.Courses
                           join a in db.Authors on c.AuthorId equals a.Id               // Inner Join                         
                           select new { Name = c.Name, Author = a.Name };                 

            foreach (var course in courses)
            {
                Console.WriteLine($"Course Name: {course.Name}, Author Name: {course.Author}");
            }


            // 2. Group Join

            Console.WriteLine("\n2. Group Join:");

            var query = from a in db.Authors
                        join c in db.Courses on a.Id equals c.AuthorId into g           // Group Join                       
                        select new { AuthorName = a.Name, CoursesCount = g.Count() };

            foreach (var item in query)
            {
                Console.WriteLine($"Author Name: {item.AuthorName}, Courses Count: {item.CoursesCount}");
            }


            // 3. Cross Join

            Console.WriteLine("\n3. Cross Join:");

            var query1 = from a in db.Authors
                         from c in db.Courses                                             // Cross Join (Use 'from' instead of 'join' in second line).                     
                         select new { AuthorName = a.Name, CourseName = c.Name };

            foreach (var item in query1)
            {
                Console.WriteLine($"Author Name: {item.AuthorName}, Course Name: {item.CourseName}");   // one on one combination of every other and every course.
            }

        }



        /***** LINQ Extension Methods *****/
        public static void LINQExtensionMethods(PlutoContext db)
        {
            Console.WriteLine("LINQ Extension Methods");


            Console.WriteLine("\nRestriction, Sorting, Projection, Set Operators:");

            var tags = db.Courses.Where(c => c.Level == 1)                                                      // Restriction                                        
                                 .OrderByDescending(c => c.Name)                                                // Sorting
                                 .ThenByDescending(c => c.Level)
                                 //.Select(c => new { CourseName = c.Name, AuthorName = c.Author.Name })        // Projection
                                 .SelectMany(c => c.Tags)           // The SelectMany operator is used to project each element of a sequence to an IEnumerable and then flatten the resulting sequences into one sequence.              
                                 .Distinct();                       // Set Operators        

            foreach (var t in tags)
            {
                Console.WriteLine(t.Name);
            }


            Console.WriteLine("\nGrouping:");

            var groups = db.Courses.GroupBy(c => c.Level);

            foreach (var group in groups)
            {
                Console.WriteLine($"Kay : {group.Key}");

                foreach (var course in group)
                {
                    Console.WriteLine($"\t{course.Name}");
                }
            }

        }


        /***** LINQ Extension Methods - Joins *****/
        public static void LINQExtensionMethods_Joins(PlutoContext db)
        {
            // LINQ Joins:
            // 1. Inner Join
            // 2. Group Join    (Not using in SQL)
            // 3. Cross Join

            Console.WriteLine("\nLINQ Joins");

            // 1. Inner Join

            Console.WriteLine("\n1. Inner Join:");

            var courses = db.Courses.Join(db.Authors, c => c.AuthorId, a => a.Id, (course, author) => new 
            { 
                CourseName = course.Name, 
                AuthorName = author.Name 
            });

            foreach (var course in courses)
            {
                Console.WriteLine($"Course Name: {course.CourseName}, Author Name: {course.AuthorName}");
            }


            // 2. Group Join

            Console.WriteLine("\n2. Group Join:");

            var query = db.Authors.GroupJoin(db.Courses, a => a.Id, c => c.AuthorId, (author, courseList) => new 
            { 
                AuthorName = author.Name, 
                CourseList = courseList 
            });

            foreach (var item in query)
            {
                Console.WriteLine($"Author Name: {item.AuthorName}, Courses Count: {item.CourseList.Count()}");
            }


            // 3. Cross Join

            Console.WriteLine("\n3. Cross Join:");

            var query1 = db.Authors.SelectMany(a => db.Courses, (author, course) => new             // Use 'SelectMany' instead of 'CrossJoin' because  we dont have CrossJoin in LINQ.             
            { 
                AuthorName = author.Name,
                CourseName = course.Name
            });

            foreach (var item in query1)
            {
                Console.WriteLine($"Author Name: {item.AuthorName}, Course Name: {item.CourseName}");   
            }
        }


        /***** LINQ Extension Methods - Additional Methods *****/
        public static void LINQExtensionMethods_AdditionalMethods(PlutoContext db)
        {
            // Partitioning:

            var courses = db.Courses.Skip(10).Take(10);                 // Use for pagination. Skips first 10 courses and Takes another 10 courses.


            // Element Operators:

            var courses1 = db.Courses.First(c => c.FullPrice > 100);            // First() - Return first course from courses. If courses are null then throws exception.
            var courses2 = db.Courses.FirstOrDefault(c => c.FullPrice > 100);   // FirstOrDefault() - Return first course from courses. If courses are null then return null.

            var courses3 = db.Courses.Single(c => c.Level == 1);                // Single() - Return single course from courses. If there are multiple courses or if courses are null then throws exception.
            var courses4 = db.Courses.SingleOrDefault(c => c.Level == 1);       // SingleOrDefault() - Return single course from courses. If courses are null then return null. If there are multiple courses throws exception.


            // Quantifying:

            bool allAbove10Dollars = db.Courses.All(c => c.FullPrice > 100);    // All() - If all courses satisfy a condition then return true otherwise false. 
            bool anyAbove10Dollars = db.Courses.Any(c => c.FullPrice > 100);    // Any() - If any courses satisfy a condition then return true otherwise false. 


            // Aggregating:

            int level1CoursesCount = db.Courses.Where(c => c.Level == 1).Count();
            float coursesWithMaxPrice = db.Courses.Max(c => c.FullPrice);
            float coursesWithMinPrice = db.Courses.Min(c => c.FullPrice);
            float coursesWithAveragePrice = db.Courses.Average(c => c.FullPrice);
        }


    }
}

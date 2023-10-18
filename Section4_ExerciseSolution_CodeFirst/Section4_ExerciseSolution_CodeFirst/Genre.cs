using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Section4_ExerciseSolution_CodeFirst
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Video> Videos { get; set; }

        public Genre()
        {
            Videos = new Collection<Video>();
        }
    }
}

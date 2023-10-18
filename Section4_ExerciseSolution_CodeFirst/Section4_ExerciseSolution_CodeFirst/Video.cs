using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Section4_ExerciseSolution_CodeFirst
{
    public class Video
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Genre Genre{ get; set; }
        public Classification Classification { get; set; }
    }
}

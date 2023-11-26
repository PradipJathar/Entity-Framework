using System.Collections.Generic;

namespace Section4_And_5_ExerciseSolution_CodeFirst
{
    public class Tag
    {
        public int TagId { get; set; }
        public int VideoId { get; set; }
        public List<Video> Videos { get; set; }
    }
}

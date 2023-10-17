using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section3_ExerciseSolution_DatabaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            VidzyDbContext db = new VidzyDbContext();

            db.AddVideo("Ra.One", DateTime.Today, "Action", (byte)Classification.Silver);
            db.AddVideo("2.O", DateTime.Today, "Thriller", (byte)Classification.Platinum);
            db.AddVideo("Hera Pheri", DateTime.Today, "Comedy", (byte)Classification.Gold);
            db.SaveChanges();
        }
    }
}

﻿using System.Data.Entity;

namespace CodeFirstDataAnnotations
{
    public class PlutoContext : DbContext
    {

        public DbSet<Course> Courses { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Tag> Tags { get; set; }


        public PlutoContext() : base("name=PlutoContext")
        {

        }
    }
}
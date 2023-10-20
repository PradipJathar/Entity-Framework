namespace Section4_And_5_ExerciseSolution_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenresIntoGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Genres (Name)
                    VALUES 
                    ('Comedy'), 
	                ('Action'), 
	                ('Horror'), 
	                ('Thriller'), 
	                ('Family'), 
	                ('Romance')");
        }
        
        public override void Down()
        {
            Sql("DELETE FORM Genres WHERE Id BETWEEN 1 AND 6");
        }
    }
}

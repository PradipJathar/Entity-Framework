namespace Section4_And_5_ExerciseSolution_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClassificationToVideosTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Videos", "Classification", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Videos", "Classification");
        }
    }
}

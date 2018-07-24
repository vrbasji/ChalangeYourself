namespace ChalangeYourself.Services.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_final : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Points", c => c.Int(nullable: false));
            AddColumn("dbo.ProposalChalanges", "Points", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProposalChalanges", "Points");
            DropColumn("dbo.AspNetUsers", "Points");
        }
    }
}

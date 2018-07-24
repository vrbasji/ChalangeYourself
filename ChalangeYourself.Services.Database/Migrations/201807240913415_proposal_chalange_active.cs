namespace ChalangeYourself.Services.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class proposal_chalange_active : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProposalChalanges", "Activated", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProposalChalanges", "Activated");
        }
    }
}

namespace ChalangeYourself.Services.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChalangePrices",
                c => new
                    {
                        ChalangePriceId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        ImageUrl = c.String(),
                        SponsorInfo_SponsorId = c.Int(),
                        Chalange_ChalangeId = c.Int(),
                    })
                .PrimaryKey(t => t.ChalangePriceId)
                .ForeignKey("dbo.Sponsors", t => t.SponsorInfo_SponsorId)
                .ForeignKey("dbo.Chalanges", t => t.Chalange_ChalangeId)
                .Index(t => t.SponsorInfo_SponsorId)
                .Index(t => t.Chalange_ChalangeId);
            
            CreateTable(
                "dbo.Sponsors",
                c => new
                    {
                        SponsorId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Contact = c.String(),
                    })
                .PrimaryKey(t => t.SponsorId);
            
            CreateTable(
                "dbo.Chalanges",
                c => new
                    {
                        ChalangeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        PublishDate = c.DateTime(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        ThumbnailUrl = c.String(nullable: false),
                        Difficulty = c.Int(nullable: false),
                        MinAge = c.Int(nullable: false),
                        MaxAge = c.Int(nullable: false),
                        SponsorInfo_SponsorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChalangeId)
                .ForeignKey("dbo.Sponsors", t => t.SponsorInfo_SponsorId, cascadeDelete: true)
                .Index(t => t.SponsorInfo_SponsorId);
            
            CreateTable(
                "dbo.Interests",
                c => new
                    {
                        InterestId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.InterestId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ImagePath = c.String(),
                        DateOfBirth = c.DateTime(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        ShipingAddress_ShipingAddressId = c.Int(),
                        ProposalChalange_ProposalChalangeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ShipingAddresses", t => t.ShipingAddress_ShipingAddressId)
                .ForeignKey("dbo.ProposalChalanges", t => t.ProposalChalange_ProposalChalangeId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.ShipingAddress_ShipingAddressId)
                .Index(t => t.ProposalChalange_ProposalChalangeId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.ShipingAddresses",
                c => new
                    {
                        ShipingAddressId = c.Int(nullable: false, identity: true),
                        City = c.String(nullable: false),
                        Country = c.String(),
                        PostCode = c.Int(nullable: false),
                        Street = c.String(),
                        HouseNumber = c.String(),
                    })
                .PrimaryKey(t => t.ShipingAddressId);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        ResultId = c.Int(nullable: false, identity: true),
                        Place = c.Int(nullable: false),
                        Point = c.Int(nullable: false),
                        Comment = c.String(),
                        ResultLink = c.String(nullable: false),
                        Price_ChalangePriceId = c.Int(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                        Chalange_ChalangeId = c.Int(),
                    })
                .PrimaryKey(t => t.ResultId)
                .ForeignKey("dbo.ChalangePrices", t => t.Price_ChalangePriceId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Chalanges", t => t.Chalange_ChalangeId)
                .Index(t => t.Price_ChalangePriceId)
                .Index(t => t.User_Id)
                .Index(t => t.Chalange_ChalangeId);
            
            CreateTable(
                "dbo.ProposalChalanges",
                c => new
                    {
                        ProposalChalangeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ProposalChalangeId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UserChalangeHistories",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        ChalangeId = c.Int(nullable: false),
                        PointsGained = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.ChalangeId })
                .ForeignKey("dbo.Chalanges", t => t.ChalangeId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ChalangeId);
            
            CreateTable(
                "dbo.InterestChalanges",
                c => new
                    {
                        Interest_InterestId = c.Int(nullable: false),
                        Chalange_ChalangeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Interest_InterestId, t.Chalange_ChalangeId })
                .ForeignKey("dbo.Interests", t => t.Interest_InterestId, cascadeDelete: true)
                .ForeignKey("dbo.Chalanges", t => t.Chalange_ChalangeId, cascadeDelete: true)
                .Index(t => t.Interest_InterestId)
                .Index(t => t.Chalange_ChalangeId);
            
            CreateTable(
                "dbo.ApplicationUserChalanges",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Chalange_ChalangeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Chalange_ChalangeId })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Chalanges", t => t.Chalange_ChalangeId, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Chalange_ChalangeId);
            
            CreateTable(
                "dbo.ApplicationUserInterests",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Interest_InterestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Interest_InterestId })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Interests", t => t.Interest_InterestId, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Interest_InterestId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserChalangeHistories", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserChalangeHistories", "ChalangeId", "dbo.Chalanges");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUsers", "ProposalChalange_ProposalChalangeId", "dbo.ProposalChalanges");
            DropForeignKey("dbo.ProposalChalanges", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Chalanges", "SponsorInfo_SponsorId", "dbo.Sponsors");
            DropForeignKey("dbo.Results", "Chalange_ChalangeId", "dbo.Chalanges");
            DropForeignKey("dbo.Results", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Results", "Price_ChalangePriceId", "dbo.ChalangePrices");
            DropForeignKey("dbo.ChalangePrices", "Chalange_ChalangeId", "dbo.Chalanges");
            DropForeignKey("dbo.AspNetUsers", "ShipingAddress_ShipingAddressId", "dbo.ShipingAddresses");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUserInterests", "Interest_InterestId", "dbo.Interests");
            DropForeignKey("dbo.ApplicationUserInterests", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUserChalanges", "Chalange_ChalangeId", "dbo.Chalanges");
            DropForeignKey("dbo.ApplicationUserChalanges", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.InterestChalanges", "Chalange_ChalangeId", "dbo.Chalanges");
            DropForeignKey("dbo.InterestChalanges", "Interest_InterestId", "dbo.Interests");
            DropForeignKey("dbo.ChalangePrices", "SponsorInfo_SponsorId", "dbo.Sponsors");
            DropIndex("dbo.ApplicationUserInterests", new[] { "Interest_InterestId" });
            DropIndex("dbo.ApplicationUserInterests", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUserChalanges", new[] { "Chalange_ChalangeId" });
            DropIndex("dbo.ApplicationUserChalanges", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.InterestChalanges", new[] { "Chalange_ChalangeId" });
            DropIndex("dbo.InterestChalanges", new[] { "Interest_InterestId" });
            DropIndex("dbo.UserChalangeHistories", new[] { "ChalangeId" });
            DropIndex("dbo.UserChalangeHistories", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ProposalChalanges", new[] { "User_Id" });
            DropIndex("dbo.Results", new[] { "Chalange_ChalangeId" });
            DropIndex("dbo.Results", new[] { "User_Id" });
            DropIndex("dbo.Results", new[] { "Price_ChalangePriceId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "ProposalChalange_ProposalChalangeId" });
            DropIndex("dbo.AspNetUsers", new[] { "ShipingAddress_ShipingAddressId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Chalanges", new[] { "SponsorInfo_SponsorId" });
            DropIndex("dbo.ChalangePrices", new[] { "Chalange_ChalangeId" });
            DropIndex("dbo.ChalangePrices", new[] { "SponsorInfo_SponsorId" });
            DropTable("dbo.ApplicationUserInterests");
            DropTable("dbo.ApplicationUserChalanges");
            DropTable("dbo.InterestChalanges");
            DropTable("dbo.UserChalangeHistories");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ProposalChalanges");
            DropTable("dbo.Results");
            DropTable("dbo.ShipingAddresses");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Interests");
            DropTable("dbo.Chalanges");
            DropTable("dbo.Sponsors");
            DropTable("dbo.ChalangePrices");
        }
    }
}

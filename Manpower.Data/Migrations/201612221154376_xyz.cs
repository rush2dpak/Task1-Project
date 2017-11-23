namespace Manpower.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class xyz : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Extra",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ApplicantBasicInfoId = c.Int(nullable: false),
                        Personality = c.String(),
                        Drinking = c.String(),
                        Smoking = c.String(),
                        Piles = c.String(),
                        Hydrosil = c.String(),
                        Epilepsy = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.ApplicantBasicInfo", "Remarks", c => c.String());
            AddColumn("dbo.ApplicantBasicInfo", "Status", c => c.String());
            AddColumn("dbo.ApplicantBasicInfo", "Company", c => c.String());
            AddColumn("dbo.ApplicantClientEntry", "ApplicantBasicInfoId", c => c.Int(nullable: false));
            AddColumn("dbo.User", "RoleId", c => c.Int(nullable: false));
            DropColumn("dbo.ApplicantInfo", "PassportNo");
            DropColumn("dbo.ApplicantInfo", "DateOfIssue");
            DropColumn("dbo.ApplicantInfo", "DateOfExpiry");
            DropColumn("dbo.ApplicantInfo", "Passport");
            DropColumn("dbo.Language", "Certificate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Language", "Certificate", c => c.String());
            AddColumn("dbo.ApplicantInfo", "Passport", c => c.String());
            AddColumn("dbo.ApplicantInfo", "DateOfExpiry", c => c.DateTime());
            AddColumn("dbo.ApplicantInfo", "DateOfIssue", c => c.DateTime());
            AddColumn("dbo.ApplicantInfo", "PassportNo", c => c.String());
            DropColumn("dbo.User", "RoleId");
            DropColumn("dbo.ApplicantClientEntry", "ApplicantBasicInfoId");
            DropColumn("dbo.ApplicantBasicInfo", "Company");
            DropColumn("dbo.ApplicantBasicInfo", "Status");
            DropColumn("dbo.ApplicantBasicInfo", "Remarks");
            DropTable("dbo.Extra");
        }
    }
}

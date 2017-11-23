namespace Manpower.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vvd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departure",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Carrier = c.String(),
                        FlightDate = c.DateTime(nullable: false),
                        Sector = c.String(),
                        LastWord = c.String(),
                        ApplicantBasicInfoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Permit",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PermitNo = c.String(),
                        PermitDate = c.DateTime(nullable: false),
                        ApplicantBasicInfoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Visa",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IssuedDate = c.DateTime(nullable: false),
                        ValidTill = c.DateTime(nullable: false),
                        VisaNo = c.String(),
                        ApplicantBasicInfoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.ApplicantBasicInfo", "CompanyID", c => c.Int(nullable: false));
            AddColumn("dbo.ApplicantBasicInfo", "AppliedDate", c => c.DateTime());
            AddColumn("dbo.ApplicantInfo", "ApplicantDate", c => c.DateTime());
            AddColumn("dbo.ApplicantInfo", "Phone1", c => c.String());
            AddColumn("dbo.ApplicantInfo", "Phone2", c => c.String());
            AddColumn("dbo.ApplicantInfo", "PassportNo", c => c.String());
            AddColumn("dbo.ApplicantInfo", "DateOfIssue", c => c.DateTime());
            AddColumn("dbo.ApplicantInfo", "DateOfExpiry", c => c.DateTime());
            AddColumn("dbo.ApplicantInfo", "RelationshipKeen", c => c.String());
            AddColumn("dbo.ClientNotice", "Fooding", c => c.String());
            AddColumn("dbo.ClientNotice", "Accomodation", c => c.String());
            DropColumn("dbo.ApplicantInfo", "Phone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicantInfo", "Phone", c => c.String());
            DropColumn("dbo.ClientNotice", "Accomodation");
            DropColumn("dbo.ClientNotice", "Fooding");
            DropColumn("dbo.ApplicantInfo", "RelationshipKeen");
            DropColumn("dbo.ApplicantInfo", "DateOfExpiry");
            DropColumn("dbo.ApplicantInfo", "DateOfIssue");
            DropColumn("dbo.ApplicantInfo", "PassportNo");
            DropColumn("dbo.ApplicantInfo", "Phone2");
            DropColumn("dbo.ApplicantInfo", "Phone1");
            DropColumn("dbo.ApplicantInfo", "ApplicantDate");
            DropColumn("dbo.ApplicantBasicInfo", "AppliedDate");
            DropColumn("dbo.ApplicantBasicInfo", "CompanyID");
            DropTable("dbo.Visa");
            DropTable("dbo.Permit");
            DropTable("dbo.Departure");
        }
    }
}

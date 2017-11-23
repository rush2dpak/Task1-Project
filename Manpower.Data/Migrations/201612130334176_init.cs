namespace Manpower.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicantBasicInfo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        DOB = c.DateTime(nullable: false),
                        AgentName = c.String(),
                        Cancel = c.Boolean(nullable: false),
                        ApplicantImage = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ApplicantInfo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ApplicantBasicInfoId = c.Int(nullable: false),
                        Sex = c.String(),
                        Religion = c.String(),
                        Nationality = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        PermanentAddress = c.String(),
                        PassportNo = c.String(),
                        DateOfIssue = c.DateTime(),
                        DateOfExpiry = c.DateTime(),
                        Feet = c.String(),
                        Inches = c.String(),
                        Weight = c.String(),
                        MaritalStatus = c.String(),
                        NoOfChildren = c.Int(nullable: false),
                        NameOfNextKeen = c.String(),
                        PhoneKeen = c.String(),
                        AddressKeen = c.String(),
                        EmailKeen = c.String(),
                        Passport = c.String(),
                        Objective = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ApplicantBasicInfo", t => t.ApplicantBasicInfoId, cascadeDelete: true)
                .Index(t => t.ApplicantBasicInfoId);
            
            CreateTable(
                "dbo.AppliedCompany",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        JobApplied = c.String(),
                        CompanyInfoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CompanyInfo", t => t.CompanyInfoID, cascadeDelete: true)
                .Index(t => t.CompanyInfoID);
            
            CreateTable(
                "dbo.CompanyInfo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country = c.String(),
                        Address = c.String(),
                        PhoneNo = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Certificate",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CertificateName = c.String(),
                        CertificateImage = c.String(),
                        ApplicantBasicInfoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ClientNotice",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompanyInfoID = c.Int(nullable: false),
                        LotNo = c.Int(nullable: false),
                        NoticeDate = c.DateTime(nullable: false),
                        NoticeNo = c.String(),
                        TotalWorkers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CompanyInfo", t => t.CompanyInfoID, cascadeDelete: true)
                .Index(t => t.CompanyInfoID);
            
            CreateTable(
                "dbo.Education",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Level = c.String(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Institute = c.String(),
                        ApplicantBasicInfoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Employment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Position = c.String(),
                        Company = c.String(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Experience = c.String(),
                        ApplicantBasicInfoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Error",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        StackTrace = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Language",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Languages = c.String(),
                        Spoken = c.String(),
                        Writing = c.String(),
                        Reading = c.String(),
                        Listening = c.String(),
                        Certificate = c.String(),
                        ApplicantBasicInfoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ManpowerInfo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortName = c.String(),
                        Address = c.String(),
                        PhoneNo1 = c.String(),
                        PhoneNo2 = c.String(),
                        Email = c.String(),
                        WebSite = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PositionDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Position = c.Int(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        JobNumber = c.Int(nullable: false),
                        ClientNoticeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PositionTitle",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Skill = c.String(),
                        ApplicantBasicInfoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Training",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Institution = c.String(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        ApplicantBasicInfoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        Sex = c.String(),
                        Remarks = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        Cancel = c.Boolean(nullable: false),
                        HashedPassword = c.String(),
                        Salt = c.String(),
                        IsLocked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.ClientNotice", "CompanyInfoID", "dbo.CompanyInfo");
            DropForeignKey("dbo.AppliedCompany", "CompanyInfoID", "dbo.CompanyInfo");
            DropForeignKey("dbo.ApplicantInfo", "ApplicantBasicInfoId", "dbo.ApplicantBasicInfo");
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.ClientNotice", new[] { "CompanyInfoID" });
            DropIndex("dbo.AppliedCompany", new[] { "CompanyInfoID" });
            DropIndex("dbo.ApplicantInfo", new[] { "ApplicantBasicInfoId" });
            DropTable("dbo.User");
            DropTable("dbo.UserRole");
            DropTable("dbo.Training");
            DropTable("dbo.Skills");
            DropTable("dbo.Role");
            DropTable("dbo.PositionTitle");
            DropTable("dbo.PositionDetails");
            DropTable("dbo.ManpowerInfo");
            DropTable("dbo.Language");
            DropTable("dbo.Error");
            DropTable("dbo.Employment");
            DropTable("dbo.Education");
            DropTable("dbo.ClientNotice");
            DropTable("dbo.Certificate");
            DropTable("dbo.CompanyInfo");
            DropTable("dbo.AppliedCompany");
            DropTable("dbo.ApplicantInfo");
            DropTable("dbo.ApplicantBasicInfo");
        }
    }
}

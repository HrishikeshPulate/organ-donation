namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accepters",
                c => new
                    {
                        ACEEPTER_ID = c.Int(nullable: false, identity: true),
                        NAME = c.String(nullable: false),
                        REQUIREMENT = c.String(nullable: false),
                        AGE = c.Int(nullable: false),
                        DATE = c.DateTime(nullable: false),
                        GENDER = c.String(nullable: false),
                        LOCATION = c.String(nullable: false),
                        BLOOD_GROUP = c.String(nullable: false),
                        CONTACT_NUMBER = c.String(nullable: false),
                        STATUS = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ACEEPTER_ID)
                .ForeignKey("dbo.Userinfoes", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Userinfoes",
                c => new
                    {
                        USER_ID = c.Int(nullable: false, identity: true),
                        USER_NAME = c.String(nullable: false),
                        PASSWORD = c.String(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.USER_ID)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ROLE_ID = c.Int(nullable: false, identity: true),
                        ROLE_NAME = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ROLE_ID);
            
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        APPOINTMENT_ID = c.Int(nullable: false, identity: true),
                        CaseId = c.Int(nullable: false),
                        STATUS = c.String(),
                        SLOT = c.String(nullable: false),
                        BOOKING_DATE = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.APPOINTMENT_ID)
                .ForeignKey("dbo.CasePools", t => t.CaseId, cascadeDelete: true)
                .Index(t => t.CaseId);
            
            CreateTable(
                "dbo.CasePools",
                c => new
                    {
                        CASE_ID = c.Int(nullable: false, identity: true),
                        AccepterId = c.Int(),
                        DonorId = c.Int(nullable: false),
                        ORGANS = c.String(),
                        DoctorId = c.Int(),
                        STATUS = c.String(),
                    })
                .PrimaryKey(t => t.CASE_ID)
                .ForeignKey("dbo.Accepters", t => t.AccepterId)
                .ForeignKey("dbo.Doctors", t => t.DoctorId)
                .ForeignKey("dbo.Nominees", t => t.DonorId, cascadeDelete: true)
                .Index(t => t.AccepterId)
                .Index(t => t.DonorId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DOCTOR_ID = c.Int(nullable: false, identity: true),
                        DOCTOR_NAME = c.String(nullable: false),
                        CONTACT_NUMBER = c.String(nullable: false),
                        STATUS = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DOCTOR_ID)
                .ForeignKey("dbo.Userinfoes", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Nominees",
                c => new
                    {
                        NOMINEE_ID = c.Int(nullable: false, identity: true),
                        DONOR_NAME = c.String(nullable: false),
                        NOMINEE_NAME = c.String(nullable: false),
                        DONOR_AGE = c.Int(nullable: false),
                        DATE = c.DateTime(nullable: false),
                        DONOR_GENDER = c.String(nullable: false),
                        LOCATION = c.String(nullable: false),
                        BLOOD_GROUP = c.String(nullable: false),
                        CONTACT_NUMBER = c.String(nullable: false),
                        STATUS = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NOMINEE_ID)
                .ForeignKey("dbo.Userinfoes", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        MANAGER_ID = c.Int(nullable: false, identity: true),
                        MANAGER_NAME = c.String(nullable: false),
                        CONTACT_NUMBER = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MANAGER_ID)
                .ForeignKey("dbo.Userinfoes", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Managers", "UserId", "dbo.Userinfoes");
            DropForeignKey("dbo.Appointments", "CaseId", "dbo.CasePools");
            DropForeignKey("dbo.CasePools", "DonorId", "dbo.Nominees");
            DropForeignKey("dbo.Nominees", "UserId", "dbo.Userinfoes");
            DropForeignKey("dbo.CasePools", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Doctors", "UserId", "dbo.Userinfoes");
            DropForeignKey("dbo.CasePools", "AccepterId", "dbo.Accepters");
            DropForeignKey("dbo.Accepters", "UserId", "dbo.Userinfoes");
            DropForeignKey("dbo.Userinfoes", "RoleId", "dbo.Roles");
            DropIndex("dbo.Managers", new[] { "UserId" });
            DropIndex("dbo.Nominees", new[] { "UserId" });
            DropIndex("dbo.Doctors", new[] { "UserId" });
            DropIndex("dbo.CasePools", new[] { "DoctorId" });
            DropIndex("dbo.CasePools", new[] { "DonorId" });
            DropIndex("dbo.CasePools", new[] { "AccepterId" });
            DropIndex("dbo.Appointments", new[] { "CaseId" });
            DropIndex("dbo.Userinfoes", new[] { "RoleId" });
            DropIndex("dbo.Accepters", new[] { "UserId" });
            DropTable("dbo.Managers");
            DropTable("dbo.Nominees");
            DropTable("dbo.Doctors");
            DropTable("dbo.CasePools");
            DropTable("dbo.Appointments");
            DropTable("dbo.Roles");
            DropTable("dbo.Userinfoes");
            DropTable("dbo.Accepters");
        }
    }
}

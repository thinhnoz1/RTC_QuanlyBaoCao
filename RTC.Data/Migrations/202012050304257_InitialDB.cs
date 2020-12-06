namespace RTC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RTC_Account",
                c => new
                    {
                        AccountID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false),
                        AccountType = c.Int(nullable: false),
                        LastLoginDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Status = c.Boolean(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountID)
                .ForeignKey("dbo.RTC_Employee", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.RTC_Employee",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FullName = c.String(maxLength: 100),
                        DateOfBirth = c.DateTime(storeType: "date"),
                        PhoneNumber = c.String(maxLength: 20),
                        JoinedDate = c.DateTime(storeType: "date"),
                        Email = c.String(maxLength: 100),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.RTC_DailyReport",
                c => new
                    {
                        ReportID = c.Long(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false, storeType: "date"),
                        FullName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ReportID)
                .ForeignKey("dbo.RTC_Employee", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.RTC_Department",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(maxLength: 1000),
                        DepartmentChief = c.Int(),
                        RTC_Employee_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.DepartmentID)
                .ForeignKey("dbo.RTC_Employee", t => t.RTC_Employee_UserID)
                .Index(t => t.RTC_Employee_UserID);
            
            CreateTable(
                "dbo.RTC_ProjectMember",
                c => new
                    {
                        ProjectID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        RoleID = c.Int(),
                    })
                .PrimaryKey(t => new { t.ProjectID, t.UserID })
                .ForeignKey("dbo.RTC_Employee", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.RTC_Project", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.ProjectID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.RTC_Project",
                c => new
                    {
                        ProjectID = c.Int(nullable: false, identity: true),
                        ProjectCode = c.String(maxLength: 100),
                        ProjectName = c.String(maxLength: 1000),
                        DateStarted = c.DateTime(storeType: "date"),
                        DateEnded = c.DateTime(storeType: "date"),
                        StartDateExpected = c.DateTime(storeType: "date"),
                        EndDateExpected = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.ProjectID);
            
            CreateTable(
                "dbo.RTC_ReportDetail",
                c => new
                    {
                        ReportID = c.Long(nullable: false),
                        ProjectID = c.Int(nullable: false),
                        WorkDetail = c.String(),
                        WorkFinished = c.String(),
                        ProblemRemained = c.String(),
                        ExpectedSolution = c.String(),
                        ProjectCode = c.String(maxLength: 100),
                        NextDayWork = c.String(),
                        Note = c.String(),
                        DateCreated = c.DateTime(nullable: false, storeType: "date"),
                        RTC_DailyReport_ReportID = c.Long(),
                    })
                .PrimaryKey(t => t.ReportID)
                .ForeignKey("dbo.RTC_DailyReport", t => t.RTC_DailyReport_ReportID)
                .ForeignKey("dbo.RTC_Project", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.ProjectID)
                .Index(t => t.RTC_DailyReport_ReportID);
            
            CreateTable(
                "dbo.RTC_Role",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.RTC_Team",
                c => new
                    {
                        TeamID = c.Int(nullable: false, identity: true),
                        TeamName = c.String(maxLength: 50),
                        LeaderName = c.String(maxLength: 100),
                        DepartmentID = c.Int(),
                    })
                .PrimaryKey(t => t.TeamID)
                .ForeignKey("dbo.RTC_Department", t => t.DepartmentID)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.RTC_TeamMember",
                c => new
                    {
                        TeamID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        LeaderID = c.Int(),
                    })
                .PrimaryKey(t => new { t.TeamID, t.UserID })
                .ForeignKey("dbo.RTC_Employee", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.RTC_Team", t => t.TeamID, cascadeDelete: true)
                .Index(t => t.TeamID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RTC_TeamMember", "TeamID", "dbo.RTC_Team");
            DropForeignKey("dbo.RTC_TeamMember", "UserID", "dbo.RTC_Employee");
            DropForeignKey("dbo.RTC_Team", "DepartmentID", "dbo.RTC_Department");
            DropForeignKey("dbo.RTC_ReportDetail", "ProjectID", "dbo.RTC_Project");
            DropForeignKey("dbo.RTC_ReportDetail", "RTC_DailyReport_ReportID", "dbo.RTC_DailyReport");
            DropForeignKey("dbo.RTC_ProjectMember", "ProjectID", "dbo.RTC_Project");
            DropForeignKey("dbo.RTC_ProjectMember", "UserID", "dbo.RTC_Employee");
            DropForeignKey("dbo.RTC_Department", "RTC_Employee_UserID", "dbo.RTC_Employee");
            DropForeignKey("dbo.RTC_DailyReport", "UserID", "dbo.RTC_Employee");
            DropForeignKey("dbo.RTC_Account", "UserID", "dbo.RTC_Employee");
            DropIndex("dbo.RTC_TeamMember", new[] { "UserID" });
            DropIndex("dbo.RTC_TeamMember", new[] { "TeamID" });
            DropIndex("dbo.RTC_Team", new[] { "DepartmentID" });
            DropIndex("dbo.RTC_ReportDetail", new[] { "RTC_DailyReport_ReportID" });
            DropIndex("dbo.RTC_ReportDetail", new[] { "ProjectID" });
            DropIndex("dbo.RTC_ProjectMember", new[] { "UserID" });
            DropIndex("dbo.RTC_ProjectMember", new[] { "ProjectID" });
            DropIndex("dbo.RTC_Department", new[] { "RTC_Employee_UserID" });
            DropIndex("dbo.RTC_DailyReport", new[] { "UserID" });
            DropIndex("dbo.RTC_Account", new[] { "UserID" });
            DropTable("dbo.RTC_TeamMember");
            DropTable("dbo.RTC_Team");
            DropTable("dbo.RTC_Role");
            DropTable("dbo.RTC_ReportDetail");
            DropTable("dbo.RTC_Project");
            DropTable("dbo.RTC_ProjectMember");
            DropTable("dbo.RTC_Department");
            DropTable("dbo.RTC_DailyReport");
            DropTable("dbo.RTC_Employee");
            DropTable("dbo.RTC_Account");
        }
    }
}

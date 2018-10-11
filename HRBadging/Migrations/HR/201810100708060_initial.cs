namespace HRBadging.Migrations.HR
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Badges",
                c => new
                    {
                        BadgeId = c.String(nullable: false, maxLength: 25),
                        BadgeExp = c.DateTime(nullable: false),
                        HasCustomSeal = c.Boolean(),
                        CustomSealExp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        SITA = c.String(),
                        EmployeeId = c.String(),
                        Employee_EmployeeId = c.String(maxLength: 25),
                    })
                .PrimaryKey(t => t.BadgeId)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId)
                .Index(t => t.Employee_EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.String(nullable: false, maxLength: 25),
                        LName = c.String(),
                        FName = c.String(),
                        BadgeId = c.String(),
                        Badge_BadgeId = c.String(maxLength: 25),
                        Badge_BadgeId1 = c.String(maxLength: 25),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Badges", t => t.Badge_BadgeId)
                .ForeignKey("dbo.Badges", t => t.Badge_BadgeId1)
                .Index(t => t.Badge_BadgeId)
                .Index(t => t.Badge_BadgeId1);
            
            CreateTable(
                "dbo.Terminates",
                c => new
                    {
                        UpId = c.String(nullable: false, maxLength: 25),
                        BadgeId = c.String(maxLength: 25),
                        DateJobTermination = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        BadgeTerminationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        BadgeReturned = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UpId)
                .ForeignKey("dbo.Badges", t => t.BadgeId)
                .Index(t => t.BadgeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Terminates", "BadgeId", "dbo.Badges");
            DropForeignKey("dbo.Employees", "Badge_BadgeId1", "dbo.Badges");
            DropForeignKey("dbo.Badges", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "Badge_BadgeId", "dbo.Badges");
            DropIndex("dbo.Terminates", new[] { "BadgeId" });
            DropIndex("dbo.Employees", new[] { "Badge_BadgeId1" });
            DropIndex("dbo.Employees", new[] { "Badge_BadgeId" });
            DropIndex("dbo.Badges", new[] { "Employee_EmployeeId" });
            DropTable("dbo.Terminates");
            DropTable("dbo.Employees");
            DropTable("dbo.Badges");
        }
    }
}

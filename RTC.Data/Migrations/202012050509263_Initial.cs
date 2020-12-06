namespace RTC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RTC_Account", "Status", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RTC_Account", "Status", c => c.Int());
        }
    }
}

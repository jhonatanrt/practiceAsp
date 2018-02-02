namespace practiceNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "IsSuscribedToNewsletter");
            DropColumn("dbo.Customers", "MembershipType_SignUpFee");
            DropColumn("dbo.Customers", "MembershipType_DurationInMonths");
            DropColumn("dbo.Customers", "MembershipType_DiscountRate");
            DropColumn("dbo.Customers", "MembershipTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.Customers", "MembershipType_DiscountRate", c => c.Byte(nullable: false));
            AddColumn("dbo.Customers", "MembershipType_DurationInMonths", c => c.Byte(nullable: false));
            AddColumn("dbo.Customers", "MembershipType_SignUpFee", c => c.Short(nullable: false));
            AddColumn("dbo.Customers", "IsSuscribedToNewsletter", c => c.Boolean(nullable: false));
        }
    }
}

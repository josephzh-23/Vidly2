namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNameMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("update MembershipTypes set Name = 'Pay as you go' where id =1");
            Sql("update MembershipTypes set Name = 'Monthly' where id = 2");
            Sql("UPDATE MembershipTypes SET Name = 'Quarterly' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET Name = 'Annual' WHERE Id = 4");

        }
        
        public override void Down()
        {
        }
    }
}

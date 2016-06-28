namespace QLNhaHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DonViTinhs",
                c => new
                    {
                        IDDonViTinh = c.Int(nullable: false, identity: true),
                        Ten = c.String(),
                        Huy = c.Byte(nullable: false),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.IDDonViTinh);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DonViTinhs");
        }
    }
}

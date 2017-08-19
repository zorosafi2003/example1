namespace Example1.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TblCustomer",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.TblInvoiceDetail",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Id = c.Int(nullable: false, identity: true),
                        TblProductGuid = c.Guid(nullable: false),
                        Count = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TblInvoiceMasterGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.TblInvoiceMaster", t => t.TblInvoiceMasterGuid, cascadeDelete: true)
                .ForeignKey("dbo.TblProduct", t => t.TblProductGuid)
                .Index(t => t.TblProductGuid)
                .Index(t => t.TblInvoiceMasterGuid);
            
            CreateTable(
                "dbo.TblInvoiceMaster",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Id = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Notes = c.String(),
                        TblCustomerGuid = c.Guid(nullable: false),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.TblCustomer", t => t.TblCustomerGuid)
                .Index(t => t.TblCustomerGuid);
            
            CreateTable(
                "dbo.TblProduct",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TblInvoiceDetail", "TblProductGuid", "dbo.TblProduct");
            DropForeignKey("dbo.TblInvoiceDetail", "TblInvoiceMasterGuid", "dbo.TblInvoiceMaster");
            DropForeignKey("dbo.TblInvoiceMaster", "TblCustomerGuid", "dbo.TblCustomer");
            DropIndex("dbo.TblInvoiceMaster", new[] { "TblCustomerGuid" });
            DropIndex("dbo.TblInvoiceDetail", new[] { "TblInvoiceMasterGuid" });
            DropIndex("dbo.TblInvoiceDetail", new[] { "TblProductGuid" });
            DropTable("dbo.TblProduct");
            DropTable("dbo.TblInvoiceMaster");
            DropTable("dbo.TblInvoiceDetail");
            DropTable("dbo.TblCustomer");
        }
    }
}

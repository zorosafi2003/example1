using Example1.Dal.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Example1.Dal.Concrete
{
    public  class AppDbContext : DbContext
    {
        public AppDbContext() : base("AppDbContext") 
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = true; 

        }
 
        public DbSet<TblCustomer> TblCustomer { get; set; }
        public DbSet<TblProduct> TblProduct { get; set; }
        public DbSet<TblInvoiceMaster> TblInvoiceMaster { get; set; }
        public DbSet<TblInvoiceDetail> TblInvoiceDetail { get; set; }
     

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<TblInvoiceMaster>()
                 .HasMany(c => c.tblInvoiceDetails)
                 .WithRequired(o => o.tblInvoiceMaster)
                 .HasForeignKey(o => o.TblInvoiceMasterGuid)
                 .WillCascadeOnDelete(true);
        }
    }
}

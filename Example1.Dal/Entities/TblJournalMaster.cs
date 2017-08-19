
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ECommerceApp.Dal.Concrete;

namespace Example1.Dal.Entities
{
    [Table("TblInvoiceMaster")]
    public class TblInvoiceMaster
    {
        [Key]
        public Guid Guid { get; set; }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }

        public Guid TblCustomerGuid { get; set; }
        [ForeignKey("TblCustomerGuid")]
        public virtual TblCustomer tblCustomer { get; set; }

        public decimal Discount { get; set; }

        public virtual ICollection<TblInvoiceDetail> tblInvoiceDetails { get; set; }
        [NotMapped]

        public decimal Total
        {
            get
            {
                try
                {
                    return decimal.Parse(tblInvoiceDetails.Sum(x => x.Count * x.tblProduct.Price).ToString()) * ((100 - Discount) / 100);

                }
                catch { return 0; }
            }
        }




    }
}

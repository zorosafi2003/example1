using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example1.Dal.Entities
{
    [Table("TblInvoiceDetail")]
    public class TblInvoiceDetail
    {
        [Key]
        public Guid Guid { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [NotMapped]
        public decimal TblProductPrice { get { try { return tblProduct.Price; } catch { return 0; } } }

        [NotMapped]
        public string TblProductName { get { try { return tblProduct.Name; } catch { return ""; } } }

        public Guid TblProductGuid { get; set; }
        [ForeignKey("TblProductGuid")]
        public virtual TblProduct tblProduct { get; set; }

        public decimal Count { get; set; }

        public Guid TblInvoiceMasterGuid { get; set; }
        [ForeignKey("TblInvoiceMasterGuid")]
        public virtual TblInvoiceMaster tblInvoiceMaster { get; set; }

     
     
        

    }
}

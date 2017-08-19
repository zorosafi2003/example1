
using Example1.Dal.Abstract;
using Example1.Dal.Concrete;
using Example1.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ECommerceApp.Dal.Concrete.Accounting
{
    public class EFInvoiceMasterRepository : IInvoiceMasterRepository
    {
        public IEnumerable<object> Search(string text, int skip, int take)
        {
            using (AppDbContext db = new AppDbContext())
            {

                if (text == null || text == "")
                {
                    return db.TblInvoiceMaster.Include(x=>x.tblCustomer).Include(x => x.tblInvoiceDetails.Select(c=>c.tblProduct))
                     .OrderByDescending(x => x.Id).Skip(skip).Take(take).ToList();
                }
                else
                {
                    var invoiceId = Int32.Parse(text);
                    return db.TblInvoiceMaster.Include(x => x.tblCustomer).Include(x => x.tblInvoiceDetails.Select(c => c.tblProduct))
                     .Where(x=>x.Id == invoiceId).OrderByDescending(x => x.Id).Skip(skip).Take(take).ToList();


                }
            }
        }
        public IEnumerable<object> Search(string text)
        {
            using (AppDbContext db = new AppDbContext())
            {

                if (text == null || text == "")
                {
                    return db.TblInvoiceMaster.Include(x => x.tblCustomer).Include(x => x.tblInvoiceDetails.Select(c => c.tblProduct))
                    .OrderByDescending(x => x.Id).ToList();
                }
                else
                {
                    var invoiceId = Int32.Parse(text);
                    return db.TblInvoiceMaster.Include(x => x.tblCustomer).Include(x => x.tblInvoiceDetails.Select(c => c.tblProduct))
                     .Where(x => x.Id == invoiceId).OrderByDescending(x => x.Id).ToList();
                }


            }
        }

        public int Count(string text)
        {
            using (AppDbContext db = new AppDbContext())
            {
                if (text == null || text == "")
                { return db.TblInvoiceMaster.Count(); }
                else
                {
                    var invoiceId = Int32.Parse(text);
                    return db.TblInvoiceMaster.Where(x => x.Id == invoiceId).Count();
                }
            }
        }

        public TblInvoiceMaster GetOne(string guid, bool IsNew)
        {
            if (IsNew == true)
            {
                using (AppDbContext db = new AppDbContext())
                {
                    TblInvoiceMaster n = new TblInvoiceMaster();
                    n.Guid = Guid.NewGuid();
                    n.Id = Max() + 1;
                    n.Date = DateTime.Now.Date;
                    return n;
                }
            }
            else
            {
                using (AppDbContext db = new AppDbContext())
                {
                    Guid n = Guid.Parse(guid);
                    TblInvoiceMaster query = db.TblInvoiceMaster.Include(x => x.tblCustomer).Include(x => x.tblInvoiceDetails.Select(c => c.tblProduct))
                            .Where(x => x.Guid == n).FirstOrDefault();
                    query.tblInvoiceDetails = query.tblInvoiceDetails.OrderBy(x=>x.Id).ToList();
                    return query;

                }
            }
        }

        public void Insert(TblInvoiceMaster TblInvoiceMaster)
        {
            using (AppDbContext db = new AppDbContext())
            {
                db.TblInvoiceMaster.Add(DataVerified(TblInvoiceMaster));
                db.TblInvoiceDetail.AddRange(DataVerified(TblInvoiceMaster).tblInvoiceDetails);
                db.SaveChanges();
            }

        }

        public void Update(TblInvoiceMaster TblInvoiceMaster)
        {
            using (AppDbContext db = new AppDbContext())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var original = db.TblInvoiceMaster.Where(x=>x.Guid ==TblInvoiceMaster.Guid).FirstOrDefault();

                        db.Entry(original).CurrentValues.SetValues(DataVerified(TblInvoiceMaster));

                        db.TblInvoiceDetail.RemoveRange(db.TblInvoiceDetail.Where(x => x.TblInvoiceMasterGuid == TblInvoiceMaster.Guid).ToList());

                        db.TblInvoiceDetail.AddRange(DataVerified(TblInvoiceMaster).tblInvoiceDetails);

                        db.SaveChanges();

                        dbContextTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }

                }
            }
     
        }

        public void Delete(string guid)
        {
            using (AppDbContext db = new AppDbContext())
            {
                Guid n = Guid.Parse(guid);

                var original = db.TblInvoiceMaster.Where(x => x.Guid == n).FirstOrDefault();
                db.TblInvoiceMaster.Remove(original);
                db.SaveChanges();
            }
        }


        public IEnumerable<object> Search()
        {
            using (AppDbContext db = new AppDbContext())
            {
                return db.TblInvoiceMaster.ToList();
            };
        }


        public int Max()
        {
            using (AppDbContext db = new AppDbContext())
            {
                try
                {
                    var mx = db.TblInvoiceMaster.Max(x => x.Id);
                    return mx;
                }
                catch
                { return 0; }

            }
        }

        public TblInvoiceMaster DataVerified(TblInvoiceMaster TblInvoiceMaster)
        {
            TblInvoiceMaster.TblCustomerGuid = TblInvoiceMaster.tblCustomer.Guid;
            TblInvoiceMaster.tblCustomer = null;
            foreach (var item in TblInvoiceMaster.tblInvoiceDetails)
            {
                item.tblProduct = null;
                item.tblInvoiceMaster = null;
            }
            return TblInvoiceMaster;
        }



    }
}

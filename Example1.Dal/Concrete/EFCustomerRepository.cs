using Example1.Dal.Abstract;
using Example1.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Example1.Dal.Concrete
{
    public class EFCustomerRepository : ICustomerRepository
    {
        public IEnumerable<object> Search(string text, int skip, int take)
        {
            using (AppDbContext db = new AppDbContext())
            {
                if (text == null || text == "")
                { return db.TblCustomer.OrderBy(x => x.Id).Skip(skip).Take(take).ToList(); }
                else
                {
                    return db.TblCustomer.Where(x => x.Name.Contains(text)).OrderBy(x => x.Id).Skip(skip).Take(take).ToList();
                }
            }
        }
        public IEnumerable<object> Search(string text)
        {
            using (AppDbContext db = new AppDbContext())
            {
                if (text == null || text == "")
                { return db.TblCustomer.OrderBy(x => x.Id).ToList(); }
                else
                {
                    return db.TblCustomer.Where(x => x.Name.Contains(text)).OrderBy(x => x.Id).ToList();
                }

            }
        }

        public int Count(string text)
        {
            using (AppDbContext db = new AppDbContext())
            {
                if (text == null || text == "")
                { return db.TblCustomer.Count(); }
                else
                {
                    return db.TblCustomer.Where(x => x.Name.Contains(text)).Count();
                }
            }
        }

        public TblCustomer GetOne(string guid, bool IsNew)
        {
            if (IsNew == true)
            {
                using (AppDbContext db = new AppDbContext())
                {
                    TblCustomer n = new TblCustomer();
                    n.Guid = Guid.NewGuid();
                    n.Id = Max() + 1;
                    return n;
                }
            }
            else
            {
                using (AppDbContext db = new AppDbContext())
                {
                    Guid n = Guid.Parse(guid);
                    return db.TblCustomer.Where(x => x.Guid == n).FirstOrDefault();
                }
            }
        }

        public void Insert(TblCustomer customer)
        {
            using (AppDbContext db = new AppDbContext())
            {
                try
                {
                    db.TblCustomer.Add(customer);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Update(TblCustomer customer)
        {
            using (AppDbContext db = new AppDbContext())
            {
                try
                {
                    var original = db.TblCustomer.Where(x=>x.Guid == customer.Guid).FirstOrDefault();
                    db.Entry(original).CurrentValues.SetValues(customer);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        public void Delete(string guid)
        {
            using (AppDbContext db = new AppDbContext())
            {
                try
                {
                    Guid n = Guid.Parse(guid);
                    var original = db.TblCustomer.Where(x => x.Guid == n).FirstOrDefault();
                    db.TblCustomer.Remove(original);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        public IEnumerable<object> Search()
        {
            using (AppDbContext db = new AppDbContext())
            {
                return db.TblCustomer.ToList();
            };
        }


        public int Max()
        {
            using (AppDbContext db = new AppDbContext())
            {
                try
                {
                    var mx = db.TblCustomer.Max(x => x.Id);
                    return mx;
                }
                catch
                { return 0; }

            }
        }


    }
}

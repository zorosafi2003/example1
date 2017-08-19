using Example1.Dal.Abstract;
using Example1.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Example1.Dal.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        public IEnumerable<object> Search(string text, int skip, int take)
        {
            using (AppDbContext db = new AppDbContext())
            {
                if (text == null || text == "")
                { return db.TblProduct.OrderBy(x => x.Id).Skip(skip).Take(take).ToList(); }
                else
                {
                    return db.TblProduct.Where(x => x.Name.Contains(text)).OrderBy(x => x.Id).Skip(skip).Take(take).ToList();
                }
            }
        }
        public IEnumerable<object> Search(string text)
        {
            using (AppDbContext db = new AppDbContext())
            {
                if (text == null || text == "")
                { return db.TblProduct.OrderBy(x => x.Id).ToList(); }
                else
                {
                    return db.TblProduct.Where(x => x.Name.Contains(text)).OrderBy(x => x.Id).ToList();
                }

            }
        }

        public int Count(string text)
        {
            using (AppDbContext db = new AppDbContext())
            {
                if (text == null || text == "")
                { return db.TblProduct.Count(); }
                else
                {
                    return db.TblProduct.Where(x => x.Name.Contains(text)).Count();
                }
            }
        }

        public TblProduct GetOne(string guid, bool IsNew)
        {
            if (IsNew == true)
            {
                using (AppDbContext db = new AppDbContext())
                {
                    TblProduct n = new TblProduct();
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
                    return db.TblProduct.Where(x => x.Guid == n).FirstOrDefault();
                }
            }
        }

        public void Insert(TblProduct customer)
        {
            using (AppDbContext db = new AppDbContext())
            {
                try
                {
                    db.TblProduct.Add(customer);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Update(TblProduct customer)
        {
            using (AppDbContext db = new AppDbContext())
            {
                try
                {
                    var original = db.TblProduct.Where(x=>x.Guid == customer.Guid).FirstOrDefault();
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
                    var original = db.TblProduct.Where(x => x.Guid == n).FirstOrDefault();
                    db.TblProduct.Remove(original);
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
                return db.TblProduct.ToList();
            };
        }


        public int Max()
        {
            using (AppDbContext db = new AppDbContext())
            {
                try
                {
                    var mx = db.TblProduct.Max(x => x.Id);
                    return mx;
                }
                catch
                { return 0; }

            }
        }


    }
}

using Example1.Dal.Entities;
using System.Collections.Generic;

namespace Example1.Dal.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<object> Search(string text, int skip, int take);
        IEnumerable<object> Search(string text);
        IEnumerable<object> Search();
        int Count(string text);
        int Max();
        TblProduct GetOne(string guid, bool IsNew);
        void Insert(TblProduct product);
        void Update(TblProduct product);
        void Delete(string guid);
    }
}

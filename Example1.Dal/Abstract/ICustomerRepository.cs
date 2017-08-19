using Example1.Dal.Entities;
using System.Collections.Generic;

namespace Example1.Dal.Abstract
{
    public interface ICustomerRepository
    {
        IEnumerable<object> Search(string text, int skip, int take);
        IEnumerable<object> Search(string text);
        IEnumerable<object> Search();
        int Count(string text);
        int Max();
        TblCustomer GetOne(string guid, bool IsNew);
        void Insert(TblCustomer customer);
        void Update(TblCustomer customer);
        void Delete(string guid);
    }
}

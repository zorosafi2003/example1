
using Example1.Dal.Entities;
using System;
using System.Collections.Generic;

namespace Example1.Dal.Abstract
{
    public interface IInvoiceMasterRepository
    {
        IEnumerable<TblInvoiceMaster> Search(string text, int skip, int take);
        IEnumerable<TblInvoiceMaster> Search(string text);
        IEnumerable<TblInvoiceMaster> Search();
        int Count(string text);
        int Max();
        TblInvoiceMaster GetOne(string guid, bool IsNew);
        void Insert(TblInvoiceMaster invoiceMaster);
        void Update(TblInvoiceMaster invoiceMaster);
        void Delete(string guid);

    }
}

using Example1.Dal.Abstract;
using Example1.Dal.Entities;
using Example1.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Example1.Mvc.Controllers
{
    public class InvoiceController : ApiController
    {
        private IInvoiceMasterRepository repository;
        private ICustomerRepository customerRepository;
        private IProductRepository productRepository;


        public InvoiceController(IInvoiceMasterRepository repo , ICustomerRepository customerRepo , IProductRepository productRepo)
        {
            this.repository = repo;
            this.customerRepository = customerRepo;
            this.productRepository = productRepo;
        }

        public IEnumerable<object> Get()
        {
            return repository.Search();
        }

       
        public DataAndCount Get(string text, int skip, int take)
        {
            DataAndCount dc = new DataAndCount();
            dc.Data = repository.Search(text, skip, take);
            dc.Count = repository.Count(text);
            return dc;
        }


        public AddOrUpdate Get(string guid, bool IsNew)
        {
            AddOrUpdate ae = new AddOrUpdate();
            ae.Data = repository.GetOne(guid, IsNew);
            ae.Customers = customerRepository.Search();
            ae.Products = productRepository.Search();
            return ae;
        }

        public void Post([FromBody]TblInvoiceMaster invoiceMaster)
        {

            repository.Insert(invoiceMaster);
        }

        public void Put([FromBody]TblInvoiceMaster invoiceMaster)
        {

            repository.Update(invoiceMaster);
        }

        public void Delete(string id)
        {
            repository.Delete(id);
        }
    }
}

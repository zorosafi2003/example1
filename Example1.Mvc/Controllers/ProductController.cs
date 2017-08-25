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
    public class ProductController : ApiController
    {
        private IProductRepository repository;


        public ProductController(IProductRepository repo)
        {
            this.repository = repo;
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

            return ae;
        }

        public void Post([FromBody]TblProduct product)
        {
            repository.Insert(product);
        }

        public void Put([FromBody]TblProduct product)
        {

            repository.Update(product);
        }

        public void Delete(string id)
        {
            repository.Delete(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Example1.Mvc.Models
{
    public class DataAndCount
    {
        public IEnumerable<object> Data { get; set; }
        public int Count { get; set; }
    }
}
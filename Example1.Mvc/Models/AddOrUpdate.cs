﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Example1.Mvc.Models
{
    public class AddOrUpdate
    {
        public object Data { get; set; }
        public IEnumerable<object> Products { get; set; }
        public IEnumerable< object> Customers { get; set; }
    }
}
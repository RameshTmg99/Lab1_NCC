using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string SerialNumber { get; set; }

        public string Company { get; set; }

        //Collection navigation property
        //public ICollection<Employee> employees { get; set; }
    }
}
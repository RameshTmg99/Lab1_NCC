using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab1.Models
{
    public class DataContext:DbContext
    {
        public DataContext() : base("conn")
        {

        }
        public DbSet<Product> products { get; set; }
    }
}
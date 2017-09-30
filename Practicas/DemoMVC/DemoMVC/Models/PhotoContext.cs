using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DemoMVC.Models
{
    public class PhotoContext : DbContext
    {
        public DbSet<Photo> Photos { get; set; }
    }
}
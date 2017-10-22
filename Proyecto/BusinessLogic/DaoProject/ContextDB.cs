using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DaoProject
{
    public class ContextDB : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
    }
}
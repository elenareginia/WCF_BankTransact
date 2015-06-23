using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Domain;

namespace MainService
{
    public class EfDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
    }
}

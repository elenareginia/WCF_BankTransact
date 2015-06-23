using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Domain;

namespace MoneyAddService
{
    public class EfDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
    }
}
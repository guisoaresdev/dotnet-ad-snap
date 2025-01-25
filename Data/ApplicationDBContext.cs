using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi_anuncios.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_webapi_anuncios.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options): base(options) {}
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Service> Services { get; set; }
        
    }
}
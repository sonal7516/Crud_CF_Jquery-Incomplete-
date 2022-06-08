using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crud_CF_Jquery.Models;

namespace Crud_CF_Jquery.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options): base(options) { }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Product> Products { get; set; }

    }
}

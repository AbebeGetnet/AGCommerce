using AGCommerce.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGCommerce.Data.Data
{
    public class AGCommerceDbContext : DbContext
    {
        public AGCommerceDbContext(DbContextOptions<AGCommerceDbContext> options) : base(options)
        {

        } 
        public DbSet<Category> Categories { get; set; }
    }
}

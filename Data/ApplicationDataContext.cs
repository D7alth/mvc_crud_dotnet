using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crud.Models;
using Microsoft.EntityFrameworkCore;

namespace crud.Data
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
        {
            
        }
        
        public DbSet<Category> Categories { get; set; }
    }

}
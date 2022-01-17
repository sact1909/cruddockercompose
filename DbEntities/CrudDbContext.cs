using cruddockercompose.DbEntities.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cruddockercompose.DbEntities
{
    public class CrudDbContext : DbContext
    {
        
        public DbSet<User> User { get; set; }
        public CrudDbContext(DbContextOptions<CrudDbContext> options)
           : base(options)
        {
        }

        public CrudDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<User>(us=> {
                us.HasKey(a => a.Id);
                us.Property(p => p.Id).HasDefaultValueSql("NEWID()");
            });
        }
    }
}

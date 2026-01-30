using BE_012026.DataAccess.NetCore.DataObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_012026.DataAccess.NetCore.Dbcontext
{
    public class BE_012026Dbcontext : DbContext
    {
        public BE_012026Dbcontext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Product> product { get; set; }
        public virtual DbSet<Category> category { get; set; }
        public virtual DbSet<Account> account { get; set; }
    }
}

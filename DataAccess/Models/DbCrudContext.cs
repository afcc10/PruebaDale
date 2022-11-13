using Microsoft.EntityFrameworkCore;
using System.IO;


namespace DataAccess.Models
{
    public partial class DbCrudContext : DbContext    
    {
        public DbCrudContext()
        {
        }

        public DbCrudContext(DbContextOptions<DbCrudContext> options) : base(options)
        {
        }

        public virtual DbSet<Producto> Producto { get; set; }

        public virtual DbSet<Cliente> Cliente { get; set; }

        public virtual DbSet<Venta> Venta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

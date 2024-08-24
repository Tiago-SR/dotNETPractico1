using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL {
    public class DBContext : DbContext {
        private string _connectionString = "Server=localhost,1400;Database=practico;User Id=sa; Password=Abc*123!;Encrypt=False;";

        public DBContext() { }

        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PersonaEF>()
                .HasIndex(p => p.Documento)
                .IsUnique();
        }

        public DbSet<PersonaEF> Personas { get; set; }
        public DbSet<VehiculoEF> Vehiculos { get; set; }
    }
}

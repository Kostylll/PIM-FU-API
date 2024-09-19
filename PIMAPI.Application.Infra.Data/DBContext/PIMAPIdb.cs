using Microsoft.EntityFrameworkCore;
using PIMAPI.Application.Abstraction.Domain.DTO;
using Microsoft.EntityFrameworkCore.Design;

namespace PIMAPI.Application.Infra.Data.DBContext
{
    public class PIMAPIdb : DbContext
    {
        public static string schema => "PIMAPIdb";

        public DbSet<Colaboradores> Colaboradores { get; set; }
        public DbSet<Vendas> Vendas { get; set; }
        public DbSet <Fornecedores> Fornecedores { get; set; }
        public DbSet<Produtos> Produtos { get; set; }

        public PIMAPIdb(DbContextOptions<PIMAPIdb> options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            modelBuilder.Entity<Colaboradores>().Property(x => x.Id).HasDefaultValue("NEWID()");



            base.OnModelCreating(modelBuilder);
        }

        public class IntegrationContextFactory : IDesignTimeDbContextFactory<PIMAPIdb>
        {
            public PIMAPIdb CreateDbContext(string[] args)
            {
                var optionBuilder = new DbContextOptionsBuilder<PIMAPIdb>();

                optionBuilder.UseSqlServer("Data Source=localhost;Database=PIMAPIdb;Trusted_Connection=True;Trust Server Certificate = true;");

                return new PIMAPIdb(optionBuilder.Options);
            }
        }
    }
}

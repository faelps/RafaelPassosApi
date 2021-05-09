using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RafaelPassosApi.Models.Context.Mapping;
using System.Linq;

namespace RafaelPassosApi.Models.Context
{
    public class PessoaContext: DbContext
    {
        private readonly IConfiguration configuration;
        public PessoaContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public DbSet<Pessoa> Pessoa { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(string)))
            {
                if (property.GetMaxLength() == null)
                    property.SetColumnType("varchar(200)");
            }
            modelBuilder.ApplyConfiguration(new PessoaMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("PessoaContext"));
            base.OnConfiguring(optionsBuilder);
        }
    }
}

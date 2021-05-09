using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RafaelPassosApi.Models.Enums;

namespace RafaelPassosApi.Models.Context.Mapping
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Cpf).IsRequired().HasColumnType("varchar(11)");
            builder.Property(x => x.Sexo).IsRequired().HasColumnType("varchar(20)").HasConversion(v => v.ToString(), v => (Sexo)System.Enum.Parse(typeof(Sexo), v));
        }
    }
}

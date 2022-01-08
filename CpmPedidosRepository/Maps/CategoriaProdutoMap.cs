using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CpmPedidos.Repository
{
    public class CategoriaProdutoMap : BaseDomainMap<CategoriaProduto>
    {
      public  CategoriaProdutoMap() : base("tb_categoriaProduto") { }

        public new void Configure(EntityTypeBuilder<CategoriaProduto> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Ativo).HasColumnName("ativo").IsRequired();

        }
    }
}

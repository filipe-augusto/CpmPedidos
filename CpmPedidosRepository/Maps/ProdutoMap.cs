using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository
{
    public class ProdutoMap : BaseDomainMap<Produto>
    {
       public ProdutoMap() : base("tb_produto") { }

        public new void Configure(EntityTypeBuilder<Produto> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Codigo).HasColumnName("codigo").HasMaxLength(2).IsRequired();
            builder.Property(x => x.Descricao).HasColumnName("descricao").IsRequired().HasMaxLength(200);
            builder.Property(x => x.Preco).HasColumnName("preco").HasPrecision(17,12).IsRequired();
            builder.Property(x => x.Ativo).HasColumnName("ativo").IsRequired();


            builder.Property(x => x.IdCategoria).HasColumnName("id_categoria").IsRequired();
            builder.HasOne(x => x.Categoria).WithMany(x => x.Produtos).HasForeignKey(x => x.IdCategoria);
        }
    }
}

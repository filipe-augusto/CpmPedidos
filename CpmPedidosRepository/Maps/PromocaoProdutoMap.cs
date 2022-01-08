using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository
{
    public class PromocaoProdutoMap : BaseDomainMap<PromocaoProduto>
    {
      public  PromocaoProdutoMap() : base("tb_promocaoProduto") { }

        public new void Configure(EntityTypeBuilder<PromocaoProduto> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Preco).HasColumnName("preco").HasPrecision(17,2).IsRequired();
            builder.Property(x => x.Ativo).HasColumnName("ativo").IsRequired();

            builder.Property(x => x.IdProduto).HasColumnName("id_produto").IsRequired();
            builder.HasOne(x => x.Produto).WithMany(x => x.Promocoes).HasForeignKey(x => x.IdProduto);
        }
    }
}

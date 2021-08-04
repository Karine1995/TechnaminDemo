using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Infrastructure
{
    public class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(e => e.CreationDate)
                .IsRequired(true)
                .HasDefaultValueSql("SYSUTCDATETIME()");

            builder.Property(e => e.LastUpdateTime)
                .IsRequired(true)
                .HasDefaultValueSql("SYSUTCDATETIME()");
        }
    }
}

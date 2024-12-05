using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorRepository
{
    public class EntityBaseConfiguration<T> : IEntityTypeConfiguration<T> where T : EntityBase
    {
        protected virtual bool ApplyQueryFilter => true;
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.ToTable(typeof(T).Name);

            //builder.Property(e => e.Id)
            //    .HasDefaultValueSql("newsequentialid()");

            builder.Property(e => e.IsDeleted)
                .HasDefaultValue(false);

            if (ApplyQueryFilter)
            {
                builder.HasQueryFilter(p => p.IsDeleted == false);
            }
        }
    }
}

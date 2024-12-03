using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorData.Configuration
{
    internal class EntityBaseConfiguration<T> : IEntityTypeConfiguration<T> where T : EntityBase
    {
        protected virtual bool ApplyQueryFilter => true;
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.ToTable(typeof(T).Name);

            builder.Property(e => e.Id)
                .HasDefaultValueSql("newsequentialid()");

            builder.Property(e => e.IsDeleted)
                .HasDefaultValue(false);

            if (ApplyQueryFilter)
            {
                builder.HasQueryFilter(p => p.IsDeleted == false);
            }

            builder.HasOne(e => e.Creator)
                .WithMany()
                .HasForeignKey(e => e.CreatedBy)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.UpdatedByUser)
                .WithMany()
                .HasForeignKey(e => e.UpdatedBy)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

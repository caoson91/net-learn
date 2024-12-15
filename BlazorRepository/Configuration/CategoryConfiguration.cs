using BlazorRepository.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorRepository.Configuration
{
    public class CategoryConfiguration : EntityBaseConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);

            builder.HasData(
                 new Category { Id = 1, Name = "Food & Beverage", Level = 0 },
                 new Category { Id = 2, Name = "Agriculture", Level = 0 },
                 new Category { Id = 3, Name = "Apparel & Accessories", Level = 0 }
                );
        }
    }
}

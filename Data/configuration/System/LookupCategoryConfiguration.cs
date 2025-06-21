using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qimmah.Data.System;
using Qimmah.Enums.System;

namespace Qimmah.Data.configuration.System;

public class LookupsCategoryConfiguration : IEntityTypeConfiguration<LookupCategory>
{
    public void Configure(EntityTypeBuilder<LookupCategory> builder)
    {
        builder.ToTable("LookupCategories", "System");
        builder.HasData(new List<LookupCategory>
        {
            new LookupCategory
            {
                ID = LookupCategoryEnum.Countries.ToAnyType<int>(),
                Description = "List of countries",
            },
            new LookupCategory
            {
                ID = LookupCategoryEnum.Cities.ToAnyType<int>(),
                Description = "List of cities",

            },
            new LookupCategory
            {
                ID = 200,
                Description = "Program Categories",
                OrderID = 1
            }
        });
    }

}

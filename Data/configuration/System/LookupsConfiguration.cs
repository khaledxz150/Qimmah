using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qimmah.Data.System;
using Qimmah.Enums.System;

namespace Qimmah.Data.configuration.System;

public class LookupsConfiguration : IEntityTypeConfiguration<Lookup>
{
    public void Configure(EntityTypeBuilder<Lookup> builder)
    {
        builder.ToTable("Lookups", "System");
        builder.Property(p => p.StringValue)
            .HasMaxLength(500)
            .IsRequired(false);
        builder.HasData(new List<Lookup>
        {
            new Lookup
            {
                ID = CountriesEnum.Jordan.ToAnyType<int>(),
                Description = "Jordan",
                CategoryID = LookupCategoryEnum.Countries.ToAnyType<int>(),
                DictionaryID = 1001
            },
            new Lookup
            {
                ID = CountriesEnum.Palestine.ToAnyType<int>(),
                Description = "Palestine",
                CategoryID = LookupCategoryEnum.Countries.ToAnyType<int>(),
                DictionaryID = 1002
            },
            new Lookup
            {
                ID = CountriesEnum.Lebanon.ToAnyType<int>(),
                Description = "Lebanon",
                CategoryID = LookupCategoryEnum.Countries.ToAnyType<int>(),
                DictionaryID = 1003
            },
            new Lookup
            {
                ID = CountriesEnum.Syria.ToAnyType<int>(),
                Description = "Syria",
                CategoryID = LookupCategoryEnum.Countries.ToAnyType<int>(),
                DictionaryID = 1004
            },
            new Lookup
            {
                ID = CountriesEnum.Iraq.ToAnyType<int>(),
                Description = "Iraq",
                CategoryID = LookupCategoryEnum.Countries.ToAnyType<int>(),
                DictionaryID = 1005
            },
            new Lookup
            {
                ID = CountriesEnum.SaudiArabia.ToAnyType<int>(),
                Description = "Saudi Arabia",
                CategoryID = LookupCategoryEnum.Countries.ToAnyType<int>(),
                DictionaryID = 1006
            },
            new Lookup
            {
                ID = CountriesEnum.Kuwait.ToAnyType<int>(),
                Description = "Kuwait",
                CategoryID = LookupCategoryEnum.Countries.ToAnyType<int>(),
                DictionaryID = 1007
            },
            new Lookup
            {
                ID = CountriesEnum.Bahrain.ToAnyType<int>(),
                Description = "Bahrain",
                CategoryID = LookupCategoryEnum.Countries.ToAnyType<int>(),
                DictionaryID = 1008
            },
            new Lookup
            {
                ID = CountriesEnum.Qatar.ToAnyType<int>(),
                Description = "Qatar",
                CategoryID = LookupCategoryEnum.Countries.ToAnyType<int>(),
                DictionaryID = 1009
            },
            new Lookup
            {
                ID = CountriesEnum.UAE.ToAnyType<int>(),
                Description = "United Arab Emirates",
                CategoryID = LookupCategoryEnum.Countries.ToAnyType<int>(),
                DictionaryID = 1010
            },
            new Lookup
            {
                ID = CountriesEnum.Oman.ToAnyType<int>(),
                Description = "Oman",
                CategoryID = LookupCategoryEnum.Countries.ToAnyType<int>(),
                DictionaryID = 1011
            },
            new Lookup
            {
                ID = CountriesEnum.Yemen.ToAnyType<int>(),
                Description = "Yemen",
                CategoryID = LookupCategoryEnum.Countries.ToAnyType<int>(),
                DictionaryID = 1012
            },
            new Lookup
            {
                ID = CountriesEnum.Egypt.ToAnyType<int>(),
                Description = "Egypt",
                CategoryID = LookupCategoryEnum.Countries.ToAnyType<int>(),
                DictionaryID = 1013
            },
            new Lookup
            {
                ID = CountriesEnum.Turkey.ToAnyType<int>(),
                Description = "Turkey",
                CategoryID = LookupCategoryEnum.Countries.ToAnyType<int>(),
                DictionaryID = 1014
            },
            new Lookup
            {
                ID = CountriesEnum.Iran.ToAnyType<int>(),
                Description = "Iran",
                CategoryID = LookupCategoryEnum.Countries.ToAnyType<int>(),
                DictionaryID = 1015
            }




        });
    }

}

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
                DictionaryID = 1001,
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
            },

        });

        builder.HasData(new List<Lookup>
{
    // Jordan
    new Lookup
    {
        ID = CitiesEnum.Amman.ToAnyType<int>(),
        Description = "Amman",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 193,
        ParentID = CountriesEnum.Jordan.ToAnyType<int>()
    },
    new Lookup
    {
        ID = CitiesEnum.Irbid.ToAnyType<int>(),
        Description = "Irbid",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 194,
        ParentID = CountriesEnum.Jordan.ToAnyType<int>()
    },
    new Lookup
    {
        ID = CitiesEnum.Zarqa.ToAnyType<int>(),
        Description = "Zarqa",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 195,
        ParentID = CountriesEnum.Jordan.ToAnyType<int>()
    },
    new Lookup
    {
        ID = CitiesEnum.Aqaba.ToAnyType<int>(),
        Description = "Aqaba",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 196,
        ParentID = CountriesEnum.Jordan.ToAnyType<int>()
    },

    // Palestine
    new Lookup
    {
        ID = CitiesEnum.Ramallah.ToAnyType<int>(),
        Description = "Ramallah",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 197,
        ParentID = CountriesEnum.Palestine.ToAnyType<int>()
    },
    new Lookup
    {
        ID = CitiesEnum.Nablus.ToAnyType<int>(),
        Description = "Nablus",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 198,
        ParentID = CountriesEnum.Palestine.ToAnyType<int>()
    },
    new Lookup
    {
        ID = CitiesEnum.Hebron.ToAnyType<int>(),
        Description = "Hebron",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 199,
        ParentID = CountriesEnum.Palestine.ToAnyType<int>()
    },
    new Lookup
    {
        ID = CitiesEnum.Gaza.ToAnyType<int>(),
        Description = "Gaza",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 200,
        ParentID = CountriesEnum.Palestine.ToAnyType<int>()
    },

    // Lebanon
    new Lookup
    {
        ID = CitiesEnum.Beirut.ToAnyType<int>(),
        Description = "Beirut",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 201,
        ParentID = CountriesEnum.Lebanon.ToAnyType<int>()
    },
    new Lookup
    {
        ID = CitiesEnum.Tripoli_Lebanon.ToAnyType<int>(),
        Description = "Tripoli",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 202,
        ParentID = CountriesEnum.Lebanon.ToAnyType<int>()
    },
    new Lookup
    {
        ID = CitiesEnum.Sidon.ToAnyType<int>(),
        Description = "Sidon",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 203,
        ParentID = CountriesEnum.Lebanon.ToAnyType<int>()
    },

    // Syria
    new Lookup
    {
        ID = CitiesEnum.Damascus.ToAnyType<int>(),
        Description = "Damascus",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 204,
        ParentID = CountriesEnum.Syria.ToAnyType<int>()
    },
    new Lookup
    {
        ID = CitiesEnum.Aleppo.ToAnyType<int>(),
        Description = "Aleppo",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 205,
        ParentID = CountriesEnum.Syria.ToAnyType<int>()
    },
    new Lookup
    {
        ID = CitiesEnum.Homs.ToAnyType<int>(),
        Description = "Homs",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 206,
        ParentID = CountriesEnum.Syria.ToAnyType<int>()
    },

    // Iraq
    new Lookup
    {
        ID = CitiesEnum.Baghdad.ToAnyType<int>(),
        Description = "Baghdad",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 207,
        ParentID = CountriesEnum.Iraq.ToAnyType<int>()
    },
    new Lookup
    {
        ID = CitiesEnum.Basra.ToAnyType<int>(),
        Description = "Basra",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 208,
        ParentID = CountriesEnum.Iraq.ToAnyType<int>()
    },
    new Lookup
    {
        ID = CitiesEnum.Erbil.ToAnyType<int>(),
        Description = "Erbil",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 209,
        ParentID = CountriesEnum.Iraq.ToAnyType<int>()
    },

    // Saudi Arabia
    new Lookup
    {
        ID = CitiesEnum.Riyadh.ToAnyType<int>(),
        Description = "Riyadh",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 210,
        ParentID = CountriesEnum.SaudiArabia.ToAnyType<int>()
    },
    new Lookup
    {
        ID = CitiesEnum.Jeddah.ToAnyType<int>(),
        Description = "Jeddah",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 211,
        ParentID = CountriesEnum.SaudiArabia.ToAnyType<int>()
    },
    new Lookup
    {
        ID = CitiesEnum.Dammam.ToAnyType<int>(),
        Description = "Dammam",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 212,
        ParentID = CountriesEnum.SaudiArabia.ToAnyType<int>()
    },
    new Lookup
    {
        ID = CitiesEnum.Mecca.ToAnyType<int>(),
        Description = "Mecca",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 213,
        ParentID = CountriesEnum.SaudiArabia.ToAnyType<int>()
    },
    new Lookup
    {
        ID = CitiesEnum.Medina.ToAnyType<int>(),
        Description = "Medina",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 214,
        ParentID = CountriesEnum.SaudiArabia.ToAnyType<int>()
    },

    // Kuwait
    new Lookup
    {
        ID = CitiesEnum.KuwaitCity.ToAnyType<int>(),
        Description = "Kuwait City",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 215,
        ParentID = CountriesEnum.Kuwait.ToAnyType<int>()
    },

    // Bahrain
    new Lookup
    {
        ID = CitiesEnum.Manama.ToAnyType<int>(),
        Description = "Manama",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 216,
        ParentID = CountriesEnum.Bahrain.ToAnyType<int>()
    },

    // Qatar
    new Lookup
    {
        ID = CitiesEnum.Doha.ToAnyType<int>(),
        Description = "Doha",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 217,
        ParentID = CountriesEnum.Qatar.ToAnyType<int>()
    },

    // UAE
    new Lookup
    {
        ID = CitiesEnum.AbuDhabi.ToAnyType<int>(),
        Description = "Abu Dhabi",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 218,
        ParentID = CountriesEnum.UAE.ToAnyType<int>()
    },
    new Lookup
    {
        ID = CitiesEnum.Dubai.ToAnyType<int>(),
        Description = "Dubai",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 219,
        ParentID = CountriesEnum.UAE.ToAnyType<int>()
    },
    new Lookup
    {
        ID = CitiesEnum.Sharjah.ToAnyType<int>(),
        Description = "Sharjah",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 220,
        ParentID = CountriesEnum.UAE.ToAnyType<int>()
    },

    // Oman
    new Lookup
    {
        ID = CitiesEnum.Muscat.ToAnyType<int>(),
        Description = "Muscat",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 221,
        ParentID = CountriesEnum.Oman.ToAnyType<int>()
    },
    new Lookup
    {
        ID = CitiesEnum.Salalah.ToAnyType<int>(),
        Description = "Salalah",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 222,
        ParentID = CountriesEnum.Oman.ToAnyType<int>()
    },

    // Yemen
    new Lookup
    {
        ID = CitiesEnum.Sana_a.ToAnyType<int>(),
        Description = "Sana'a",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 223,
        ParentID = CountriesEnum.Yemen.ToAnyType<int>()
    },
    new Lookup
    {
        ID = CitiesEnum.Aden.ToAnyType<int>(),
        Description = "Aden",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 224,
        ParentID = CountriesEnum.Yemen.ToAnyType<int>()
    },

    // Egypt
    new Lookup
    {
        ID = CitiesEnum.Cairo.ToAnyType<int>(),
        Description = "Cairo",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 225,
        ParentID = CountriesEnum.Egypt.ToAnyType<int>()
    },
    new Lookup
    {
        ID = CitiesEnum.Alexandria.ToAnyType<int>(),
        Description = "Alexandria",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 226,
        ParentID = CountriesEnum.Egypt.ToAnyType<int>()
    },
    new Lookup
    {
        ID = CitiesEnum.Giza.ToAnyType<int>(),
        Description = "Giza",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 227,
        ParentID = CountriesEnum.Egypt.ToAnyType<int>()
    },

    // Turkey
    new Lookup
    {
        ID = CitiesEnum.Istanbul.ToAnyType<int>(),
        Description = "Istanbul",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 228,
        ParentID = CountriesEnum.Turkey.ToAnyType<int>()
    },
    new Lookup
    {
        ID = CitiesEnum.Ankara.ToAnyType<int>(),
        Description = "Ankara",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 229,
        ParentID = CountriesEnum.Turkey.ToAnyType<int>()
    },
    new Lookup
    {
        ID = CitiesEnum.Izmir.ToAnyType<int>(),
        Description = "Izmir",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 230,
        ParentID = CountriesEnum.Turkey.ToAnyType<int>()
    },

    // Iran
    new Lookup
    {
        ID = CitiesEnum.Tehran.ToAnyType<int>(),
        Description = "Tehran",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 231,
        ParentID = CountriesEnum.Iran.ToAnyType<int>()
    },
    new Lookup
    {
        ID = CitiesEnum.Mashhad.ToAnyType<int>(),
        Description = "Mashhad",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 232,
        ParentID = CountriesEnum.Iran.ToAnyType<int>()
    },
    new Lookup
    {
        ID = CitiesEnum.Isfahan.ToAnyType<int>(),
        Description = "Isfahan",
        CategoryID = LookupCategoryEnum.Cities.ToAnyType<int>(),
        DictionaryID = 233,
        ParentID = CountriesEnum.Iran.ToAnyType<int>()
    }
});

    }

}

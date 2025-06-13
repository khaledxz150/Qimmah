
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qimmah.Data.System;

namespace Qimmah.Data.configuration.System;

public class CountrySeeding : IEntityTypeConfiguration<Lookup>
{

    public void Configure(EntityTypeBuilder<Lookup> builder)
    {
        builder.HasKey(x => x.ID);
    }

}

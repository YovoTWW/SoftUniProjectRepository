using EuropeBJJ.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EuropeBJJ.Data.Configuration
{
    public class SecondConfiguration : IEntityTypeConfiguration<EventProfile>
    {
        public void Configure(EntityTypeBuilder<EventProfile> builder)
        {
            builder.HasKey(oea => new { oea.EventId, oea.ProfileId });
        }
    }        
}

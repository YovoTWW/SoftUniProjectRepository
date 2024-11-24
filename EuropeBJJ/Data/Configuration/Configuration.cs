using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EuropeBJJ.Data.Models;

namespace EuropeBJJ.Data.Configuration
{
    public class Configuration : IEntityTypeConfiguration<EventAccount>
    {
        public void Configure(EntityTypeBuilder<EventAccount> builder)
        {
            builder.HasKey(oea => new { oea.EventId, oea.AccountId });
        }
    }
}

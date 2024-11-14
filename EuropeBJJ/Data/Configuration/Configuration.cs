using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EuropeBJJ.Data.Models;

namespace EuropeBJJ.Data.Configuration
{
    public class Configuration : IEntityTypeConfiguration<OrganizedEventAccount>
    {
        public void Configure(EntityTypeBuilder<OrganizedEventAccount> builder)
        {
            builder.HasKey(oea => new { oea.OrganizedEventId, oea.AccountId });
        }
    }
}

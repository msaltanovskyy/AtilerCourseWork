using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtilerCourseWork.Configuration
{
    public class PositionConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
            new IdentityRole
            {
                Id = "1",
                Name = "Master",
                NormalizedName = "MASTER"
            },
            new IdentityRole
            {
                Id = "2",
                Name = "Manager",
                NormalizedName = "MANAGER"
            });
        }
    }
}

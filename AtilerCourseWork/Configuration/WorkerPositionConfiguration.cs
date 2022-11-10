using AtilerCourseWork.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtilerCourseWork.Configuration
{
    public class WorkerPositionConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
            new IdentityUserRole<string>
            {
                RoleId = "1",
                UserId = "1",
            },
            new IdentityUserRole<string>
            {
                RoleId = "2",
                UserId = "2",
            },
            new IdentityUserRole<string>
            {
                RoleId = "2",
                UserId = "3",
            });
        }
    }
}

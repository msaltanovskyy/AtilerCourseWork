using AtilerCourseWork.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtilerCourseWork.Configuration
{
    public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
    {

        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            var worker1 = new Worker
            {
                Id = "1",
                UserName = "manager@gmail.com",
                NormalizedEmail = "MANAGER@GMAIL.COM",
                Email = "manager@gmail.com",
                NormalizedUserName = "MANAGER@GMAIL.COM",
                Name = "Manager",
                Surname = "Manager",
                Secondname = "Manager",
                Salary = 15000,
                Phone = "+380999999",
                StartWork = DateTime.UtcNow,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };

            var worker2 = new Worker
            {
                Id = "2",
                UserName = "master@gmail.com",
                NormalizedEmail = "MASTER@GMAIL.COM",
                Email = "master@gmail.com",
                NormalizedUserName = "MASTER@GMAIL.COM",
                Name = "Master",
                Surname = "Master",
                Secondname = "Master",
                Salary = 15000,
                Phone = "+380999999",
                StartWork = DateTime.UtcNow,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };
            var worker3 = new Worker
            {
                Id = "3",
                UserName = "master2@gmail.com",
                NormalizedEmail = "MASTER2@GMAIL.COM",
                Email = "master2@gmail.com",
                NormalizedUserName = "MASTER2@GMAIL.COM",
                Name = "Master2",
                Surname = "Master2",
                Secondname = "Master2",
                Salary = 15000,
                Phone = "+380999999",
                StartWork = DateTime.UtcNow,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };

            var hasher = new PasswordHasher<Worker>();
            worker1.PasswordHash = hasher.HashPassword(worker1, "Manager1@");
            worker2.PasswordHash = hasher.HashPassword(worker2, "Master1@");
            worker3.PasswordHash = hasher.HashPassword(worker3, "Master2@");
            builder.HasData(worker1, worker2, worker3);

            
        }
    }
}

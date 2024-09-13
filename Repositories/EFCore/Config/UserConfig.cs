using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Repositories.EFCore.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User { Id = 1, Name = "Talha", Surname = "Zeren", City = "Malatya" },
                new User { Id = 2, Name = "Orkun", Surname = "Özdemir", City = "Ankara" },
                new User { Id = 3, Name = "Şevval", Surname = "Kaymazlı", City = "Ankara" }
                );
        }
    }
}

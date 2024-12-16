using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Database.EntityTypeBuilder;

namespace Utils.Database.EntityTypeBuilder.Configurations
{
    internal class Class1EntityConfiguration : IEntityTypeConfiguration<Class1>
    {
        public void Configure(EntityTypeBuilder<Class1> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}

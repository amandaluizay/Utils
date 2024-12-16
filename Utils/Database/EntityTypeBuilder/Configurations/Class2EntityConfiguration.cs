using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Utils.Database.EntityTypeBuilder;

namespace Utils.Database.EntityTypeBuilder.Configurations
{
    internal class Class2EntityConfiguration : IEntityTypeConfiguration<Class2>
    {
        public void Configure(EntityTypeBuilder<Class2> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(i => i.Class1)
           .WithMany(i => i.Class2s)
           .HasForeignKey(p => p.Class1Id)
           .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

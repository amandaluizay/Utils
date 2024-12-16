using Microsoft.EntityFrameworkCore;
using Utils.Database.EntityTypeBuilder;

namespace Utils.Database.DbContexts
{
    public class MyDbContext(DbContextOptions<MyDbContext> options) : DbContext(options)
    {
        DbSet<Class1> Class1s { get; set; }
        DbSet<Class2> Class2s { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}


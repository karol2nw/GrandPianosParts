
using GrandPianosParts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace GrandPianosParts.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<PianoParts> PianoParts => Set<PianoParts>();
        public DbSet<Hammer> Hammers => Set<Hammer>();
        public DbSet<Schank> Schanks => Set<Schank>();
        public DbSet<DamperFilz> DamperFilzs => Set<DamperFilz>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("GrandPianosPartsStorage");
        }

    }
}

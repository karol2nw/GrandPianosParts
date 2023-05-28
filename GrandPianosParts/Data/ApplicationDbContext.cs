
using GrandPianosParts.Entities;
using Microsoft.EntityFrameworkCore;

namespace GrandPianosParts.Data
{
    internal class ApplicationDbContext : DbContext
    {
        public DbSet<Hammer> Hammers => Set<Hammer>();


    }
}

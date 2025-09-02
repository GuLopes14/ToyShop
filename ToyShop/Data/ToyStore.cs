using Microsoft.EntityFrameworkCore;
using ToyStore.Models;

namespace ToyStore.Data
{
    public class ToyStoreContext : DbContext
    {
        public ToyStoreContext(DbContextOptions<ToyStoreContext> options) : base(options) { }

        public DbSet<Brinquedo> Brinquedos { get; set; }
    }
}
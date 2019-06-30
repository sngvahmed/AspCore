using Market.component.item;
using Microsoft.EntityFrameworkCore;

namespace Market.Config
{
    public class MarketDbContext: DbContext
    {
        public MarketDbContext(DbContextOptions<MarketDbContext> options) : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }
    }
}

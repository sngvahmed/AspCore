using Market.Component.Item;
using System;

namespace Market.Config
{
    public static class DBIntializer
    {
        public static void Seed(MarketDbContext context)
        {
            int r1 = (new Random().Next() * 1000) % 1000;
            int r2 = (new Random().Next() * 1000) % 1000;
            int r3 = (new Random().Next() * 1000) % 1000;

            context.AddRange(
                new Item { Id = Guid.NewGuid(), Description = $"Mack pro {r1}", ImageThumbnailUrl = "assets/laptop.png", ImageUrl = "assets/apple.png", Price = 8762.4, Name = $"Macbook Pro {r1}" },
                new Item { Id = Guid.NewGuid(), Description = $"Hp laptop {r2}", ImageThumbnailUrl = "assets/laptop.png", ImageUrl = "assets/hp.png", Price = 1224.1, Name = $"Hp Laptop v123 {r2}" },
                new Item { Id = Guid.NewGuid(), Description = $"Lenovo Beko {r3}", ImageThumbnailUrl = "assets/laptop.png", ImageUrl = "assets/lenovo.png", Price = 4122.4, Name = $"Lenovo beko {r3}" }
            );

            context.SaveChanges();
        }
    }
}
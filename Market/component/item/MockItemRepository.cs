using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.component.item
{
    public class MockItemRepository : IItemRepository
    {
        List<Item> items;

        public MockItemRepository()
        {
            if (items == null)
            {
                IntializeItems();
            }
        }

        private void IntializeItems()
        {
            items = new List<Item>
            {
                new Item {Id = Guid.NewGuid(), Description = "Mack pro", ImageThumbnailUrl = "assets/laptop.png", ImageUrl = "assets/apple.png", Price = 8762.4, Name = "Macbook Pro"},
                new Item {Id = Guid.NewGuid(), Description = "Hp laptop", ImageThumbnailUrl = "assets/laptop.png", ImageUrl = "assets/hp.png", Price = 1224.1, Name = "Hp Laptop v123"},
                new Item {Id = Guid.NewGuid(), Description = "Lenovo", ImageThumbnailUrl = "assets/laptop.png", ImageUrl = "assets/lenovo.png", Price = 4122.4, Name = "Lenovo legion"}
            };
        }

        public IEnumerable<Item> GetAllItem()
        {
            return items;
        }

        public Item GetById(Guid id)
        {
            return items.Where(i => i.Id == id).FirstOrDefault();
        }
    }
}

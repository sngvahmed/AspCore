using Market.Component.Item;
using Market.Component.Item.Interface;
using Market.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Market.Component.Item
{
    public class ItemRepository: IItemRepository
    {
        private readonly MarketDbContext context;
        private readonly DbSet<Item> itemRepo;

        public ItemRepository(MarketDbContext marketDbContext)
        {
            this.itemRepo = marketDbContext.Items;
            this.context = marketDbContext;
        }

        public Item AddItem(Item item)
        {
            item.Id = Guid.NewGuid();
            EntityEntry<Item> result = itemRepo.Add(item);

            context.SaveChanges(); 

            return result.Entity;
        }

        public IEnumerable<Item> GetAllItem()
        {
            return itemRepo;
        }

        public Item GetById(Guid id)
        {
            return itemRepo.FirstOrDefault(i => i.Id == id);
        }

        public Item UpdateItem(Item item)
        {
            EntityEntry<Item> result = itemRepo.Update(item);

            context.SaveChanges();

            return result.Entity;
        }
    }
}

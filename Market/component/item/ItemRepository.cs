using Market.component.item.Interface;
using Market.Config;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Market.component.item
{
    public class ItemRepository: IItemRepository
    {
        private readonly MarketDbContext marketDbContext;

        public ItemRepository(MarketDbContext marketDbContext)
        {
            this.marketDbContext = marketDbContext;
        }

        public IEnumerable<Item> GetAllItem()
        {
            return marketDbContext.Items;
        }

        public Item GetById(Guid id)
        {
            return marketDbContext.Items.FirstOrDefault(i => i.Id == id);
        }
    }
}

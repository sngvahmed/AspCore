using System;
using System.Collections.Generic;

namespace Market.Component.Item.Interface
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetAllItem();
        Item GetById(Guid id);
        Item AddItem(Item item);

        Item UpdateItem(Item item);
    }
}

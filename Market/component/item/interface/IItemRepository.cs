using System;
using System.Collections.Generic;

namespace Market.component.item.Interface
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetAllItem();
        Item GetById(Guid id);
    }
}

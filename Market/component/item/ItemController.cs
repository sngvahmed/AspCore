using Market.component.item.Interface;
using Market.Config;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Market.component.item
{

    public class ItemController: MarketMainController
    {
        private readonly IItemRepository itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetItems()
        {
            return itemRepository.GetAllItem().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Item> GetItemById(Guid id)
        {
            return itemRepository.GetById(id);
        }
    }
}

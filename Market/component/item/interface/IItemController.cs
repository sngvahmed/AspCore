using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Market.component.item.Interface
{

    public interface IItemController
    {
        [HttpGet]
        ActionResult<IEnumerable<Item>> GetItems();

        [HttpGet("{id}")]
        ActionResult<Item> GetItemById(Guid id);
    }
}

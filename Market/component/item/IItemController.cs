using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.component.item
{
    
    public interface IItemController
    {
        [HttpGet]
        ActionResult<IEnumerable<Item>> GetItems();

        [HttpGet("{id}")]
        ActionResult<Item> GetItemById(Guid id);
    }
}

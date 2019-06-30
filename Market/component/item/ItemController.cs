using Market.Component.Item.Interface;
using Market.Config;
using Market.Util;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;

namespace Market.Component.Item
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
            List<Item> data = itemRepository.GetAllItem().ToList();
            var response = new MarketHttpResponse<List<Item>>(data, MarketResponseType.SUCCESS, data.Count);

            if (data.Any()) return Ok(response);

            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<Item> GetItemById(Guid id)
        {
            Item data = itemRepository.GetById(id);
            MarketHttpResponse<Item> response = new MarketHttpResponse<Item>(data, (data == null) ? MarketResponseType.NOT_FOUND : MarketResponseType.FOUND);

            if (data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<Item> AddItem(Item item)
        {
            try { 
                return Ok(itemRepository.AddItem(item));
            }
            catch (MarketControllerException exc)
            {
                return BadRequest(exc.Response);
            }
            catch (Exception exc)
            {
                string message = exc.Message;
                if (exc.InnerException != null) message += exc.InnerException.Message;

                return BadRequest(new MarketControllerException(message).Response);
            }
        }

        [HttpPut]
        public ActionResult<Item> UpdateItem(Item item)
        {
            try
            {
                return Ok(itemRepository.UpdateItem(item));
            }
            catch (MarketControllerException exc)
            {
                return BadRequest(exc.Response);
            }
            catch (Exception exc)
            {
                string message = exc.Message;
                if (exc.InnerException != null) message += exc.InnerException.Message;

                return BadRequest(new MarketControllerException(message).Response);
            }
        }
    }
}

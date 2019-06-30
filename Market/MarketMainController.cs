using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market
{
    [Route("api/v1/market/[controller]")]
    [ApiController]
    public class MarketMainController: ControllerBase
    {
        public MarketMainController()
        {

        }
    }
}

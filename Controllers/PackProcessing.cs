using ChargeProceesing.API.Models.Dtos;
//using ChargeProcessing.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace ChargeProcessing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackProcessing : ControllerBase
    {
        private readonly ILogger<PackProcessing> _logger;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(PackProcessing));
        public PackProcessing(ILogger<PackProcessing> logger)
        {

            _logger = logger;
        }
        //------------------------------------------------------------------------
        [HttpGet]
        public IActionResult GetPackProcessing([FromQuery] GetDto data)
        {



            if (data.comType == "Integral")
            {
                _log4net.Info("Getting Integral Type Charges");
                data.packageCharges = 100 * data.quantity;
                data.deliveryCharges = 200 * data.quantity;
            }
            else
            {
                _log4net.Info("Getting Accessory Type Charges");
                data.packageCharges = 50 * data.quantity;
                data.deliveryCharges = 100 * data.quantity;
            }
            return Ok(data);
        }
        //--------------------------------------------------------------------------------------
    }
}
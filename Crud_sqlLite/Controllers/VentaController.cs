using Business.Contract;
using Common.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Models;
using System.Threading.Tasks;
using System;
using Common.Utilities.Services;

namespace APisPruebaDale.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : ControllerBase
    {
        #region Propierties
        private readonly IVentaServices Service;
        private readonly ILogger<VentaController> _logger;
        #endregion

        #region Constructor
        public VentaController(IVentaServices service, ILogger<VentaController> logger)
        {
            Service = service;
            _logger = logger;
        }
        #endregion

        #region methods
        /// <summary>
        /// crear estudiantes
        /// </summary>
        /// <returns>Response bool</returns>
        /// <author>Andres Cabezas</author>
        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        public async Task<Response<bool>> Post(VentaDto venta)
        {
            Response<bool> response;
            try
            {
                response = await Service.createVenta(venta);
                return response;
            }
            catch (Exception ex)
            {
                return new Response<bool>
                {
                    Status = false,
                    Message = MessageExtension.AddMessageList(ex.Message)
                };
            }
        }
        #endregion

    }
}

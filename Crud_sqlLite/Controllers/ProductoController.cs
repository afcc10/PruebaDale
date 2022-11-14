using Business.Contract;
using Common.Helpers;
using Common.Utilities.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APisPruebaDale.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        #region Propierties
        private readonly IProductoServices Service;
        private readonly ILogger<ProductoController> _logger;
        #endregion

        #region Constructor
        public ProductoController(IProductoServices service, ILogger<ProductoController> logger)
        {
            Service = service;
            _logger = logger;
        }
        #endregion

        #region methods

        /// <summary>
        /// Obtener estudiantes
        /// </summary>
        /// <returns>Response model ProductoDto</returns>
        /// <author>Andres Cabezas</author>
        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(Response<List<ProductoDto>>), StatusCodes.Status200OK)]
        public async Task<Response<List<ProductoDto>>> Get()
        {
            Response<List<ProductoDto>> response;
            try
            {
                response = await Service.GetProductos();
                return response;
            }
            catch (Exception ex)
            {
                return new Response<List<ProductoDto>>
                {
                    Status = false,
                    Message = MessageExtension.AddMessageList(ex.Message)
                };
            }
        }

        /// <summary>
        /// crear estudiantes
        /// </summary>
        /// <returns>Response bool</returns>
        /// <author>Andres Cabezas</author>
        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        public async Task<Response<bool>> Post(ProductoDto student)
        {
            Response<bool> response;
            try
            {
                response = await Service.CreateProducto(student);
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

        /// <summary>
        /// actualizar estudiantes
        /// </summary>
        /// <returns>Response bool</returns>
        /// <author>Andres Cabezas</author>
        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        public async Task<Response<bool>> Update(ProductoDto student)
        {
            Response<bool> response;
            try
            {
                response = await Service.UpdateProducto(student);
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

        /// <summary>
        /// obtener estudiantes by id
        /// </summary>
        /// <returns>Response ProductoDto</returns>
        /// <author>Andres Cabezas</author>
        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(typeof(Response<ProductoDto>), StatusCodes.Status200OK)]
        public async Task<Response<ProductoDto>> GetById(int id)
        {
            Response<ProductoDto> response;
            try
            {
                response = await Service.GetByIdProducto(id);
                return response;
            }
            catch (Exception ex)
            {
                return new Response<ProductoDto>
                {
                    Status = false,
                    Message = MessageExtension.AddMessageList(ex.Message)
                };
            }
        }

        /// <summary>
        /// eliminar by id
        /// </summary>
        /// <returns>Response bool</returns>
        /// <author>Andres Cabezas</author>
        [HttpDelete]
        [Route("Delete")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        public async Task<Response<bool>> DeleteById(int id)
        {
            Response<bool> response;
            try
            {
                response = await Service.DeleteByIdProducto(id);
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

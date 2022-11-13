using Business.Contract;
using Common.Helpers;
using Crud_sqlLite.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Common.Utilities.Services;

namespace APisPruebaDale.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        #region Propierties
        private readonly IClienteServices Service;
        private readonly ILogger<ClienteController> _logger;
        #endregion

        #region Constructor
        public ClienteController(IClienteServices service, ILogger<ClienteController> logger)
        {
            Service = service;
            _logger = logger;
        }
        #endregion

        #region methods
        /// <summary>
        /// Obtener estudiantes
        /// </summary>
        /// <returns>Response model ClienteDto</returns>
        /// <author>Andres Cabezas</author>
        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(Response<List<ClienteDto>>), StatusCodes.Status200OK)]
        public async Task<Response<List<ClienteDto>>> Get()
        {
            Response<List<ClienteDto>> response;
            try
            {
                response = await Service.GetClientes();
                return response;
            }
            catch (Exception ex)
            {
                return new Response<List<ClienteDto>>
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
        public async Task<Response<bool>> Post(ClienteDto cliente)
        {
            Response<bool> response;
            try
            {
                response = await Service.CreateCliente(cliente);
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
        public async Task<Response<bool>> Update(ClienteDto cliente)
        {
            Response<bool> response;
            try
            {
                response = await Service.UpdateCliente(cliente);
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
        /// <returns>Response ClienteDto</returns>
        /// <author>Andres Cabezas</author>
        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(typeof(Response<ClienteDto>), StatusCodes.Status200OK)]
        public async Task<Response<ClienteDto>> GetById(int id)
        {
            Response<ClienteDto> response;
            try
            {
                response = await Service.GetByIdCliente(id);
                return response;
            }
            catch (Exception ex)
            {
                return new Response<ClienteDto>
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
                response = await Service.DeleteByIdCliente(id);
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

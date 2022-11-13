using Common.Helpers;
using Common.Utilities.Resource;
using Common.Utilities.Services;
using DataAccess.Core.Contract;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core.Implements
{
    public class ClienteRepository : IClienteRepository
    {
        #region Propierties
        private readonly DbCrudContext context;
        private readonly ILogger<ClienteRepository> _logger;
        #endregion

        #region Contructor
        public ClienteRepository(DbCrudContext context, ILogger<ClienteRepository> logger)
        {
            this.context = context;
            this._logger = logger;
        }
        #endregion

        #region Method
        public async Task<Response<bool>> CreateCliente(ClienteDto _cliente)
        {
            Response<bool> response = new();
            try
            {
                Cliente cliente = new();

                cliente.Apellido = _cliente.Apellido;
                cliente.Cedula = _cliente.Cedula;
                cliente.Telefono = _cliente.Telefono;
                cliente.Nombre = _cliente.Nombre;                
                context.Add(cliente);
                await context.SaveChangesAsync();

                response = new()
                {
                    Status = true,
                    ObjectResponse = true,
                    Message = MessageExtension.AddMessageList(Message_es.CreateSucces)
                };

                return response;
            }
            catch (Exception)
            {
                return new Response<bool>
                {
                    Status = false,
                    ObjectResponse = false,
                    Message = MessageExtension.AddMessageList(Message_es.CreateError)
                };
            }
        }

        public async Task<Response<bool>> DeleteByIdCliente(int id)
        {
            Response<bool> response = new();
            try
            {
                var cliente = context.Cliente.Where(x => x.Id == id).FirstOrDefault();

                context.Remove(cliente);
                context.SaveChanges();

                response = new()
                {
                    Status = true,
                    ObjectResponse = true,
                    Message = MessageExtension.AddMessageList(Message_es.DeleteSucces)
                };

                return await Task.FromResult(response);
            }
            catch (Exception)
            {
                return new Response<bool>
                {
                    Status = false,
                    ObjectResponse = false,
                    Message = MessageExtension.AddMessageList(Message_es.DeleteError)
                };
            }
        }

        public async Task<Response<ClienteDto>> GetByIdCliente(int id)
        {
            Response<ClienteDto> response = new();
            try
            {
                var cliente = context.Cliente.Where(x => x.Id == id).FirstOrDefault();
                ClienteDto clienteDto = new()
                {
                   Id = cliente.Id,
                   Nombre = cliente.Nombre,
                   Apellido = cliente.Apellido,
                   Telefono= cliente.Telefono,
                   Cedula= cliente.Cedula,
                };

                response = new()
                {
                    Status = true,
                    ObjectResponse = clienteDto,
                    Message = MessageExtension.AddMessageList(Message_es.ConsultaExitosa)
                };

                return await Task.FromResult(response);
            }
            catch (Exception)
            {
                return new Response<ClienteDto>
                {
                    Status = false,
                    ObjectResponse = null,
                    Message = MessageExtension.AddMessageList(Message_es.ConsultaNotFound)
                };
            }
        }

        public async Task<Response<object>> GetClientes()
        {
            Response<Object> response = new();
            try
            {
                List<Cliente> query = await context.Cliente.ToListAsync();

                response = new()
                {
                    Message = MessageExtension.AddMessageList(Message_es.ConsultaExitosa),
                    ObjectResponse = query,
                    Status = true
                };

                return await Task.FromResult(response);
            }
            catch (Exception ex)
            {
                return new Response<Object>
                {
                    Status = false,
                    ObjectResponse = false,
                    Message = MessageExtension.AddMessageList(ex.Message)
                };
            }
        }

        public async Task<Response<bool>> UpdateCliente(ClienteDto _cliente)
        {
            Response<bool> response = new();
            try
            {
                var cliente = context.Cliente.Where(x => x.Id == _cliente.Id).FirstOrDefault();

                cliente.Apellido = _cliente.Apellido;
                cliente.Cedula = _cliente.Cedula;
                cliente.Telefono = _cliente.Telefono;
                cliente.Nombre = _cliente.Nombre;
                context.Update(cliente);
                context.SaveChanges();

                response = new()
                {
                    Status = true,
                    ObjectResponse = true,
                    Message = MessageExtension.AddMessageList(Message_es.UpdateSucces)
                };

                return await Task.FromResult(response);
            }
            catch (Exception)
            {
                return new Response<bool>
                {
                    Status = false,
                    ObjectResponse = false,
                    Message = MessageExtension.AddMessageList(Message_es.UpdateError)
                };
            }
        }
        #endregion
    }
}

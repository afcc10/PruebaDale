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
    public class ProductoRepository : IProductoRepository
    {
        #region Propierties
        private readonly DbCrudContext context;
        private readonly ILogger<ProductoRepository> _logger;
        #endregion

        #region Contructor
        public ProductoRepository(DbCrudContext context,ILogger<ProductoRepository> logger)
        {
            this.context = context;
            this._logger = logger;
        }
        
        #endregion

        #region Method
        public async Task<Response<Object>> GetProducto()
        {
            Response<Object> response = new();
            try
            {
                List<Models.Producto> query = await context.Producto.ToListAsync();

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

        public async Task<Response<bool>> UpdateProducto(ProductoDto _producto)
        {
            Response<bool> response = new();
            try
            {
                var producto = context.Producto.Where(x => x.Id == _producto.Id).FirstOrDefault();

                producto.Nombre = _producto.Nombre;
                producto.ValorUnitario = _producto.ValorUnitario;               
                context.Update(producto);
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

        public async Task<Response<bool>> CreateProducto(ProductoDto _producto)
        {
            Response<bool> response = new();
            try
            {
                Producto producto = new();

                producto.Nombre = _producto.Nombre;
                producto.ValorUnitario = _producto.ValorUnitario;               
                context.Add(producto);
                context.SaveChanges();

                response = new()
                {
                    Status = true,
                    ObjectResponse = true,
                    Message = MessageExtension.AddMessageList(Message_es.CreateSucces)
                };

                return await Task.FromResult(response);
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

        public async Task<Response<bool>> DeleteByIdProducto(int id)
        {
            Response<bool> response = new();
            try
            {
                var producto = context.Producto.Where(x => x.Id == id).FirstOrDefault();

                context.Remove(producto);
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

        public async Task<Response<ProductoDto>> GetByIdProducto(int id)
        {
            Response<ProductoDto> response = new();
            try
            {
                var producto = context.Producto.Where(x => x.Id == id).FirstOrDefault();
                ProductoDto productoDto = new()
                {
                    Id = producto.Id,
                    Nombre = producto.Nombre,
                    ValorUnitario = producto.ValorUnitario
                };

                response = new()
                {
                    Status = true,
                    ObjectResponse = productoDto,
                    Message = MessageExtension.AddMessageList(Message_es.ConsultaExitosa)
                };

                return await Task.FromResult(response);
            }
            catch (Exception)
            {
                return new Response<ProductoDto>
                {
                    Status = false,
                    ObjectResponse = null,
                    Message = MessageExtension.AddMessageList(Message_es.ConsultaNotFound)
                };
            }
        }
        #endregion
    }
}

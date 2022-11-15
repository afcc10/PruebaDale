using Common.Helpers;
using Common.Utilities.Resource;
using Common.Utilities.Services;
using DataAccess.Core.Contract;
using DataAccess.Models;
using Microsoft.Extensions.Logging;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core.Implements
{
    public class VentaRepository : IVentaRepository
    {
        #region Propierties
        private readonly DbCrudContext context;
        private readonly ILogger<VentaRepository> _logger;
        #endregion

        #region Contructor
        public VentaRepository(DbCrudContext context, ILogger<VentaRepository> logger)
        {
            this.context = context;
            this._logger = logger;
        }
        #endregion

        #region Method
        public async Task<Response<bool>> createVenta(VentaDto _venta)
        {
            Response<bool> response = new();
            try
            {
                Venta venta = new()
                {
                    id_cliente= _venta.id_cliente,
                    Cantidad= _venta.Cantidad,
                    id_producto= _venta.id_producto,
                    ValorTotal = _venta.ValorTotal
                };                
                
                context.Add(venta);
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
        #endregion
    }
}

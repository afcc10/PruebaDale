using Common.Utilities.Services;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core.Contract
{
    public interface IVentaRepository
    {
        Task<Response<bool>> createVenta(VentaDto venta);
    }
}

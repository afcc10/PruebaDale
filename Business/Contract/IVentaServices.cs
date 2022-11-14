using Common.Utilities.Services;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contract
{
    public interface IVentaServices
    {
        Task<Response<bool>> createVenta(VentaDto venta);
    }
}

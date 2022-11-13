using Common.Utilities.Services;
using DataAccess.Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core.Contract
{
    public interface IProductoRepository
    {
        Task<Response<Object>> GetProducto();

        Task<Response<bool>> CreateProducto(ProductoDto producto);

        Task<Response<ProductoDto>> GetByIdProducto(int id);

        Task<Response<bool>> UpdateProducto(ProductoDto producto);

        Task<Response<bool>> DeleteByIdProducto(int id);
    }
}

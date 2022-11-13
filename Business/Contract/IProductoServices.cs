using Common.Utilities.Services;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contract
{
    public interface IProductoServices
    {
        Task<Response<List<ProductoDto>>> GetProductos();

        Task<Response<bool>> CreateProducto(ProductoDto producto);

        Task<Response<ProductoDto>> GetByIdProducto(int id);

        Task<Response<bool>> UpdateProducto(ProductoDto producto);

        Task<Response<bool>> DeleteByIdProducto(int id);
    }
}

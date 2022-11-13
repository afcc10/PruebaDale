using AutoMapper;
using Business.Contract;
using Common.Helpers;
using Common.Utilities.Services;
using DataAccess.Core.Contract;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implement
{
    public class ProductoServices : IProductoServices
    {
        #region Propierties
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public ProductoServices(IProductoRepository productoRepository, IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }


        #endregion

        #region methods

        public async Task<Response<List<ProductoDto>>> GetProductos()
        {
            var result = await _productoRepository.GetProducto();

            Response<List<ProductoDto>> response = new()
            {
                Status = result.Status,
                Message = result.Message,
                ObjectResponse = result.ObjectResponse != null ? _mapper.Map<List<ProductoDto>>(result.ObjectResponse)
                                    : null
            };

            return response;
        }

        public async Task<Response<bool>> UpdateProducto(ProductoDto producto)
        {
            var result = await _productoRepository.UpdateProducto(producto);
            return result;
        }

        public async Task<Response<bool>> CreateProducto(ProductoDto producto)
        {
            var result = await _productoRepository.CreateProducto(producto);
            return result;
        }

        public async Task<Response<bool>> DeleteByIdProducto(int id)
        {
            var result = await _productoRepository.DeleteByIdProducto(id);
            return result;
        }

        public async Task<Response<ProductoDto>> GetByIdProducto(int id)
        {
            var result = await _productoRepository.GetByIdProducto(id);
            return result;
        }

        #endregion
    }
}

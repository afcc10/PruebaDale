using AutoMapper;
using Business.Contract;
using Common.Utilities.Services;
using DataAccess.Core.Contract;
using DataAccess.Core.Implements;
using DataAccess.Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implement
{
    public class VentaServices : IVentaServices
    {
        #region Propierties
        private readonly IVentaRepository _ventaRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public VentaServices(IVentaRepository ventaRepository, IMapper mapper)
        {
            _ventaRepository = ventaRepository;
            _mapper = mapper;
        }
        #endregion

        #region Method
        public async Task<Response<bool>> createVenta(VentaDto venta)
        {
            var result = await _ventaRepository.createVenta(venta);
            return result;
        }
        #endregion
    }
}

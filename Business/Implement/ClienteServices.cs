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
    public class ClienteServices : IClienteServices
    {
        #region Propierties
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public ClienteServices(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }


        #endregion

        #region methods

        public async Task<Response<bool>> CreateCliente(ClienteDto cliente)
        {
            var result = await _clienteRepository.CreateCliente(cliente);
            return result;
        }

        public async Task<Response<bool>> DeleteByIdCliente(int id)
        {
            var result = await _clienteRepository.DeleteByIdCliente(id);
            return result;
        }

        public async Task<Response<ClienteDto>> GetByIdCliente(int id)
        {
            var result = await _clienteRepository.GetByIdCliente(id);
            return result;
        }

        public async Task<Response<List<ClienteDto>>> GetClientes()
        {
            var result = await _clienteRepository.GetClientes();

            Response<List<ClienteDto>> response = new()
            {
                Status = result.Status,
                Message = result.Message,
                ObjectResponse = result.ObjectResponse != null ? _mapper.Map<List<ClienteDto>>(result.ObjectResponse)
                                    : null
            };

            return response;
        }

        public async Task<Response<bool>> UpdateCliente(ClienteDto cliente)
        {
            var result = await _clienteRepository.UpdateCliente(cliente);
            return result;
        }

        #endregion
    }
}

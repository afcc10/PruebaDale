using Common.Utilities.Services;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contract
{
    public interface IClienteServices
    {
        Task<Response<List<ClienteDto>>> GetClientes();

        Task<Response<bool>> CreateCliente(ClienteDto cliente);

        Task<Response<ClienteDto>> GetByIdCliente(int id);

        Task<Response<bool>> UpdateCliente(ClienteDto cliente);

        Task<Response<bool>> DeleteByIdCliente(int id);
    }
}

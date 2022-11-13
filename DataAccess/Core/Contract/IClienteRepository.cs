using Common.Utilities.Services;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core.Contract
{
    public interface IClienteRepository
    {
        Task<Response<Object>> GetClientes();

        Task<Response<bool>> CreateCliente(ClienteDto cliente);

        Task<Response<ClienteDto>> GetByIdCliente(int id);

        Task<Response<bool>> UpdateCliente(ClienteDto cliente);

        Task<Response<bool>> DeleteByIdCliente(int id);
    }
}

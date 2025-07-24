using CL.Core.Domain;
using CL.Core.Shared.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Manager.Interfaces
{
    public interface IClienteManager
    {
        public Task<Cliente> AdicionarUmCliente(NovoCliente cliente);

        public Task<List<Cliente>> BuscarTodosClientes();

        public Task<Cliente> BuscarClientePorId(int id);

        public Task<Cliente> AtualizarCliente(Cliente cliente);

        public Task<bool> ExcluirCliente(int id);
    }
}
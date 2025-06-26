using CL.Core.Domain;
using CL.Data.Context;
using CL.Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClContext _context;

        public ClienteRepository(ClContext context)
        {
            _context = context;
        }

        public async Task<Cliente> Inserir(Cliente clientinho)
        {
            _context.Clientes.Add(clientinho);

            await _context.SaveChangesAsync();

            return clientinho;
        }
    }
}
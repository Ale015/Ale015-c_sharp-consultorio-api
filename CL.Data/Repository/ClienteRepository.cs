using CL.Core.Domain;
using CL.Data.Context;
using CL.Manager.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Cliente> Inserir(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);

            await _context.SaveChangesAsync();

            return cliente;
        }


        public async Task<List<Cliente>> BuscarTodos()
        {
            return await _context.Clientes.ToListAsync();
        }


        public async Task<List<Cliente>> BuscarId(int id)
        {

            return await _context.Clientes.Where(c => c.Id == id).ToListAsync();

        }

        public async Task<Cliente> Atualizar(Cliente cliente)
        {

            Cliente clienteFinded = await _context.Clientes.FindAsync(cliente.Id);

            if (clienteFinded == null)
            {
                return null;
            }

            //_context.Clientes.Update(cliente);

            _context.Entry(clienteFinded).CurrentValues.SetValues(cliente);

            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<bool> Excluir(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return false;
            }

            _context.Clientes.Remove(cliente);

            return true;
        }

    }
}
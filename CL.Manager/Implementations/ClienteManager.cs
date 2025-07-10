using CL.Core.Domain;
using CL.Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Manager.Implementations;

public class ClienteManager : IClienteManager
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteManager(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<Cliente> AdicionarUmCliente(Cliente clientinho)
    {

        if (clientinho == null)
        {
            throw new ArgumentNullException(nameof(clientinho), "Cliente não pode ser nulo.");
        }

        if (string.IsNullOrWhiteSpace(clientinho.Nome))
        {
            throw new ArgumentException("Nome do cliente não pode ser vazio.", nameof(clientinho.Nome));
        }



        return await _clienteRepository.Inserir(clientinho);
    }

    public Task<List<Cliente>> BuscarClientePorId(int id)
    {
        return _clienteRepository.BuscarId(id);
    }

    public Task<List<Cliente>> BuscarTodosClientes()
    {
        return _clienteRepository.BuscarTodos();
    }
}
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

    public async Task<List<Cliente>> BuscarTodosClientes()
    {
        List<Cliente> clientes = new List<Cliente>();

        clientes = await _clienteRepository.BuscarTodos();

        if ( clientes == null || clientes.Count == 0)
        {
            throw new InvalidOperationException("Nenhum cliente encontrado.");
        }

        return clientes;
       
    }


    public async Task<Cliente> AtualizarCliente(Cliente cliente)
    {
        if (cliente == null)
        {
            throw new ArgumentNullException(nameof(cliente), "Cliente não pode ser nulo.");
        }

        if (string.IsNullOrWhiteSpace(cliente.Nome))
        {
            throw new ArgumentException("Nome do cliente não pode ser vazio.", nameof(cliente.Nome));
        }

        return await _clienteRepository.Atualizar(cliente);
    }

    public async Task<List<Cliente>> BuscarClientePorId(int id)
    {
        return await _clienteRepository.BuscarId(id);
    }

    public async Task<bool> ExcluirCliente(int id)
    {
        throw new NotImplementedException();
    }

}
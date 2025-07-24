using CL.Core.Domain;
using CL.Core.Shared.ModelViews;
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

    public async Task<Cliente> AdicionarUmCliente(NovoCliente clientinho)
    {

        if (clientinho == null)
        {
            throw new ArgumentNullException(nameof(clientinho), "Cliente não pode ser nulo.");
        }

        if (string.IsNullOrWhiteSpace(clientinho.Nome))
        {
            throw new ArgumentException("Nome do cliente não pode ser vazio.", nameof(clientinho.Nome));
        }

        if (clientinho.Sexo != "M"  && clientinho.Sexo != "F")
        {

            throw new ArgumentException("Sexo deve ser 'M' ou 'F'.", nameof(clientinho.Sexo));
        }

        return await _clienteRepository.Inserir(clientinho);
    }

    public async Task<List<Cliente>> BuscarTodosClientes()
    {
        List<Cliente> clientes = new List<Cliente>();

        clientes = await _clienteRepository.BuscarTodos();

        return clientes ?? new List<Cliente>();
       
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

    public async Task<Cliente> BuscarClientePorId(int id)
    {
        return await _clienteRepository.BuscarId(id);
    }

    public async Task<bool> ExcluirCliente(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("ID inválido.", nameof(id));
        }

        var cliente = await _clienteRepository.BuscarId(id);

        if (cliente == null)
        {
            return false;
        }

        return await _clienteRepository.Excluir(id);
    }

}
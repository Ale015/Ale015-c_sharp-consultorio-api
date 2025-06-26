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
        return await _clienteRepository.Inserir(clientinho);
    }
}
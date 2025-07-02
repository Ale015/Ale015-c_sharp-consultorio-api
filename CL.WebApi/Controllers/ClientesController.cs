using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CL.Core.Domain;
using CL.Manager.Interfaces;

namespace CL.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    // Injeção de dependências
    private readonly IClienteManager _clienteManager;

    public ClientesController(IClienteManager clienteManager)
    {
        _clienteManager = clienteManager;
    }

    // GET All
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var clientes = await _clienteManager.BuscarTodosClientes();

        if (clientes == null || clientes.Count == 0)
        {
            return NotFound("Nenhum cliente encontrado.");
        }

        return Ok(clientes);
    }

    // GET - pelo ID do cliente
    [HttpGet("{id}")]
   public async Task<IActionResult> GetById(int id)
    {
        if (id == 0)
        {
            return BadRequest("Id inválido.");
        }

        var cliente = await _clienteManager.BuscarClientePorId(id);

        return cliente != null ? Ok(cliente) : NotFound("Cliente não encontrado.");

    }

    // POST - Criar novo cliente
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Cliente cliente)
    {

        var clienteAdicionado = await _clienteManager.AdicionarUmCliente(cliente);

        if (clienteAdicionado == null)
        {
            return BadRequest("Erro ao adicionar cliente.");
        }

        return Created("", clienteAdicionado);

    }
   

    // PUT - Atualizar um cliente pelo Id



    // DELETE - Deletar Cliente pelo Id

}
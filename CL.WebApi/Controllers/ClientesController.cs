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
        var clienteInterno = new Cliente
        {
            Nome = cliente.Nome,
            DataNascimento = cliente.DataNascimento
        };

        var clienteAdicionado = await _clienteManager.AdicionarUmCliente(clienteInterno);

        if (clienteAdicionado == null)
        {
            return BadRequest("Erro ao adicionar cliente.");
        }

        //return Created("", clienteAdicionado);

        return CreatedAtAction(nameof(GetById), new { id = clienteAdicionado.Id }, clienteAdicionado);

    }


    // PUT - Atualizar um cliente pelo Id
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Cliente cliente)
    {

        //if (id <= 0 || cliente == null || cliente.Id != id)
        //{
        //    return BadRequest("Id inválido ou cliente nulo.");
        //}
        //var clienteAtualizado = await _clienteManager.AtualizarCliente(cliente);
        //if (clienteAtualizado == null)
        //{
        //    return NotFound("Cliente não encontrado para atualização.");
        //}
        //return Ok(clienteAtualizado);

        if (id <= 0 || cliente == null || cliente.Id != id)
        {
            return BadRequest("Cliente não encontrado para atualização.");
        }

        var clienteAtualizado = await _clienteManager.AtualizarCliente(cliente);

        return clienteAtualizado != null ? Ok(clienteAtualizado) : NotFound("Cliente não foi encontrado para atualização");

    }



    // DELETE - Deletar Cliente pelo Id
    public async Task<IActionResult> Delete(int id)
    {
        if (id <= 0)
        {
            return BadRequest("ID Inválido");
        }

        var resultado = await _clienteManager.ExcluirCliente(id);

        return resultado ? NoContent() : NotFound("Cliente não encontrado para exclusão.");
    }



}
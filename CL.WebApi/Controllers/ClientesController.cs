using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CL.Core.Domain;
using CL.Manager.Interfaces;
using CL.Manager.Validator;
using CL.Core.Shared.ModelViews;

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
        if (id <= 0)
        {
            return BadRequest("Id inválido.");
        }

        var cliente = await _clienteManager.BuscarClientePorId(id);

        return cliente != null ? Ok(cliente) : NotFound("Cliente não encontrado.");

    }

    // POST - Criar novo cliente
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] NovoCliente cliente)
    {


        
            var clienteAdicionado = await _clienteManager.AdicionarUmCliente(cliente);


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
        if (id <= 0)
        {
            return BadRequest("ID inválido.");
        }

        if (cliente == null)
        {
            return BadRequest("Cliente não pode ser nulo.");
        }

        cliente.Id = id; // Garantir que o ID está correto

        try
        {
            var clienteAtualizado = await _clienteManager.AtualizarCliente(cliente);
            
            return clienteAtualizado != null ? Ok(clienteAtualizado) : NotFound("Cliente não encontrado para atualização.");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }



    // DELETE - Deletar Cliente pelo Id
    [HttpDelete("{id}")]
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
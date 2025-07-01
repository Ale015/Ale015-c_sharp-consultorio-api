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
    public async Task<IActionResult> Get()
    {
       
    }

    // GET - pelo ID do cliente
    [HttpGet("{id}")]
   

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
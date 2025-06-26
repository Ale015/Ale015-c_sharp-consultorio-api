using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CL.Core.Domain;
using CL.Manager.Interfaces;

namespace CL.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientesController : ControllerBase
{
    private readonly IClienteManager _clienteManager;

    public ClientesController(IClienteManager clienteManager)
    {
        _clienteManager = clienteManager;
    }

    [HttpGet]
    public IEnumerable<Cliente> Get()
    {
        return new List<Cliente>()
        {
            new Cliente()
            {
                Id = 1,
                Nome = "Cliente 1",
                DataNascimento = new DateTime(1980,01,22)
            },
            new Cliente()
            {
                Id = 2,
                Nome = "Cliente 2",
                DataNascimento = new DateTime(1980,03,15)
            }
        };
    }

    [HttpGet("{id}")]
    public string GetId(int id)
    {
        // retorna o id
        return $"Id: Escolhido {id.ToString()}";
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Cliente cliente)
    {
        var result = await _clienteManager.AdicionarUmCliente(cliente);

        return Ok(result);
    }
}
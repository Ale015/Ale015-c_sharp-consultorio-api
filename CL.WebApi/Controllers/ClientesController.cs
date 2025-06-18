using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CL.Core.Domain;

namespace CL.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientesController : ControllerBase
{
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

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Core.Domain
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }
        public string Documento { get; set; }

        public Cliente(Cliente cliente)
        {
            Id = cliente.Id;
            Nome = cliente.Nome;
            DataNascimento = cliente.DataNascimento;
            Email = cliente.Email;
            Sexo = cliente.Sexo;
            Telefone = cliente.Telefone;
            Documento = cliente.Documento;

        }

        public Cliente()
        {

        }


    }


}

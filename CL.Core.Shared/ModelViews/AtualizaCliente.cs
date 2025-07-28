namespace CL.Core.Shared.ModelViews
{
    public class AtualizaCliente : NovoCliente
    {
        public int Id { get; set; }

        public AtualizaCliente(NovoCliente cliente)
        {
            Nome = cliente.Nome;
            DataNascimento = cliente.DataNascimento;
            Documento = cliente.Documento;
            Email = cliente.Email;
            Nome = cliente.Nome;
            Sexo = cliente.Sexo;
            Telefone = cliente.Telefone;
        }

        public AtualizaCliente()
        { }
    }
}
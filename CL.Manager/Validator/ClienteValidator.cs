using CL.Core.Domain;
using CL.Core.Shared.ModelViews;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Manager.Validator
{
    public class ClienteValidator : AbstractValidator<NovoCliente>
    {

        public ClienteValidator()
        {
            
            RuleFor(c => c.Nome).NotEmpty().WithMessage("O nome do cliente não pode ser vazio.")
                .Length(2, 100).WithMessage("O nome do cliente deve ter entre 2 e 100 caracteres.");
            RuleFor(x => x.DataNascimento).NotNull().NotEmpty().LessThan(DateTime.Now).GreaterThan(DateTime.Now.AddYears(-140));
            RuleFor(c => c.Email).NotEmpty().WithMessage("O Email não pode ser vazio.");
            RuleFor(c => c.Sexo).Must(s => s == "M" || s == "F").WithMessage("O sexo deve ser 'M' ou 'F'.");
            RuleFor(c => c.Telefone).NotEmpty().WithMessage("O telefone não pode ser vazio.")
                 .Matches("^[0-9]{9,15}$").WithMessage("O telefone deve conter entre 9 e 15 dígitos.");
            RuleFor(c => c.Documento).NotEmpty().WithMessage("O documento não pode ser vazio.");



        }

    }
}

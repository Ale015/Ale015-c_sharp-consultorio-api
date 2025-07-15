using CL.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Data.Configuration
{
    internal class ClienteEntityConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(c => c.DataNascimento)
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            builder.Property(c => c.Sexo)
                .HasMaxLength(1)
                .HasDefaultValue("M"); 
        }
    }
}

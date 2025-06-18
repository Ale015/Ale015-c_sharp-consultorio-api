using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.Core.Domain;

namespace CL.Data.Context
{
    public class ClContext : DbContext
    {

        // O DbContext tem dois construtores, um públic que recebe o DbContextOptions e precisamos usar, e outro que não recebe nada sendo protected.
        public ClContext(DbContextOptions<ClContext> options) : base(options)
        {
        }


        public DbSet<Cliente> Clientes { get; set; }

    }
}

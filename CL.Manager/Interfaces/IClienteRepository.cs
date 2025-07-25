﻿using CL.Core.Domain;
using CL.Core.Shared.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Manager.Interfaces
{
    public interface IClienteRepository
    {
        public Task<Cliente> Inserir(Cliente cliente);

        public Task<List<Cliente>> BuscarTodos();

        public Task<Cliente> BuscarId(int id);

        public Task<Cliente> Atualizar(Cliente cliente);

        public Task<bool> Excluir(int id);

    }
}
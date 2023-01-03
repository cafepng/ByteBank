﻿using Alura.ByteBank.Aplicacao.AplicacaoServico;
using Alura.ByteBank.Aplicacao.DTO;
using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Alura.ByteBank.Dominio.Interfaces.Servicos;
using Alura.ByteBank.Dominio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ByteBank.Apresentacao.Comandos
{
    internal class ClienteComando
    {
        IClienteRepositorio _repositorio;
        IClienteServico _servico;
        ClienteServicoApp clienteServicoApp;
        public ClienteComando()
        {
            _repositorio = new ClienteRepositorio();
            _servico = new ClienteServico(_repositorio);
            clienteServicoApp = new ClienteServicoApp(_servico);
        }

        public bool Adicionar(ClienteDTO cliente)
        {
            return clienteServicoApp.Add(cliente);
        }
        public bool Atualizar(int id,ClienteDTO cliente)
        {
            return clienteServicoApp.Update(id,cliente);
        }

        public bool Excluir(int id)
        {
            return clienteServicoApp.Remove(id);
        }

        public ClienteDTO ObterPorId(int id)
        {
            return clienteServicoApp.GetById(id);
        }
        public ClienteDTO ObterPorGuid(Guid guid)
        {
            return clienteServicoApp.GetByGuid(guid);
        }

        public List<ClienteDTO> ObterTodos()
        {
           return clienteServicoApp.GetAll();
        }

    }
}

using Alura.ByteBank.Aplicacao.AplicacaoServico;
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
    internal class AgenciaComando
    {
        IAgenciaRepositorio _repositorio;
        IAgenciaServico _servico;
        AgenciaServicoApp agenciaServicoApp;
        public AgenciaComando()
        {
            _repositorio = new AgenciaRepositorio();
            _servico = new AgenciaServico(_repositorio);
            agenciaServicoApp = new AgenciaServicoApp(_servico);
        }

        public bool Adicionar(AgenciaDTO agencia)
        {
            return agenciaServicoApp.Add(agencia);
        }
        public bool Atualizar(int id, AgenciaDTO agencia)
        {
            return agenciaServicoApp.Update(id,agencia);
        }

        public bool Excluir(int id)
        {
            return agenciaServicoApp.Remove(id);
        }

        public AgenciaDTO ObterPorId(int id)
        {
            return agenciaServicoApp.GetById(id);
        }

        public List<AgenciaDTO> ObterTodos()
        {
           return agenciaServicoApp.GetAll();
        }

    }
}

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
    internal class ContaCorrenteComando
    {
        IContaCorrenteRepositorio _repositorio;
        IContaCorrenteServico _servico;
        ContaCorrenteServicoApp contaCorrenteServicoApp;
        public ContaCorrenteComando()
        {
            _repositorio = new ContaCorrenteRepositorio();
            _servico = new ContaCorrenteServico(_repositorio);
            contaCorrenteServicoApp = new ContaCorrenteServicoApp(_servico);
        }

        public bool Adicionar(ContaCorrenteDTO conta)
        {
            return contaCorrenteServicoApp.Add(conta);
        }
        public bool Atualizar(int id, ContaCorrenteDTO conta)
        {
            return contaCorrenteServicoApp.Update(id,conta);
        }

        public bool Excluir(int id)
        {
            return contaCorrenteServicoApp.Remove(id);
        }

        public ContaCorrenteDTO ObterPorId(int id)
        {
            return contaCorrenteServicoApp.GetById(id);
        }

        public List<ContaCorrenteDTO> ObterTodos()
        {
           return contaCorrenteServicoApp.GetAll();
        }

    }
}

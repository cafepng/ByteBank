using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Alura.ByteBank.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ByteBank.Dominio.Services
{
    public class ClienteServico : IClienteServico
    {
        private readonly IClienteRepositorio _repositorio;
        public ClienteServico(IClienteRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public bool Adicionar(Cliente cliente)
        {
           return _repositorio.Add(cliente);
        }

        public bool Atualizar(int id, Cliente cliente)
        {
            return _repositorio.Update(id, cliente);
        }

        public bool Excluir(int id)
        {
            return _repositorio.Remove(id);
        }

        public Cliente ObterPorId(int id)
        {
            return _repositorio.GetById(id);
        }

        public Cliente ObterPorGuid(Guid guid)
        {
            return _repositorio.GetByGuid(guid);
        }
        
        public List<Cliente> ObterTodos()
        {
            return _repositorio.GetAll();
        }

        public void Dispose()
        {
            _repositorio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

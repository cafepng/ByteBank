using Alura.ByteBank.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Alura.ByteBank.Dominio.Interfaces.Repositorios
{
    public interface IContaCorrenteRepositorio:IDisposable
    {
        public List<ContaCorrente> RemoveAll();
        public ContaCorrente GetById(int id);
        public ContaCorrente GetByGuid(Guid guid);
        public bool Insert(ContaCorrente conta);
        public bool Update(int id, ContaCorrente conta);
        public bool Remove(int id);
    }
}

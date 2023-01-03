using Alura.ByteBank.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Alura.ByteBank.Dominio.Interfaces.Repositorios
{
    public interface IClienteRepositorio:IDisposable
    {
        public List<Cliente> GetAll();
        public Cliente GetById(int id);
        public Cliente GetByGuid(Guid guid);
        public bool Add(Cliente cliente);
        public bool Update(int id,Cliente cliente);
        public bool Remove(int id);

    }
}

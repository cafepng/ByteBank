using Alura.ByteBank.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Alura.ByteBank.Dominio.Interfaces.Repositorios
{
    public interface IAgenciaRepositorio:IDisposable
    {
        public List<Agencia> GetAll();
        public Agencia GetById(int id);
        public Agencia GetByGuid(Guid guid);
        public bool Add(Agencia agencia);
        public bool Update(int id, Agencia agencia);
        public bool Remove(int id);
    }
}

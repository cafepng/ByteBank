using Alura.ByteBank.Dados.Contexto;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ByteBank.Dados.Repositorio
{
    public class AgenciaRepositorio : IAgenciaRepositorio
    {
        private readonly ByteBankContexto _contexto;
        public AgenciaRepositorio()
        {
            _contexto = new ByteBankContexto();
        }
        public bool Add(Agencia agencia)
        {
            try
            {
                _contexto.Agencias.Add(agencia);
                _contexto.SaveChanges();

                return true;
            }
            catch{
                return false;
            }
        }

        public bool Update(int id, Agencia agencia)
        {
            
            try
            {
                if (id != agencia.Id)
                {
                    return false;
                }
                _contexto.Entry(agencia).State = EntityState.Modified;
                _contexto.SaveChanges();
                return true;
            }
            catch{
                return false;
            }
        }

        public bool Remove(int id)
        {
            var agencia = _contexto.Agencias.FirstOrDefault(p => p.Id == id);

            try
            {
                if (agencia == null)
                {
                    return false;
                }

                _contexto.Agencias.Remove(agencia);
                _contexto.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Agencia GetById(int id)
        {
            try
            {
                var agencia = _contexto.Agencias.FirstOrDefault(p => p.Id == id);

                if(agencia == null)
                {
                    throw new FormatException($"Erro ao obter agência com Id = {id}.");
                }
                return agencia;
            }
            catch (FormatException ex)
            {
               throw new FormatException($"Erro ao obter agência => {ex.Message}") ;
            }
        }

        public Agencia GetByGuid(Guid guid)
        {
            try
            {
                var agencia = _contexto.Agencias.FirstOrDefault(p => p.Identificador == guid);
                if (agencia == null)
                {
                    return null;
                }
                return agencia;
            }
            catch
            {
                throw new Exception($"Erro ao obter agência com Guid = {guid}.");
            }
        }

        public List<Agencia> GetAll()
        {
            try
            {
                return _contexto.Agencias.ToList();
            }
            catch
            {
                throw new Exception("Erro ao obter Agências.");
            }
        }

        public void Dispose()
        {
            _contexto.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

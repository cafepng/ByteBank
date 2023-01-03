using Alura.ByteBank.Aplicacao.DTO;
using Alura.ByteBank.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ByteBank.Aplicacao.Interfaces
{
    public interface IAgenciaServicoApp:IDisposable
    {
        public List<AgenciaDTO> GetAll();
        public AgenciaDTO GetById(int id);
        public AgenciaDTO GetByGuid(Guid guid);
        public bool Add(AgenciaDTO agencia);
        public bool Update(int id, AgenciaDTO agencia);
        public bool Remove(int id);
    }
}

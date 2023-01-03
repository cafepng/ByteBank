using Alura.ByteBank.Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ByteBank.Aplicacao.Interfaces
{
    public interface IContaCorrenteServicoApp:IDisposable
    {
        public List<ContaCorrenteDTO> GetAll();
        public ContaCorrenteDTO GetById(int id);
        public ContaCorrenteDTO GetByGuid(Guid guid);
        public bool Add(ContaCorrenteDTO cliente);
        public bool Update(int id, ContaCorrenteDTO cliente);
        public bool Remove(int id);
    }
}

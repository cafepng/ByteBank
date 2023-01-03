using Alura.ByteBank.Aplicacao.DTO;
using Alura.ByteBank.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ByteBank.Aplicacao.Interfaces
{
    public interface IClienteServicoApp:IDisposable
    {        
        public List<ClienteDTO> GetAll();
        public ClienteDTO GetById(int id);

        public ClienteDTO GetByGuid(Guid guid);
        public bool Add(ClienteDTO cliente);
        public bool Update(int id, ClienteDTO cliente);
        public bool Remove(int id);
      
    }
}

using Alura.ByteBank.Aplicacao.DTO;
using Alura.ByteBank.Aplicacao.Interfaces;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Servicos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ByteBank.Aplicacao.AplicacaoServico
{
    public class ClienteServicoApp : IClienteServicoApp
    {
        private readonly IClienteServico _servico;     
        private readonly Mapper _mapper;
      
        public ClienteServicoApp(IClienteServico servico)
        {
            _servico = servico;            
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Cliente, ClienteDTO>().ReverseMap());
            _mapper = new(config);
        }
        public void Dispose()
        {
            _servico.Dispose();
            GC.SuppressFinalize(this);
        }
        public bool Add(ClienteDTO cliente)
        {
            
            return _servico.Adicionar(_mapper.Map<ClienteDTO,Cliente>(cliente));
        }

        public bool Update(int id, ClienteDTO cliente)
        {
            return _servico.Atualizar(id, _mapper.Map<ClienteDTO, Cliente>(cliente));
        }

        public bool Remove(int id)
        {
            return _servico.Excluir(id);
        }

        public ClienteDTO GetById(int id)
        {
            return _mapper.Map<Cliente, ClienteDTO>(_servico.ObterPorId(id));
        }

        public ClienteDTO GetByGuid(Guid guid)
        {
            return _mapper.Map<Cliente, ClienteDTO>(_servico.ObterPorGuid(guid));
        }
        public List<ClienteDTO> GetAll()
        {
            var clientes = _servico.ObterTodos();
            List<ClienteDTO> clientesDTO = _mapper.Map<List<Cliente>, List<ClienteDTO>>(clientes);
            return clientesDTO;
        }
    }
}

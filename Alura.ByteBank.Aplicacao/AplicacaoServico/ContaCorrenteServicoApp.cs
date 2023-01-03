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
    public class ContaCorrenteServicoApp : IContaCorrenteServicoApp
    {
        private readonly IContaCorrenteServico _servico;     
        private readonly Mapper _mapper;
      
        public ContaCorrenteServicoApp(IContaCorrenteServico servico)
        {
            _servico = servico;            
            var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<ContaCorrente, ContaCorrenteDTO>().ReverseMap();
                     cfg.CreateMap<Cliente, ClienteDTO>().ReverseMap();
                         cfg.CreateMap<Agencia, AgenciaDTO>().ReverseMap();
            });
            _mapper = new(config);
        }
        public void Dispose()
        {
            _servico.Dispose();
            GC.SuppressFinalize(this);
        }
        public bool Add(ContaCorrenteDTO conta)
        {            
           return _servico.Adicionar(_mapper.Map<ContaCorrenteDTO, ContaCorrente>(conta));
        }

        public bool Update(int id, ContaCorrenteDTO conta)
        {
            return _servico.Atualizar(id, _mapper.Map<ContaCorrenteDTO, ContaCorrente>(conta));
        }

        public bool Remove(int id)
        {
            return _servico.Excluir(id);
        }

        public ContaCorrenteDTO GetById(int id)
        {
            return _mapper.Map<ContaCorrente, ContaCorrenteDTO>(_servico.ObterPorId(id));
        }

        public ContaCorrenteDTO GetByGuid(Guid guid)
        {
            return _mapper.Map<ContaCorrente, ContaCorrenteDTO>(_servico.ObterPorGuid(guid));
        }
        public List<ContaCorrenteDTO> GetAll()
        {
            var contas = _servico.ObterTodos();
            List<ContaCorrenteDTO> contasDTO = _mapper.Map<List<ContaCorrente>,List<ContaCorrenteDTO>>(contas);
            return contasDTO;
        }
    }
}

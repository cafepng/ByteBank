using ByteBank.Infraestrutura.Testes.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ByteBank.Infraestrutura.Testes.Service
{
    public class PixRepository : IPixRepository
    {
        public List<PixDTO> listPix { get; set; }

        public PixRepository()
        {
            listPix = new List<PixDTO>()
            {
                new PixDTO(){ Saldo = 100 },
                new PixDTO(){ Saldo = 200 },
                new PixDTO(){ Saldo = 300 },
                new PixDTO(){ Saldo = 400 },
                new PixDTO(){ Saldo = 500 },
                new PixDTO(){ Saldo = 600 },
                new PixDTO(){ Saldo = 700 },
                new PixDTO(){ Saldo = 800 },
                new PixDTO(){ Saldo = 900 }
            };
        }

        public PixDTO GetPix(Guid chave)
        {
            PixDTO pix = listPix.Where(x => x.Chave == chave)
                                .FirstOrDefault();

            return pix;
        }
    }
}

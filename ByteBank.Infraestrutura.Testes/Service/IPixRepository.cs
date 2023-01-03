using ByteBank.Infraestrutura.Testes.Service.DTO;
using System;

namespace ByteBank.Infraestrutura.Testes.Service
{
    public interface IPixRepository
    {
        public PixDTO GetPix(Guid pix);
    }
}

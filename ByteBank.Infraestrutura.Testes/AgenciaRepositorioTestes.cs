using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ByteBank.Infraestrutura.Testes
{
    public class AgenciaRepositorioTestes
    {
        private readonly IAgenciaRepositorio _agenciaRepositorio;

        public AgenciaRepositorioTestes()
        {
            var service = new ServiceCollection();
            service.AddTransient<IAgenciaRepositorio, AgenciaRepositorio>();
            var provedor = service.BuildServiceProvider();
            _agenciaRepositorio = provedor.GetService<IAgenciaRepositorio>();
        }

        [Fact]
        public void TestGetAll()
        {
            List<Agencia> lista = _agenciaRepositorio.GetAll();

            Assert.NotNull(lista);
        }

        [Fact]
        public void TestGetById()
        {
            var conta = _agenciaRepositorio.GetById(1);

            Assert.NotNull(conta);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void TestGetForManyId(int id)
        {
            var conta = _agenciaRepositorio.GetById(id);

            Assert.NotNull(conta);
        }

        [Fact]
        public void TestExceptionGetById()
        {
            Assert.Throws<FormatException>(
                () => _agenciaRepositorio.GetById(-1)
            );
        }
    }
}

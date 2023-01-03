using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using ByteBank.Infraestrutura.Testes.Service;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace ByteBank.Infraestrutura.Testes
{
    public class AgenciaRepositorioTestes
    {
        private readonly IAgenciaRepositorio _agenciaRepositorio;
        private readonly IByteBankRepository _byteBankRepository;
        public ITestOutputHelper SaidaConsoleTest { get; set; }

        public AgenciaRepositorioTestes(ITestOutputHelper _testOutputHelper)
        {
            SaidaConsoleTest = _testOutputHelper;
            SaidaConsoleTest.WriteLine("Construtor invocado.");

            var service = new ServiceCollection();
            service.AddTransient<IAgenciaRepositorio, AgenciaRepositorio>();
            var provedor = service.BuildServiceProvider();
            _agenciaRepositorio = provedor.GetService<IAgenciaRepositorio>();

            service = new ServiceCollection();
            service.AddTransient<IByteBankRepository, ByteBankRepository>();
            provedor = service.BuildServiceProvider();
            _byteBankRepository = provedor.GetService<IByteBankRepository>();
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

        [Fact]
        public void TestAddMock()
        {
            Agencia agencia = new()
            {
                Id = 4,
                Nome = "Agencia 04",
                Identificador = Guid.NewGuid(),
                Endereco = "Endereço 04",
                Numero = 4
            };

            var add = _byteBankRepository.AddAgencia(agencia);

            Assert.True( add );
        }

        [Fact]
        public void TestGetMock()
        {
            var byteBankRepository = new Mock<IByteBankRepository>();
            var mock = byteBankRepository.Object;

            var lista = mock.GetAgencias();

            byteBankRepository.Verify(b => b.GetAgencias());
        }
    }
}

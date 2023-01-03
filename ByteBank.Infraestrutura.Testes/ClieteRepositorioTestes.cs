using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Xunit;

namespace ByteBank.Infraestrutura.Testes
{
    public class ClieteRepositorioTestes
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        
        public ClieteRepositorioTestes()
        {
            var service = new ServiceCollection();
            service.AddTransient<IClienteRepositorio, ClienteRepositorio>();
            var provedor = service.BuildServiceProvider();
            _clienteRepositorio = provedor.GetService<IClienteRepositorio>();
        }

        [Fact]
        public void TestGetAll()
        {
            List<Cliente> lista = _clienteRepositorio.GetAll();

            Assert.NotNull(lista);
            Assert.Equal(3, lista.Count);
        }

        [Fact]
        public void TestGetById()
        {
            var cliente = _clienteRepositorio.GetById(1);

            Assert.NotNull(cliente);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void TestGetForManyId(int id)
        {
            var cliente = _clienteRepositorio.GetById(id);

            Assert.NotNull(cliente);
        }
    }
}

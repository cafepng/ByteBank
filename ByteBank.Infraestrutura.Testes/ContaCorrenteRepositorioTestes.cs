using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using ByteBank.Infraestrutura.Testes.Service;
using ByteBank.Infraestrutura.Testes.Service.DTO;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace ByteBank.Infraestrutura.Testes
{
    public class ContaCorrenteRepositorioTestes
    {
        private readonly IContaCorrenteRepositorio _contaCorrenteRepositorio;

        public ContaCorrenteRepositorioTestes()
        {
            var service = new ServiceCollection();
            service.AddTransient<IContaCorrenteRepositorio, ContaCorrenteRepositorio>();
            var provedor = service.BuildServiceProvider();
            _contaCorrenteRepositorio = provedor.GetService<IContaCorrenteRepositorio>();
        }

        [Fact]
        public void TestGetAll()
        {
            List<ContaCorrente> lista = _contaCorrenteRepositorio.RemoveAll();

            Assert.NotNull(lista);
        }

        [Fact]
        public void TestGetById()
        {
            var conta = _contaCorrenteRepositorio.GetById(1);

            Assert.NotNull(conta);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void TestGetForManyId(int id)
        {
            var conta = _contaCorrenteRepositorio.GetById(id);

            Assert.NotNull(conta);
        }

        [Fact]
        public void TestUpdateSaldo()
        {
            var conta = _contaCorrenteRepositorio.GetById(1);
            double saldoAtual = conta.Saldo;
            double saldoNovo = 10;
            conta.Saldo = saldoNovo;

            var atualizado = _contaCorrenteRepositorio.Update(1, conta);

            Assert.True(atualizado);
            Assert.NotEqual(saldoAtual, conta.Saldo);
        }

        [Fact]
        public void TestNewInsert()
        {
            var conta = new ContaCorrente()
            {
                Saldo = 10,
                Identificador = Guid.NewGuid(),
                Cliente = new Cliente()
                {
                    Nome = "Cliente01",
                    CPF = "302.077.440-33",
                    Identificador = Guid.NewGuid(),
                    Profissao = "Profissao01",
                    Id = 1
                },
                Agencia = new Agencia()
                {
                    Nome = "Agencia01",
                    Identificador = Guid.NewGuid(),
                    Id = 1,
                    Endereco = "Endereco01",
                    Numero = 1
                }
            };

            var retorno = _contaCorrenteRepositorio.Insert(conta);

            Assert.True(retorno);
        }

        [Fact]
        public void TestGetPix()
        {
            var chavePix = Guid.NewGuid();

            PixDTO pix = new()
            {
                Chave = chavePix,
                Saldo = 100
            };

            var pixMock = new Mock<IPixRepository>();
            pixMock.Setup(x => x.GetPix(It.IsAny<Guid>())).Returns(pix);

            var mock = pixMock.Object;

            var saldo = mock.GetPix(chavePix).Saldo;

            Assert.Equal(100, saldo);
        }
    }
}

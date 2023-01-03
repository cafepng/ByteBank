using Alura.ByteBank.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace ByteBank.Infraestrutura.Testes.Service
{
    public class ByteBankRepository : IByteBankRepository
    {
        private readonly List<Cliente> clientes = new()
        {
            new Cliente
            {
                Id = 1,
                Nome = "Cliente 01",
                CPF = "630.890.670-05",
                Identificador = Guid.NewGuid(),
                Profissao = "Dev"
            },
            new Cliente
            {
                Id = 2,
                Nome = "Cliente 02",
                CPF = "630.890.670-05",
                Identificador = Guid.NewGuid(),
                Profissao = "Dev"
            },
            new Cliente
            {
                Id = 3,
                Nome = "Cliente 03",
                CPF = "630.890.670-05",
                Identificador = Guid.NewGuid(),
                Profissao = "Dev"
            }
        };
        private readonly List<Agencia> agencias = new()
        {
            new Agencia
            {
                Id = 1,
                Numero = 1,
                Nome = "Agencia 01",
                Endereco = "Endereço 01",
                Identificador = Guid.NewGuid()
            },
            new Agencia
            {
                Id = 2,
                Numero = 2,
                Nome = "Agencia 02",
                Endereco = "Endereço 02",
                Identificador = Guid.NewGuid()
            },
            new Agencia
            {
                Id = 3,
                Numero = 3,
                Nome = "Agencia 03",
                Endereco = "Endereço 03",
                Identificador = Guid.NewGuid()
            }
        };
        private readonly List<ContaCorrente> contaCorrentes = new()
        {
            new ContaCorrente
            {
                Id = 1,
                Numero = 1,
                Saldo = 100,
                Identificador = Guid.NewGuid(),
                PixConta = Guid.NewGuid(),
                Cliente = new Cliente()
                {
                    Id = 1,
                    Nome = "Cliente 01",
                    CPF = "630.890.670-05",
                    Identificador = Guid.NewGuid(),
                    Profissao = "Dev"
                },
                Agencia = new Agencia()
                {
                    Id = 1,
                    Numero = 1,
                    Nome = "Agencia 01",
                    Endereco = "Endereço 01",
                    Identificador = Guid.NewGuid()
                }
            },

            new ContaCorrente
            {
                Id = 2,
                Numero = 2,
                Saldo = 200,
                Identificador = Guid.NewGuid(),
                PixConta = Guid.NewGuid(),
                Cliente = new Cliente()
                {
                    Id = 2,
                    Nome = "Cliente 02",
                    CPF = "630.890.670-05",
                    Identificador = Guid.NewGuid(),
                    Profissao = "Dev"
                },
                Agencia = new Agencia()
                {
                    Id = 2,
                    Numero = 2,
                    Nome = "Agencia 02",
                    Endereco = "Endereço 02",
                    Identificador = Guid.NewGuid()
                }
            },

            new ContaCorrente
            {
                Id = 3,
                Numero = 3,
                Saldo = 300,
                Identificador = Guid.NewGuid(),
                PixConta = Guid.NewGuid(),
                Cliente = new Cliente()
                {
                    Id = 3,
                    Nome = "Cliente 03",
                    CPF = "630.890.670-05",
                    Identificador = Guid.NewGuid(),
                    Profissao = "Dev"
                },
                Agencia = new Agencia()
                {
                    Id = 3,
                    Numero = 3,
                    Nome = "Agencia 03",
                    Endereco = "Endereço 03",
                    Identificador = Guid.NewGuid()
                }
            }
        };

        public ByteBankRepository()
        {

        }

        public List<Cliente> GetClientes()
        {
            return clientes;
        }

        public List<Agencia> GetAgencias()
        {
            return agencias;
        }

        public List<ContaCorrente> GetContaCorrentes()
        {
            return contaCorrentes;
        }

        public bool AddConta(ContaCorrente contaCorrente)
        {
            contaCorrentes.Add(contaCorrente);
            return true;
        }

        public bool AddAgencia(Agencia agencia)
        {
            agencias.Add(agencia);
            return true;
        }

        public bool AddCliente(Cliente cliente)
        {
            clientes.Add(cliente);
            return true;
        }
    }
}

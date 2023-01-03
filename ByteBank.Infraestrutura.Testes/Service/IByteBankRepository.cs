using Alura.ByteBank.Dominio.Entidades;
using System.Collections.Generic;

namespace ByteBank.Infraestrutura.Testes.Service
{
    public interface IByteBankRepository
    {
        public List<Cliente> GetClientes();
        public List<Agencia> GetAgencias();
        public List<ContaCorrente> GetContaCorrentes();
        bool AddConta(ContaCorrente contaCorrente);
        bool AddAgencia(Agencia agencia);
        bool AddCliente(Cliente cliente);
    }
}

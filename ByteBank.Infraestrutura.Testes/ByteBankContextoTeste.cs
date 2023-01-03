using Alura.ByteBank.Dados.Contexto;
using System;
using Xunit;

namespace ByteBank.Infraestrutura.Testes
{
    public class ByteBankContextoTeste
    {
        [Fact]
        public void TestConnectionDB()
        {
            var context = new ByteBankContexto();
            bool conectado;

            try
            {
                conectado = context.Database.CanConnect();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível conectar a base de dados.");
            }

            Assert.True(conectado);
        }
    }
}

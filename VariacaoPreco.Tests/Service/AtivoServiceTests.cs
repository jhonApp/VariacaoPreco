using Xunit;
using Moq;
using VariacaoPreco.Core.Entity;
using VariacaoPreco.Core.Interface;
using VariacaoPreco.Core.Service;
using System;
using System.Collections.Generic;

namespace VariacaoPreco.Tests
{
    public class AtivoServiceTests
    {
        [Fact]
        public void CalcularVariacaoPreco()
        {
            // Arrange
            var mockAtivo = new Mock<IAtivo>();
            var ativos = new List<Ativo>
            {
                new Ativo { Valor_abertura = 100, Data_stamp = DateTime.Now.AddDays(-10) },
                new Ativo { Valor_abertura = 110, Data_stamp = DateTime.Now.AddDays(-9) },
            };
            mockAtivo.Setup(a => a.ObterAtivosUltimos30Pregoes()).Returns(ativos);

            var ativoService = new AtivoService(mockAtivo.Object);

            // Act
            var result = ativoService.CalcularVariacaoPreco();

            // Assert
            Assert.Equal(10, result);
        }

        [Fact]
        public void CalcularVariacoes()
        {
            // Arrange
            var mockAtivo = new Mock<IAtivo>();
            var ativos = new List<Ativo>
            {
                new Ativo { Valor_fechamento = 100 },
                new Ativo { Valor_fechamento = 110 },
                // Add more sample data as needed
            };
            mockAtivo.Setup(a => a.ObterAtivosUltimos30Pregoes()).Returns(ativos);

            var ativoService = new AtivoService(mockAtivo.Object);

            // Act
            var result = ativoService.CalcularVariacoes();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ativos.Count, result.Count);
        }
    }
}

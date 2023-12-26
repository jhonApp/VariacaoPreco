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
        [Theory]
        [InlineData("AAPL")]
        [InlineData("MSFT")]
        [InlineData("AMZN")]
        [InlineData("GOOGL")]
        [InlineData("FB")]
        [InlineData("TSLA")]
        [InlineData("PETR4")]
        [InlineData("PETR3")]
        [InlineData("VALE3")]
        [InlineData("BBAS3")]
        [InlineData("ITUB4")]
        [InlineData("BBDC4")]
        [InlineData("BP")]
        [InlineData("VOD")]
        [InlineData("GSK")]
        [InlineData("ULVR")]

        public void CalcularVariacoesBySimbolo(string symbol)
        {
            // Arrange
            var mockAtivo = new Mock<IAtivo>();
            mockAtivo.Setup(ativo => ativo.ObterAtivosUltimos30PregoesBySimbolo(It.IsAny<string>()))
                .Returns(GenerateRandomAtivos(30, symbol));

            var ativoService = new AtivoService(mockAtivo.Object);

            var result = ativoService.CalcularVariacoesBySimbolo(symbol);

            Assert.NotNull(result);
        }

        private List<Ativo> GenerateRandomAtivos(int count, string symbol)
        {
            var ativos = new List<Ativo>();
            var random = new Random();

            for (int i = 0; i < count; i++)
            {
                var data = DateTime.Now.AddDays(-i);
                var valorFechamento = random.NextDouble() * 100; // Gera valores aleatórios entre 0 e 100

                ativos.Add(new Ativo
                {
                    Dia = i + 1,
                    Data_stamp = data,
                    Valor_fechamento = valorFechamento,
                    Simbolo = symbol
                });
            }

            return ativos;
        }
    }
}

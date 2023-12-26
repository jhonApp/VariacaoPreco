using Microsoft.EntityFrameworkCore;
using VariacaoPreco.Core.Entity;
using VariacaoPreco.Data;
using VariacaoPreco.Data.Repository;
using Xunit;

namespace VariacaoPreco.Tests
{
    public class AtivoRepositoryTests
    {
        [Fact]
        public void ObterAtivosUltimos30Pregoes()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new AppDbContext(options))
            {
                var repository = new AtivoRepository(context);
                // Adding test data
                AddTestData(context);

                // Act
                var result = repository.ObterAtivosUltimos30Pregoes();

                // Assert
                Assert.NotNull(result);
                Assert.Equal(30, result.Count); // Assuming it returns a list with 30 elements
                // Add more specific assertions based on the expected behavior
            }
        }

        private void AddTestData(AppDbContext context)
        {
            for (int i = 0; i < 50; i++)
            {
                var ativo = new Ativo
                {
                    Simbolo = "TEST",
                    Dia = i + 1,
                    Data_stamp = DateTime.Now.AddDays(-i),
                };

                context.Ativos.Add(ativo);
            }

            context.SaveChanges();
        }
    }
}

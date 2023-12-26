using Microsoft.EntityFrameworkCore;
using VariacaoPreco.Core.Interface;
using VariacaoPreco.Data;
using VariacaoPreco.Data.Repository;
using VariacaoPreco.Integracao;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<AppDbContext>(options =>
                    {
                        options.UseSqlServer(configuration.GetConnectionString("VariacaoAWS"));
                    });

                    services.AddTransient<AtivoIntegracaoService>();
                    services.AddScoped<IAtivo, AtivoRepository>();
                })
                .Build();

            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var ativoService = serviceProvider.GetRequiredService<AtivoIntegracaoService>();

                try
                {
                    await ativoService.ObterPrecoAtivo("teste");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                }
            }
        }

    }
}

namespace VariacaoPreco.Data.Interface
{
    public interface IDbContextFactory
    {
        AppDbContext CreateDbContext();
    }
}

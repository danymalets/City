namespace Sources.App.Infrastructure.Services.Gizmoses
{
    public interface IGizmosService : IService
    {
        public GizmosContext CreateContext();
    }
}
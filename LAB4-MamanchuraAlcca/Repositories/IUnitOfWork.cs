namespace LAB4_MamanchuraAlcca.Repositories;

public interface IUnitOfWork : IDisposable
{
    IClienteRepository Clientes { get; } // Repositorio de clientes
    int SaveChanges(); // Guarda los cambios realizados en la base de datos
}


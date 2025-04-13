using LAB4_MamanchuraAlcca.Models;

namespace LAB4_MamanchuraAlcca.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly TiendaDBContext _context;

    // El repositorio de clientes
    public IClienteRepository Clientes { get; }

    // Constructor que recibe un DbContext y el repositorio de clientes
    public UnitOfWork(TiendaDBContext context, IClienteRepository clienteRepository)
    {
        _context = context;
        Clientes = clienteRepository; // Asignamos el repositorio de clientes
    }

    // Guarda los cambios realizados en la base de datos
    public int SaveChanges()
    {
        return _context.SaveChanges(); // Guarda los cambios en la base de datos
    }

    // Destruye el contexto cuando ya no se necesita
    public void Dispose()
    {
        _context.Dispose(); // Libera los recursos del contexto
    }
}

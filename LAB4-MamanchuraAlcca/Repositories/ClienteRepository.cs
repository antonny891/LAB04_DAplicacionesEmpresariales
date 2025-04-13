using LAB4_MamanchuraAlcca.Models;
using Microsoft.EntityFrameworkCore;

namespace LAB4_MamanchuraAlcca.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly TiendaDBContext _context;

    // Constructor que recibe un DbContext
    public ClienteRepository(TiendaDBContext context)
    {
        _context = context;
    }

    // Obtener un cliente por ID
    public cliente GetById(int id)
    {
        return _context.Set<cliente>().Find(id); // Busca un cliente por su ID
    }

    // Obtener todos los clientes
    public IEnumerable<cliente> GetAll()
    {
        return _context.Set<cliente>().ToList(); // Devuelve todos los clientes
    }

    // Agregar un nuevo cliente
    public void Add(cliente cliente)
    {
        _context.Set<cliente>().Add(cliente); // Agrega un nuevo cliente
    }

    // Actualizar un cliente existente
    public void Update(cliente cliente)
    {
        _context.Set<cliente>().Update(cliente); // Actualiza el cliente
    }

    // Eliminar un cliente por su ID
    public void Delete(int id)
    {
        var cliente = _context.Set<cliente>().Find(id); // Busca el cliente por ID
        if (cliente != null)
        {
            _context.Set<cliente>().Remove(cliente); // Elimina el cliente
        }
    }
}


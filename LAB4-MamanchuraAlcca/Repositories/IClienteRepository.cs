using LAB4_MamanchuraAlcca.Models;

namespace LAB4_MamanchuraAlcca.Repositories;

public interface IClienteRepository
{
    cliente GetById(int id); // Obtiene un cliente por su ID
    IEnumerable<cliente> GetAll(); // Obtiene todos los clientes
    void Add(cliente cliente); // Agrega un nuevo cliente
    void Update(cliente cliente); // Actualiza un cliente existente
    void Delete(int id); // Elimina un cliente por su ID
}

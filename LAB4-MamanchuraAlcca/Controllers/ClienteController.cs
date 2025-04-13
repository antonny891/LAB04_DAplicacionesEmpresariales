using LAB4_MamanchuraAlcca.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LAB4_MamanchuraAlcca.Models;

namespace LAB4_MamanchuraAlcca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        // Constructor para inyectar la unidad de trabajo
        public ClienteController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Obtener todos los clientes
        [HttpGet]
        public IActionResult GetAll()
        {
            var clientes = _unitOfWork.Clientes.GetAll();
            return Ok(clientes);
        }

        // Obtener un cliente por ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var cliente = _unitOfWork.Clientes.GetById(id);
            if (cliente == null)
            {
                return NotFound("Cliente no encontrado.");
            }
            return Ok(cliente);
        }

        // Crear un nuevo cliente
        [HttpPost]
        public IActionResult Create([FromBody] cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest("Cliente no válido.");
            }

            _unitOfWork.Clientes.Add(cliente);
            _unitOfWork.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = cliente.ClienteID }, cliente);
        }

        // Actualizar un cliente existente
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] cliente cliente)
        {
            if (cliente == null || cliente.ClienteID != id)
            {
                return BadRequest("Datos del cliente incorrectos.");
            }

            var clienteExistente = _unitOfWork.Clientes.GetById(id);
            if (clienteExistente == null)
            {
                return NotFound("Cliente no encontrado.");
            }

            _unitOfWork.Clientes.Update(cliente);
            _unitOfWork.SaveChanges();
            return NoContent();
        }

        // Eliminar un cliente
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cliente = _unitOfWork.Clientes.GetById(id);
            if (cliente == null)
            {
                return NotFound("Cliente no encontrado.");
            }

            _unitOfWork.Clientes.Delete(id);
            _unitOfWork.SaveChanges();
            return NoContent();
        }
    }
}

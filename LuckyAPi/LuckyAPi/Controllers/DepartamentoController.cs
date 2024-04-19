using LuckyAPi.DTOS;
using LuckyAPi.Models;
using LuckyAPi.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace LuckyAPi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartamentoController:ControllerBase
    {
        private readonly IDepartamentoService _departamento;

        public DepartamentoController(IDepartamentoService departamento)
        {
            _departamento = departamento;
        }
        [HttpGet]
        public ActionResult<IEnumerable<DepartamentoDTO>> ListarDepartamentos()
        {
            var departamentos = _departamento.ObtenerDepartamentos();

            var departamentosDTO = departamentos.Select(d => new DepartamentoDTO
            {
                departamento_id = d.departamento_id,
                Nombre = d.Nombre
            }).ToList();

            return Ok(departamentosDTO);
        }
        [HttpGet("{id}")]
        public IActionResult DetalleDepartamento(int id)
        {
            var departamento = _departamento.ObtenerDepartamentoPorId(id);
            var departamentoDTO = new DepartamentoDTO
            {
                departamento_id = departamento.departamento_id,
                Nombre = departamento.Nombre
            };
            return Ok(departamentoDTO);
        }

        [HttpGet("Usuarios/{id}")]
        public ActionResult<IEnumerable<UsuarioDepartamentoDTO>> Detalle(int id)
        {
            var usuarios = _departamento.ObtenerUsuariosDepartamento(id);
            var usuariosDTO=usuarios.Select(u=> new UsuarioDepartamentoDTO
            {
                usuario_id = u.usuario_id,
                Nombre=u.Nombre,
                Apellido = u.Apellido,
                Dni = u.Dni,
                Sueldo = u.Sueldo,
                FechaCreacion = u.FechaCreacion
            }).ToList();
            return Ok(usuariosDTO);
        }
        [HttpPost]
        public IActionResult Crear(DepartamentoCreateDTO departamento)
        {
            Departamento crearDepartamento=new Departamento();
            crearDepartamento.Nombre = departamento.Nombre;
            _departamento.InsertarDepartamento(crearDepartamento);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            var departamento = _departamento.ObtenerDepartamentoPorId(id);
            if (departamento == null)
                return NotFound();

            _departamento.EliminarDepartamento(id);
            return NoContent();
        }

    }
}

using LuckyAPi.DTOS;
using LuckyAPi.Models;
using LuckyAPi.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace LuckyAPi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController:ControllerBase
    {
        private readonly IUsuarioService _iusuario;
        public UsuarioController(IUsuarioService iusuario)
        {
            _iusuario = iusuario;
        }
        [HttpGet]
        public ActionResult<IEnumerable<UsuarioDTO>> ListarUsuarios()
        {
            var usuarios = _iusuario.ObtenerUsuarios();
            var usuariosDTo = usuarios.Select(u=> new UsuarioDTO{
                usuario_id = u.usuario_id,
                Nombre=u.Nombre,
                Apellido=u.Apellido,
                Dni=u.Dni,
                Sueldo=u.Sueldo,
                FechaCreacion = u.FechaCreacion,
                departamento_id = u.departamento_id
            }).ToList();
            return Ok(usuariosDTo);
        }

        [HttpGet("{id}")]
        public IActionResult Detalle(int id)
        {
            var usuario = _iusuario.ObtenerUsuarioPorId(id);
            var usuarioDTo = new UsuarioDTO
            {
                usuario_id = usuario.usuario_id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Dni = usuario.Dni,
                Sueldo = usuario.Sueldo,
                FechaCreacion = usuario.FechaCreacion,
                departamento_id = usuario.departamento_id
            };
            return Ok(usuarioDTo);
        }
        [HttpPost]
        public IActionResult Crear(UsuarioCreateDTO usuario)
        {
            Usuario nuevo= new Usuario();
            nuevo.Nombre = usuario.Nombre;
            nuevo.Apellido = usuario.Apellido;
            nuevo.Dni = usuario.Dni;
            nuevo.Sueldo = usuario.Sueldo;
            nuevo.departamento_id = usuario.departamento_id;
            _iusuario.InsertarUsuario(nuevo);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Editar(int id, UsuarioCreateDTO usuario)
        {
            {
                Usuario nuevo = new Usuario();
                nuevo.usuario_id = id;
                nuevo.Nombre = usuario.Nombre;
                nuevo.Apellido = usuario.Apellido;
                nuevo.Dni = usuario.Dni;
                nuevo.Sueldo = usuario.Sueldo;
                nuevo.departamento_id = usuario.departamento_id;
                _iusuario.ActualizarUsuario(nuevo);
                return Ok();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            var usuario = _iusuario.ObtenerUsuarioPorId(id);
            if (usuario == null)
                return NotFound(); 

            _iusuario.EliminarUsuario(id);
            return NoContent();
        }
    }
}

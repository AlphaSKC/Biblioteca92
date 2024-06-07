using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WebApi92.Context;

namespace WebApi92.Services
{
    public class UsuarioServices : IUsuariosServices
    {
        private readonly ApplicationDBContext _context;
        public UsuarioServices(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Usuario>>> GetUsuarios()
        {
            try
            {
                List<Usuario> response = await _context.Usuarios.Include(x=>x.Roles).ToListAsync();
                return new Response<List<Usuario>>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio una error: " + ex.Message);
            }
        }
        public async Task<Response<UsuariosResponse>> CrearUsuario(UsuariosResponse request)
        {
            try
            {
                Usuario usuario = new Usuario
                {
                    Nombre = request.Nombre,
                    User = request.User,
                    Password = request.Password,
                    FkRol = request.FkRol
                };
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return new Response<UsuariosResponse>(request);
                 
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio una error: " + ex.Message);
            }
        }
        public async Task<Response<UsuariosResponse>> ActualizarUsuario(int id, UsuariosResponse request)
        {
            try
            {
                Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.PkUsuario == id);
                if (usuario == null)
                {
                    throw new Exception("Usuario no encontrado");
                }
                usuario.Nombre = request.Nombre;
                usuario.Password = request.Password;
                usuario.User = request.User;
                usuario.FkRol = request.FkRol;
                await _context.SaveChangesAsync();
                return new Response<UsuariosResponse>(request);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio una error: " + ex.Message);
            }
        }
        public async Task<Response<bool>> EliminarUsuario(int id)
        {
            try
            {
                Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.PkUsuario == id);
                if (usuario == null)
                {
                    throw new Exception("Usuario no encontrado");
                }
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
                return new Response<bool>(true, "Se ha eliminado con exito");
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio una error: " + ex.Message);
            }
        }
        public async Task<Response<Usuario>> GetUsuarioById(int id)
        {
            try
            {
                Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.PkUsuario == id);
                return usuario == null ? throw new Exception("Usuario no encontrado") : new Response<Usuario>(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio una error: " + ex.Message);
            }
        }
    }
}

using Domain.Entities;

namespace WebApi92.Services
{
    public interface IUsuariosServices
    {
        public Task<Response<List<Usuario>>> GetUsuarios();
        public Task<Response<UsuariosResponse>> CrearUsuario(UsuariosResponse request);
        public Task<Response<UsuariosResponse>> ActualizarUsuario(int id, UsuariosResponse request);
        public Task<Response<bool>> EliminarUsuario(int id);
        public Task<Response<Usuario>> GetUsuarioById(int id);

    }
}

using Domain.Entities;

namespace WebApi92.Services
{
    public interface IAutorServices
    {
        public Task<Response<List<Autor>>> GetAutores();
        public Task<Response<Autor>> CreateAutor(Autor a);
        public Task<Response<Autor>> UpdateAutor(Autor a, int PkAutor);
        public Task<Response<bool>> DeleteAutor(int PkAutor);
        public Task<Response<Autor>> GetAutorById(int PkAutor);

    }
}

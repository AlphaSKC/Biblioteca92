using Dapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApi92.Context;

namespace WebApi92.Services
{
    public class AutorServices : IAutorServices
    {
        private readonly ApplicationDBContext _context;
        public AutorServices(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Autor>>> GetAutores()
        {
            try
            {
                List<Autor> Response = new List<Autor>();
                var result = await _context.Database.GetDbConnection().QueryAsync<Autor>("spGetAutores",new { }, commandType: CommandType.StoredProcedure);
                Response = result.ToList();
                return new Response<List<Autor>>(Response);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio una error: " + ex.Message);
            }
        }   
        public async Task<Response<Autor>> CreateAutor(Autor a)
        {
            try
            {
                Autor result = (await _context.Database.GetDbConnection().QueryAsync<Autor>("spCrearAutor", new { a.Nombre, a.Nacionalidad }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
                return new Response<Autor>(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio una error: " + ex.Message);
            }
        }
        public async Task<Response<Autor>> UpdateAutor(Autor a, int PkAutor)
        {
            try
            {
                Autor result = (await _context.Database.GetDbConnection().QueryAsync<Autor>("spActualizarAutor", new { PkAutor, a.Nombre, a.Nacionalidad }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
                return new Response<Autor>(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio una error: " + ex.Message);
            }
        }

        public async Task<Response<bool>> DeleteAutor(int PkAutor)
        {
            try
            {
                await _context.Database.GetDbConnection().QueryAsync<Autor>("spEliminarAutor", new { PkAutor }, commandType: CommandType.StoredProcedure);
                return new Response<bool>(true, "Se ha eliminado con exito");
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio una error: " + ex.Message);
            }
        }

        public async Task<Response<Autor>> GetAutorById(int PkAutor)
        {
            try
            {
                var result = await _context.Database.GetDbConnection().QueryAsync<Autor>("spGetAutorById", new { PkAutor }, commandType: CommandType.StoredProcedure);
                return new Response<Autor>(result.FirstOrDefault());
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio una error: " + ex.Message);
            }
        }
    }
}

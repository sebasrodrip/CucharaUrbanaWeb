using Entities.Entities;

namespace Backend.Services.Interfaces
{
    public interface IRolService
    {
        Task<IEnumerable<Rol>> GetCategoriesAsync();
        Rol GetById(int id);
        bool AddRol(Rol rol);
        bool UpdateRol(Rol rol);
        bool DeteleRol(Rol rol);


    }
}

using Entities.Entities;

namespace BackEnd.Services.Interfaces
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

using Entities.Entities;

namespace Backend.Services.Interfaces
{
    public interface ICategoriumService
    {
        Task<IEnumerable<Categorium>> GetCategoriesAsync();
        Task <Categorium> GetById(int id);
        Task<bool> AddCategorium(Categorium categorium);
        Task<bool> UpdateCategorium(Categorium categorium);
        Task<bool> DeleteCategorium(int id);


    }
}

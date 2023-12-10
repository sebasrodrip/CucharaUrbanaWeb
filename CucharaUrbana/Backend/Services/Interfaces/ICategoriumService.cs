using Entities.Entities;

namespace Backend.Services.Interfaces
{
    public interface ICategoriumService
    {
        Task<IEnumerable<Categorium>> GetCategoriesAsync();
        Categorium GetById(int id);
        bool AddCategorium(Categorium categorium);
        bool UpdateCategorium(Categorium categorium);
        bool DeteleCategorium(Categorium categorium);


    }
}

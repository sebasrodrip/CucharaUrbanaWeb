using Frontend.Models;

namespace Frontend.Helpers.Interfaces
{
    public interface ICategoriumHelper
    {
        string Token { get; set; }
        List<CategoriumViewModel> GetAll();
        CategoriumViewModel GetById(int id);
        CategoriumViewModel AddCategorium(CategoriumViewModel categoriumViewModel);
        CategoriumViewModel EditCategorium(CategoriumViewModel categoriumViewModel);

        void DeleteCategorium(int id);

    }
}

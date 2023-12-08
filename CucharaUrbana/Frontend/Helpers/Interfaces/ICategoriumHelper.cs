using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface ICategoriumHelper
    {
        List<CategoriumViewModel> GetAll();
        CategoriumViewModel GetById(int id);
        CategoriumViewModel AddCategorium(CategoriumViewModel categoriumViewModel);
        CategoriumViewModel EditCategorium(CategoriumViewModel categoriumViewModel);

        void DeleteCategorium(int id);

    }
}

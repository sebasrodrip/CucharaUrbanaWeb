using Frontend.Models;

namespace Frontend.Helpers.Interfaces
{
    public interface IFacturaHelper
    {
        List<FacturaViewModel> GetAll();
        FacturaViewModel GetById(int id);
        FacturaViewModel AddFactura(FacturaViewModel FacturaViewModel);
        FacturaViewModel EditFactura(FacturaViewModel FacturaViewModel);

        void DeleteFactura(int id);

    }
}

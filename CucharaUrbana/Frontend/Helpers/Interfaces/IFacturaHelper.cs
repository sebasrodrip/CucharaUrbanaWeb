using Frontend.Models;

namespace Frontend.Helpers.Interfaces
{
    public interface IFacturaHelper
    {
        List<FacturaViewModel> GetAll();
        FacturaViewModel GetById(int id);
        FacturaViewModel AddFactura(FacturaViewModel categoryViewModel);
        FacturaViewModel EditFactura(FacturaViewModel categoryViewModel);

        void DeleteFactura(int id);

    }
}

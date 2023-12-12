using Frontend.Models;

namespace Frontend.Helpers.Interfaces
{
    public interface ICarritoHelper
    {
        List<CarritoViewModel> GetAll();
        CarritoViewModel GetById(int id);
        CarritoViewModel AddCarrito(CarritoViewModel carritoViewModel);
        CarritoViewModel EditCarrito(CarritoViewModel carritoViewModel);

        void DeleteCarrito(int id);

    }
}
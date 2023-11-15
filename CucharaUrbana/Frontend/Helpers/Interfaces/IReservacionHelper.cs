using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IReservacionHelper
    {


        List<ReservacionViewModel> GetAll();
        ReservacionViewModel GetById(int id);
        ReservacionViewModel AddProduct(ReservacionViewModel ProductViewModel);
        ReservacionViewModel EdiProduct(ReservacionViewModel ProductViewModel);

        void DeleteProduct(int id);
    }
}

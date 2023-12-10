using Backend.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace Backend.Services.Implementations
{
    public class CategoriumService : ICategoriumService
    {

        public IUnidadDeTrabajo _unidadDeTrabajo;

        public CategoriumService(IUnidadDeTrabajo unidadDeTrabajo)
        {
                _unidadDeTrabajo = unidadDeTrabajo;
        }

        public bool AddCategorium(Categorium categorium)
        {
            bool resultado =_unidadDeTrabajo._categoriumDAL.Add(categorium);
            _unidadDeTrabajo.Complete();

            return resultado;

        }

        public bool DeteleCategorium(Categorium categorium)
        {
            bool resultado = _unidadDeTrabajo._categoriumDAL.Remove(categorium);
            _unidadDeTrabajo.Complete();

            return resultado;
        }

        public Categorium GetById(int id)
        {
            Categorium categorium;
            categorium =  _unidadDeTrabajo._categoriumDAL.Get(id);
            return categorium;
        }

        public async Task<IEnumerable<Categorium>> GetCategoriesAsync()
        {
            IEnumerable<Categorium> categories;
            categories = await _unidadDeTrabajo._categoriumDAL.GetAll();
            return categories;
        }

        public bool UpdateCategorium(Categorium categorium)
        {
            bool resultado = _unidadDeTrabajo._categoriumDAL.Update(categorium);
            _unidadDeTrabajo.Complete();

            return resultado;
        }
    }
}

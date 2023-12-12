using Backend.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace Backend.Services.Implementations
{
    public class CategoriumService : ICategoriumService
    {

        IUnidadDeTrabajo _unidadDeTrabajo;
        public CategoriumService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }


        public Task<bool> AddCategorium(Categorium categorium)
        {
            try
            {
                _unidadDeTrabajo._categoriumDAL.Add(categorium);
                _unidadDeTrabajo.Complete();
                return Task.FromResult(true);
            }
            catch (Exception)
            {

                return Task.FromResult(false);
            }

        }

        public Task<bool> DeleteCategorium(int id)
        {
            try
            {
                Categorium categorium = new Categorium { CategoriaId = id };

                _unidadDeTrabajo._categoriumDAL.Remove(categorium);
                _unidadDeTrabajo.Complete();
                return Task.FromResult(true);

            }
            catch (Exception)
            {

                return Task.FromResult(false); ;
            }
        }

        public async Task<Categorium> GetById(int id)
        {
            Categorium categorium = _unidadDeTrabajo._categoriumDAL.Get(id);
            return categorium;
        }

        public async Task<IEnumerable<Categorium>> GetCategoriesAsync()
        {
            IEnumerable<Categorium> categoriums = await _unidadDeTrabajo._categoriumDAL.GetAll();
            return categoriums;
        }

        public Task<bool> UpdateCategorium(Categorium categorium)
        {
            try
            {
                _unidadDeTrabajo._categoriumDAL.Update(categorium);
                _unidadDeTrabajo.Complete();
                return Task.FromResult(true);
            }
            catch (Exception)
            {

                return Task.FromResult(false);
            }
        }
    }
}

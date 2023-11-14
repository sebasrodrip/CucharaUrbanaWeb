using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class RolService : IRolService
    {

        public IUnidadDeTrabajo _unidadDeTrabajo;

        public RolService(IUnidadDeTrabajo unidadDeTrabajo)
        {
                _unidadDeTrabajo = unidadDeTrabajo;
        }

        public bool AddRol(Rol rol)
        {
            bool resultado =_unidadDeTrabajo._rolDAL.Add(rol);
            _unidadDeTrabajo.Complete();

            return resultado;

        }

        public bool DeteleRol(Rol rol)
        {
            bool resultado = _unidadDeTrabajo._rolDAL.Remove(rol);
            _unidadDeTrabajo.Complete();

            return resultado;
        }

        public Rol GetById(int id)
        {
            Rol rol;
            rol =  _unidadDeTrabajo._rolDAL.Get(id);
            return rol;
        }

        public async Task<IEnumerable<Rol>> GetCategoriesAsync()
        {
            IEnumerable<Rol> categories;
            categories = await _unidadDeTrabajo._rolDAL.GetAll();
            return categories;
        }

        public bool UpdateRol(Rol rol)
        {
            bool resultado = _unidadDeTrabajo._rolDAL.Update(rol);
            _unidadDeTrabajo.Complete();

            return resultado;
        }
    }
}

﻿using Frontend.Models;

namespace Frontend.Helpers.Interfaces
{
    public interface IRolHelper
    {
        List<RolViewModel> GetAll();
        RolViewModel GetById(int id);
        RolViewModel AddRol(RolViewModel rolViewModel);
        RolViewModel EditRol(RolViewModel rolViewModel);

        void DeleteRol(int id);

    }
}
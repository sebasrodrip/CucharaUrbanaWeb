﻿using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface ICategoriumService
    {
        Task<IEnumerable<Categorium>> GetCategoriesAsync();
        Categorium GetById(int id);
        bool AddCategorium(Categorium categorium);
        bool UpdateCategorium(Categorium categorium);
        bool DeteleCategorium(Categorium categorium);


    }
}
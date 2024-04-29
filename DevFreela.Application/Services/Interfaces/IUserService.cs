﻿using DevFreela.Application.ViewModels;
using DevFreela.Application.InputModels;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IUserService
    {
        UserViewModel GetById(int id);
        int Create(NewUserInputModel inputModel);
    }
}

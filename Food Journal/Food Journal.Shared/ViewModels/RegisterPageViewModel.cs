﻿using Food_Journal.ClientApi.Controllers;
using Food_Journal.Shared.Services;

namespace Food_Journal.Shared.ViewModels
{
    public class RegisterPageViewModel
    {
        public RegisterPageViewModel(
            IApplicationState applicationState,
            IUserController userController)
        {
            _applicationState = applicationState;
            _userController = userController;
        }

        private readonly IApplicationState _applicationState;
        private readonly IUserController _userController;
    }
}
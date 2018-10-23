using Food_Journal.Shared.Utils;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Controls;

namespace Food_Journal.Shared.ViewModels
{
    public abstract class BaseViewModel : BindableBase
    {
        public BaseViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        protected readonly INavigationService _navigationService;

        public virtual void OnNavigatedTo()
        {

        }

        public virtual void OnNavigatedFrom()
        {

        }
    }
}

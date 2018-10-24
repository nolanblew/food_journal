using Food_Journal.DB.Models;
using Food_Journal.Shared.Services;
using Food_Journal.Shared.Utils;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Food_Journal.Shared.ViewModels
{
    public class EntriesAddPageViewModel : BaseViewModel
    {
        public EntriesAddPageViewModel(
            IApplicationState applicationState,
            INavigationService navigationService)
            : base(navigationService)
        {
            _applicationState = applicationState;

            CurrentEntry = new Entry
            {
                DateTime = DateTime.Now,
                User = _applicationState.CurrentUser,
                FoodEntries = new List<FoodItemEntry>(),
            };

            CancelCommand = new DelegateCommand(_Cancel);
            SaveCommand = new DelegateCommand(_Save);
        }

        IApplicationState _applicationState;

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public bool CanSave => _IsValid();

        Entry _currentEntry;

        public Entry CurrentEntry
        {
            get { return _currentEntry; }
            set { SetProperty(ref _currentEntry, value); }
        }

        async void _Save()
        {

        }

        void _Cancel()
        {
            _navigationService.GoBack();
        }

        bool _IsValid()
        {
            return
                CurrentEntry.DateTime.Date <= DateTime.Now.Date
                && !string.IsNullOrEmpty(CurrentEntry.Title);
        }
    }
}

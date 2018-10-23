using Food_Journal.ClientApi.Controllers;
using Food_Journal.DB.Models;
using Food_Journal.Shared.Constants;
using Food_Journal.Shared.Services;
using Food_Journal.Shared.Utils;
using GalaSoft.MvvmLight.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Navigation;

namespace Food_Journal.Shared.ViewModels
{
    public class EntriesListPageViewModel : BaseViewModel
    {
        public EntriesListPageViewModel(
            IApplicationState applicationState,
            IEntriesController entriesController,
            INavigationService navigationService)
            : base(navigationService)
        {
            _applicationState = applicationState;
            _entriesController = entriesController;

            AddEntryCommand = new DelegateCommand(_AddEntry);
            SettingsCommand = new DelegateCommand(() => _GetEntries());
        }

        private readonly IApplicationState _applicationState;
        private readonly IEntriesController _entriesController;

        public ICommand LogoutCommand { get; }
        public ICommand SearchCommand { get; }
        public ICommand AddEntryCommand { get; }
        public ICommand ViewEntryCommand { get; }
        public ICommand SettingsCommand { get; }

        public User CurrentUser => _applicationState.CurrentUser;

        bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        ObservableCollection<Entry> _nearbyEntries;

        public ObservableCollection<Entry> NearbyEntries
        {
            get { return _nearbyEntries; }
            set { SetProperty(ref _nearbyEntries, value); }
        }

        public override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            _GetEntries();
        }

        async Task _GetEntries()
        {
            try
            {
                IsBusy = true;
                var entries = await _entriesController.GetAllEntries(_applicationState.CurrentUser);
                NearbyEntries = new ObservableCollection<Entry>(entries);
            }
            finally
            {
                IsBusy = false;
            }
        }

        void _AddEntry()
        {
            if (IsBusy) { return; }
            _navigationService.NavigateTo(PageTokens.EntriesAddPage);
        }
    }
}

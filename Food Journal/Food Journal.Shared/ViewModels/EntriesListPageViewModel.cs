using Food_Journal.ClientApi.Controllers;
using Food_Journal.DB.Models;
using Food_Journal.Shared.Constants;
using Food_Journal.Shared.Services;
using Food_Journal.Shared.Utils;
using GalaSoft.MvvmLight.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Navigation;

namespace Food_Journal.Shared.ViewModels
{
    public class EntriesListPageViewModel : BaseViewModel
    {
        public EntriesListPageViewModel(
            IApplicationState applicationState,
            ILocationService locationService,
            IEntriesController entriesController,
            INavigationService navigationService)
            : base(navigationService)
        {
            _applicationState = applicationState;
            _locationService = locationService;
            _entriesController = entriesController;

            AddEntryCommand = new DelegateCommand(_AddEntry);
            SettingsCommand = new DelegateCommand(() =>
            {
                _GetLocation();
                _GetEntries();
            });
        }

        private readonly IApplicationState _applicationState;
        private readonly ILocationService _locationService;
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

        string _bannerMessage;

        public string BannerMessage
        {
            get { return _bannerMessage; }
            set { SetProperty(ref _bannerMessage, value); }
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

            _GetLocation();
            _GetEntries();
        }

        async Task _GetLocation()
        {
            if (!_locationService.HasLocationPermissions())
            {
                BannerMessage = "Location access not granted";
                return;
            }

            BannerMessage = "Getting location...";

            var location = await _locationService.GetCurrentLocation();

            if (!location.HasValue)
            {
                BannerMessage = "Could not get location.";
                return;
            }

            BannerMessage = $"Location at ({location.Value.Latitude}, {location.Value.Longitute})";
            var dataPackage = new DataPackage();
            dataPackage.SetText($"{location.Value.Latitude},{location.Value.Longitute}");
            Clipboard.SetContent(dataPackage);
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

using Food_Journal.Shared.Utils;
using GalaSoft.MvvmLight.Views;
using Windows.UI.Xaml.Navigation;

namespace Food_Journal.Shared.ViewModels
{
    public abstract class BaseViewModel : BindableBase
    {
        public BaseViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        protected readonly INavigationService _navigationService;

        public virtual void OnNavigatedTo(NavigationEventArgs e) { }

        public virtual void OnNavigatingFrom(NavigatingCancelEventArgs e) { }

        public virtual void OnNavigatedFrom(NavigationEventArgs e) { }
    }
}

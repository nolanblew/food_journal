using Food_Journal.Shared.ViewModels;
using Unity;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Food_Journal.Shared.Views
{
    public partial class ConnectorPage : Page
    {
        public void InitializeViewModel<T>() where T : BaseViewModel
        {
            _baseViewModel = App.Container.Resolve<T>();
            DataContext = _baseViewModel;
        }

        protected BaseViewModel _baseViewModel;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            _baseViewModel.OnNavigatedTo(e);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            _baseViewModel.OnNavigatingFrom(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            _baseViewModel.OnNavigatedFrom(e);
        }
    }
}

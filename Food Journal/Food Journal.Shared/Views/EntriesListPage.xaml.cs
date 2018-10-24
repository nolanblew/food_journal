using Food_Journal.Shared.ViewModels;
using Unity;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Food_Journal.Shared.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EntriesListPage : ConnectorPage
    {
        public EntriesListPage()
        {
            base.InitializeViewModel<EntriesListPageViewModel>();
            this.InitializeComponent();
        }
    }
}

using Food_Journal.Shared.ViewModels;

namespace Food_Journal.Shared.Views
{
    public sealed partial class EntriesAddPage : ConnectorPage
    {
        public EntriesAddPage()
        {
            base.InitializeViewModel<EntriesAddPageViewModel>();
            this.InitializeComponent();
        }
    }
}

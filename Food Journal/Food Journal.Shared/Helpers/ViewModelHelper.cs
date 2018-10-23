using Food_Journal.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Controls;
using Unity;

namespace Food_Journal.Shared.Helpers
{
    public static class ViewModelHelper
    {
        public static T GetViewModel<T>(this Page page) where T : BaseViewModel
        {
            var vm = App.Container.Resolve<T>();
        }
    }
}

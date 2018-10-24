using Food_Journal.Shared.Views;
using System;
using System.Collections.Generic;

namespace Food_Journal.Shared.Constants
{
    public static class PageTokens
    {
        public static Dictionary<string, Type> TokenMappings => new Dictionary<string, Type>()
        {
            {LoginPage, typeof(LoginPage)},
            {RegisterPage, typeof(RegisterPage)},
            {EntriesListPage, typeof(EntriesListPage)},
            {EntriesAddPage, typeof(EntriesAddPage)},
        };

        public const string LoginPage = "LoginPage";
        public const string RegisterPage = "RegisterPage";
        public const string EntriesListPage = "EntriesListPage";
        public const string EntriesAddPage = "EntriesAddPage";
    }
}
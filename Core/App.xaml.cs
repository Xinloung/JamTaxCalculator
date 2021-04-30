using JamTax.Core;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JamTax
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new JamTaxShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

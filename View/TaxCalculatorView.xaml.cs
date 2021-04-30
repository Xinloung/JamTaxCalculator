using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JamTax.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaxCalculatorView : ContentPage
    {
        public TaxCalculatorView()
        {
            InitializeComponent();
        }
        public static void InitializeCulture()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        }
    }
}
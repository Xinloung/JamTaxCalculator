using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace JamTax.ViewModel
{
    class BaseViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        string title = string.Empty;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
            }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
   [CallerMemberName] string propertyName = "",
   Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }


        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public const double _INCOME_TAX_RATE = 0.25;
        public const double _MAX_INCOME_TAX_RATE = 0.30;
        public const double _EDUCATION_TAX_RATE = 0.0225;
        public const double _NATIONAL_INSURANCE_SCHEME_RATE = 0.03;
        public const double _NATIONAL_HOUSING_TRUST_RATE = 0.02;
        public const double _DEFAULT_PENSIONABLE_RATE = 0.05;


        //THRESHOLD
        public const double _NATIONAL_INSURANCE_SCHEME_THRESHOLD = 3000000.00;
        public const double _YEARLY_NATIONAL_INSURANCE_SCHEME_THRESHOLD = (_NATIONAL_INSURANCE_SCHEME_THRESHOLD * _NATIONAL_INSURANCE_SCHEME_RATE);
        public const double _MONTHLY_NATIONAL_INSURANCE_SCHEME_THRESHOLD = _YEARLY_NATIONAL_INSURANCE_SCHEME_THRESHOLD / 12;
        public const double _TAXABLE_SALARY = 1500096.00;
        public const double _INCOME_TAX_THRESHOLD = 1500096.00;
        public const double _MAX_INCOME_TAX_THRESHOLD = 6000000.01;
        public const double _MONTHLY_THRESHOLD = 125008.00;
        public const double _MAX_MONTHLY_THRESHOLD = 500000.00;

    }

}

using System;
using System.Collections.Generic;
using System.Text;

namespace JamTax.Model
{
    public class TaxRatesModel
    {
      
            public double IncomeTaxRate { get{ return _INCOME_TAX_RATE; } set { value = _INCOME_TAX_RATE; } }


        public const double _INCOME_TAX_RATE = 0.25;
        private const double _MAX_INCOME_TAX_RATE = 0.30;
        private const double _EDUCATION_TAX_RATE = 0.0225;
        private const double _NATIONAL_INSURANCE_SCHEME_RATE = 0.03;
        private const double _NATIONAL_HOUSING_TRUST_RATE = 0.02;
        private const double _DEFAULT_PENSIONABLE_RATE = 0.05;


        //THRESHOLD
        private const double _NATIONAL_INSURANCE_SCHEME_THRESHOLD = 3000000.00;
        private const double _YEARLY_NATIONAL_INSURANCE_SCHEME_THRESHOLD = (_NATIONAL_INSURANCE_SCHEME_THRESHOLD * _NATIONAL_INSURANCE_SCHEME_RATE);
        private const double _MONTHLY_NATIONAL_INSURANCE_SCHEME_THRESHOLD = _YEARLY_NATIONAL_INSURANCE_SCHEME_THRESHOLD / 12;
        private const double _TAXABLE_SALARY = 1500096.00;
        private const double _INCOME_TAX_THRESHOLD = 1500096.00;
        private const double _MAX_INCOME_TAX_THRESHOLD = 6000000.01;
        private const double _MONTHLY_THRESHOLD = 125008.00;
        private const double _MAX_MONTHLY_THRESHOLD = 500000.00;
            
        
    }
}

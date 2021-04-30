using System.Collections.Generic;
using JamTax.Model;

namespace JamTax.ViewModel
{
    class IncomeTaxCalculatorViewModel : BaseViewModel
    {
        public IncomeTaxCalculatorViewModel()
        {
            Title = "Income Tax Calculator";

        }


        private readonly TaxRatesModel Rates = new TaxRatesModel();

        

        double getIncome;
        public double GetIncome
        { get => getIncome;
            set
            {
                SetProperty(ref getIncome, value);
                CalculateTaxYearly(GetIncome, PayCycle[PayCycleIndex]);
               
            }
        }
        double incomeTax = 0.00;
        public double IncomeTax
        {
            get => incomeTax;
            set {
                SetProperty(ref incomeTax, value);
            } }
        double nis = 0.00;
        public double NIS
        {
            get => nis;
            set
            {
                SetProperty(ref nis, value);
            }
        }
        double educationTax = 0.00;
        public double EducationTax
        {
            get => educationTax;
            set
            {
                SetProperty(ref educationTax, value);
            }
        }
        double nht = 0.00;
        public double NHT
        {
            get => nht;
            set
            {
                SetProperty(ref nht, value);
            }
        }
        int payCycleIndex = 0;

        public int PayCycleIndex
        {
            get => payCycleIndex;
            set
            {
                SetProperty(ref payCycleIndex, value);
                CalculateTaxYearly(GetIncome, PayCycle[PayCycleIndex]);

            }
        }
        double pensionRate;
        public double PensionRate
        {
            get => pensionRate;
            set
            {
                SetProperty(ref pensionRate, value);
                CalculateTaxYearly(GetIncome, PayCycle[PayCycleIndex]);
            }
        }
        double pensionableAmount;
        public double PensionableAmount
        {
            get => pensionableAmount;
            set
            {
                SetProperty(ref pensionableAmount, value);
            }
        }
        public  List<string> PayCycle => new List<string> {"MTH","YR"};
        private void CalculateTaxYearly(double income, string paymentCycle)
        {
            IncomeTax = 0;
            double pensionRate = PensionRate > 0 ? PensionRate/100 : _DEFAULT_PENSIONABLE_RATE;

            PensionableAmount = income * pensionRate;
            
            double statutoryIncome = income - (PensionableAmount + NIS);
            statutoryIncome = statutoryIncome < 0 ? 0 : statutoryIncome;

            EducationTax = statutoryIncome * _EDUCATION_TAX_RATE;
            NHT = income * _NATIONAL_HOUSING_TRUST_RATE;
            
            switch(paymentCycle)
            {
                case "MTH":
                    NIS = _MONTHLY_NATIONAL_INSURANCE_SCHEME_THRESHOLD;
                    if (income >= _MAX_MONTHLY_THRESHOLD)
                    {
                        IncomeTax = (statutoryIncome - _MAX_MONTHLY_THRESHOLD) * _MAX_INCOME_TAX_RATE;
                    }else if(income >= _MONTHLY_THRESHOLD)
                    {
                        IncomeTax = (statutoryIncome - _MONTHLY_THRESHOLD) * Rates.IncomeTaxRate;
                    }
                    break;
                case "YR":
                    NIS = _YEARLY_NATIONAL_INSURANCE_SCHEME_THRESHOLD;
                    if (income >= _MAX_INCOME_TAX_THRESHOLD)
                    {
                        IncomeTax = (statutoryIncome - _MAX_INCOME_TAX_THRESHOLD) * _MAX_INCOME_TAX_RATE;
                    }
                    else if (income >= _INCOME_TAX_THRESHOLD)
                    {
                        IncomeTax = (statutoryIncome - _INCOME_TAX_THRESHOLD) * _INCOME_TAX_RATE;
                    }
                    break;
                default:
                    break;
            }
        }
       
    }
}

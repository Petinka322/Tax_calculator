
namespace Tax_Calculator.Models

{
    using Microsoft.EntityFrameworkCore;
    public class Taxes
    {
        private int id;
        private decimal incomeTax;
        private decimal socialTax;
        private decimal totalTax;
        private decimal netIncome;
        private decimal grossIncome;
        private decimal charitySpent;
        public int Id { get { return id; } set { id = value; } }
        public decimal IncomeTax
        {
            get { return incomeTax; }
            set { incomeTax = value; }
        }
        public decimal CharitySpent 
        {
            get { return charitySpent; }
            set { charitySpent = value; }
        }
        public decimal TotalTax
        {
            get { return totalTax; }
            set { totalTax = value; }
        }
        public decimal NetIncome
        {
            get { return netIncome; }
            set { netIncome = value; }
        }
        public decimal SocialTax
        {
            get { return socialTax; }
            set { socialTax = value; }
        }
        public decimal GrossIncome
        {
            get { return grossIncome; }
            set { grossIncome = value; }
        }
        //public Taxes(int id,decimal incomeTax,decimal socialTax, decimal totalTax, decimal netIncome)
        //{
        //    this.Id = id;
        //    this.IncomeTax = incomeTax;
        //    this.SocialTax=socialTax;
        //    this.TotalTax = totalTax;
        //    this.NetIncome = netIncome;
        //}

    }
}

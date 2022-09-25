namespace Tax_Calculator.Models
{
    public class TaxPayer
    {
        private int id;
        private string fullName;
        private DateTime dateOfBirth;
        private decimal grossIncome;
        private string ssn;
        private decimal charitySpent;
        public int Id { get { return id; } set { id = value; } }  
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }   
        }
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; } 
            set { dateOfBirth = value; }    
        }
        public decimal GrossIncome
        {
            get { return grossIncome; }
            set { grossIncome = value; }    
        }
        public string Ssn
        {
            get { return ssn; } 
            set { ssn = value; }    
        }
        public decimal CharitySpent
        {
            get { return charitySpent; }
            set { charitySpent = value; }
        }
        public TaxPayer(int id,string fullName, DateTime dateOfBirth, decimal grossIncome, string ssn, decimal charitySpent)
        {
            this.Id = id;
            this.FullName= fullName;
            this.DateOfBirth = dateOfBirth;
            this.GrossIncome= grossIncome;
            this.Ssn= ssn;
            this.CharitySpent= charitySpent;
        }
    }
}   

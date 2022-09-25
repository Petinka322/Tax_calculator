using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Tax_Calculator.Models;

namespace Tax_Calculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        const int noTaxationIncome = 1000;
        const int noSocialContributionApplyingAbove= 3000;
        const int socialContributionTaxAppliedOn = 2000;
        const decimal maxCharitySpentPercentage = 0.10m;
        const decimal socialContribution = 0.15m;
        const decimal IncomeTax = 0.10m;
        const decimal noTax = 0;

        [SwaggerOperation(Summary = "Calculate Taxes", Description = "Calculate Taxes")]
        [SwaggerResponse(200, "Ok")]
        [HttpPost]
        public IActionResult Calculate( TaxPayer taxPayer)
        {
            
            try
            {
                Taxes responseTaxes = new Taxes();
                responseTaxes.GrossIncome = taxPayer.GrossIncome;
                if (taxPayer.CharitySpent > 0)
                {
                    responseTaxes.CharitySpent = taxPayer.CharitySpent;
                    decimal allowedCharity= CheckCharityPercentage(taxPayer.CharitySpent, taxPayer.GrossIncome);
                    if (taxPayer.GrossIncome - allowedCharity > noTaxationIncome)
                    {
                        responseTaxes.IncomeTax = CalculateIncomeTax(taxPayer.GrossIncome -allowedCharity);
                        responseTaxes.SocialTax = CalculateSocialTax(taxPayer.GrossIncome - allowedCharity);
                        responseTaxes.TotalTax = responseTaxes.IncomeTax + responseTaxes.SocialTax;
                        responseTaxes.NetIncome = taxPayer.GrossIncome - responseTaxes.TotalTax;
                    }
                    else
                    {
                        responseTaxes.IncomeTax = noTax;
                        responseTaxes.SocialTax = noTax;
                        responseTaxes.TotalTax = noTax;
                        responseTaxes.NetIncome = taxPayer.GrossIncome - responseTaxes.TotalTax;

                    }

                }
                else 
                {
                    responseTaxes.CharitySpent = noTax;
                    if (taxPayer.GrossIncome>noTaxationIncome)
                    {
                        responseTaxes.IncomeTax = CalculateIncomeTax(taxPayer.GrossIncome);
                        responseTaxes.SocialTax =CalculateSocialTax(taxPayer.GrossIncome);
                        responseTaxes.TotalTax = responseTaxes.IncomeTax + responseTaxes.SocialTax;
                        responseTaxes.NetIncome = taxPayer.GrossIncome - responseTaxes.TotalTax;
                    }
                    else
                    {
                        responseTaxes.IncomeTax = noTax;
                        responseTaxes.SocialTax = noTax;
                        responseTaxes.TotalTax = noTax;
                        responseTaxes.NetIncome = taxPayer.GrossIncome;

                    }

                }
                
               
                return Ok(responseTaxes);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }
        private decimal CalculateIncomeTax(decimal income)
        {
            if (income > noTaxationIncome)
                return (income - noTaxationIncome) * IncomeTax;
            else return 0;
        }
        private decimal CalculateSocialTax(decimal income)
        {
            if (income > noTaxationIncome)
            {
                if (income > noSocialContributionApplyingAbove)
                {
                    return socialContributionTaxAppliedOn * socialContribution;
                }
                else
                {
                    return (income - noTaxationIncome) * socialContribution;
                }
            }
            else 
            {
                return 0;
            }
        }
        private decimal CheckCharityPercentage(decimal charityDonation,decimal income)
        {
            if (income * maxCharitySpentPercentage >= charityDonation)
            {
                return charityDonation;
            }
            else 
            {
                return income * maxCharitySpentPercentage;
            }
        }
    }
}

using Csla.Rules;
using ManagementSystem.BusinessLogicLayer;
using System.Text.RegularExpressions;

namespace ManagementSystem.BusinessRules
{
    public class QualificationRule : BusinessRule
    {


        protected override void Execute(IRuleContext context)
        {
            var item = (context.Target as FacilitatorBL);

            if (!Regex.IsMatch(item.Qualification, @"^[A-Z][a-z]*: [A-Z][a-z]*( [A-Z][a-z]*)*$"))
            {
                context.AddErrorResult("Qualification must be in this format: Degree: Degree Name (e.g Bsc: Economics)");
            }
        }
    }
}

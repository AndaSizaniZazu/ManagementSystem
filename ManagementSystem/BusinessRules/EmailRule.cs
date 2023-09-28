using Csla.Rules;
using ManagementSystem.BusinessLogicLayer;
using System.Text.RegularExpressions;

namespace ManagementSystem.BusinessRules
{
    public class EmailRule : BusinessRule
    {


        protected override void Execute(IRuleContext context)
        {
            var item = (context.Target as FacilitatorBL);

            if (!Regex.IsMatch(item.FacilitatorEmail, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                context.AddErrorResult("A valid email address is required.");
            }
        }
    }
}

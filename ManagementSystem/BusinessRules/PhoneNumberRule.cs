using Csla.Rules;
using ManagementSystem.BusinessLogicLayer;

namespace ManagementSystem.BusinessRules
{
    public class PhoneNumberRule : BusinessRule
    {


        protected override void Execute(IRuleContext context)
        {
            var item = (context.Target as FacilitatorBL);

            if (item.FacilitatorPhoneNumber.Length != 10)
            {
                context.AddErrorResult("Facilitator cellphone must be 10 digits long");
            }
        }
    }
}

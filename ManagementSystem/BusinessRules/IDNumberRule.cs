using Csla.Rules;
using ManagementSystem.BusinessLogicLayer;

namespace ManagementSystem.BusinessRules
{
    public class IDNumberRule : BusinessRule
    {


        protected override void Execute(IRuleContext context)
        {
            var item = (context.Target as FacilitatorBL);

            if (item.FacilitatorIdNumber.Length != 13)
            {
                context.AddErrorResult("Facilitator Id Number must be 13 digits long");
            }
        }
    }
}

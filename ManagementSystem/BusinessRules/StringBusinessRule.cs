using Csla.Rules;
using ManagementSystem.BusinessLogicLayer;

namespace ManagementSystem.Models
{
    public class StringBusinessRule : BusinessRule
    {


        protected override void Execute(IRuleContext context)
        {
            var item = (context.Target as ClassBL);

            if (item.ClassName.Any(x => char.IsDigit(x)))
            {
                context.AddErrorResult("Class Name must be a string");
            }
        }
    }
}

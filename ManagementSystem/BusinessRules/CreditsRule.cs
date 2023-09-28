using Csla.Rules;
using ManagementSystem.BusinessLogicLayer;

namespace ManagementSystem.BusinessRules
{
    public class CreditsRule : BusinessRule
    {

        private const int min = 1;
        private const int max = 260;
        protected override void Execute(IRuleContext context)
        {
            var course = (context.Target as CourseBL);
            if (course.Credits < min || course.Credits > max)
            {
                context.AddErrorResult($"Credits must be between {min} and {max}");
            }

        }
    }
}

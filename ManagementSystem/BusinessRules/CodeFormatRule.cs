using Csla.Rules;
using ManagementSystem.BusinessLogicLayer;
using System.Text.RegularExpressions;

namespace ManagementSystem.BusinessRules
{
    public class CodeFormatRule : BusinessRule
    {
        private const string pattern = @"^[A-Z]{3}\d{3}$";
        protected override void Execute(IRuleContext context)
        {
            var course = (context.Target as CourseBL);
            if (!Regex.IsMatch(course.Code, pattern))
            {
                context.AddErrorResult("Code must have the format AAA123");
            }
        }
    }
}

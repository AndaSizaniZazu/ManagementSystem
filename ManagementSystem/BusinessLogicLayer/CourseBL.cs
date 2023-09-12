using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using Csla;
using Csla.Rules;
using ManagementSystem.DataAccessLayer;

namespace ManagementSystem.BusinessLogicLayer

{
    [Serializable]
    public class CourseBL : BusinessBase<CourseBL>
    {
        // Register the properties to the property system
        //Helps us to access the methods of the property system
        public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(c => c.Id);
        // Defining the properties of the course class
        public int Id
        {
            get { return GetProperty(IdProperty); }
            set { SetProperty(IdProperty, value); }
        }

        public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(c => c.Name);


        [Required]
        public string Name
        {
            get { return GetProperty(NameProperty); }
            set { SetProperty(NameProperty, value); }
        }
        public static readonly PropertyInfo<string> CodeProperty = RegisterProperty<string>(c => c.Code);

        [Required]
        public string Code
        {
            get { return GetProperty(CodeProperty); }
            set { SetProperty(CodeProperty, value); }
        }

        public static readonly PropertyInfo<string> DescriptionProperty = RegisterProperty<string>(c => c.Description);


        [Required]
        public string Description
        {
            get { return GetProperty(DescriptionProperty); }
            set { SetProperty(DescriptionProperty, value); }
        }
        public static readonly PropertyInfo<int> CreditsProperty = RegisterProperty<int>(c => c.Credits);
        //public static readonly PropertyInfo<List<Course>> PrerequisitesProperty = RegisterProperty<List<Course>>(c => c.Prerequisites);

        [Required]
        public int Credits
        {
            get { return GetProperty(CreditsProperty); }
            set { SetProperty(CreditsProperty, value); }
        }

        //Mapp Entity objects to Business objects
        public CourseEntity Map()
        {
          return  new CourseEntity()
            {
                Id = Id,
                Name = Name,
                Code = Code,
                Description = Description,
                Credits = Credits
            };



        }

        // Business rules
        //Custom business rules
        protected override void AddBusinessRules()
        {
         
            BusinessRules.AddRule(new CreditsRangeRule { PrimaryProperty = CreditsProperty });
            BusinessRules.AddRule(new CodeFormatRule { PrimaryProperty = CodeProperty });
            BusinessRules.AddRule(new NameRule { PrimaryProperty = NameProperty });

            base.AddBusinessRules();
        }
        // define a custom rule that checks if Credits is between 1 and 10
        public class CreditsRangeRule : BusinessRule
        {
            
            private const int min = 1;
            private const int max = 60;
            protected override void Execute(IRuleContext context)
            {
                var course = (context.Target as CourseBL);
                if (course.Credits < min || course.Credits > max)
                {
                    context.AddErrorResult($"Credits must be between {min} and {max}");
                }

            }
        }
        public class CodeFormatRule : BusinessRule
        {
            private const string pattern = @"^[A-Z]{3}\d{3}$";
            protected override void Execute(IRuleContext context)
            {
                var course = (context.Target as CourseBL);
                if(!Regex.IsMatch(course.Code, pattern))
                {
                    context.AddErrorResult("Code must have the format AAA123");
                }
            }
        }

        public class NameRule : BusinessRule
        {
          
            private const string pattern = @"^[A-Z]+( [A-Z]+)*$";
            protected override void Execute(IRuleContext context)
            {
                var course = (context.Target as CourseBL);
              
                if (course.Name.Any(x => char.IsDigit(x)))
                {
                    context.AddErrorResult("Course Name must be a string");
                }
            }
        }

        //Add CSLA Objects


        [Fetch]
        protected void Fetch(CourseEntity course)
        {
            LoadProperty(IdProperty, course.Id);
            LoadProperty(NameProperty, course.Name);
            LoadProperty(CodeProperty, course.Code);
            LoadProperty(DescriptionProperty, course.Description);
            LoadProperty(CreditsProperty, course.Credits);
        }

       
        [Create]

        protected void Create()
        {
            BusinessRules.CheckRules();
        }
        [Insert]
        protected void Insert([Inject] ICourseDAL dataAccessLayer)
        {
           
            dataAccessLayer.Insert(Map());
            BusinessRules.CheckRules();
        }
        [Update]
        protected void Update([Inject] ICourseDAL dataAccessLayer)
        {
            
            dataAccessLayer.Update(Map());
            BusinessRules.CheckRules();
        }
        [Delete]
        protected void Delete([Inject] ICourseDAL dataAccessLayer)
        {
           
            dataAccessLayer.Delete(Map());
        }


    }
}

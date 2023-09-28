using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using Csla;
using Csla.Rules;
using ManagementSystem.BusinessRules;
using ManagementSystem.DataAccessLayer;
using ManagementSystem.Models;

namespace ManagementSystem.BusinessLogicLayer

{
    [Serializable]
    public class CourseBL : BusinessBase<CourseBL>
    {
       
       
        public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(c => c.Id);
       
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
       

        [Required]
        public int Credits
        {
            get { return GetProperty(CreditsProperty); }
            set { SetProperty(CreditsProperty, value); }
        }
        public static readonly PropertyInfo<string> DepartmentProperty = RegisterProperty<string>(c => c.Department);

        [Required]
        public string Department
        {
            get { return GetProperty(DepartmentProperty); }
            set { SetProperty(DepartmentProperty, value); }
        }
        public static readonly PropertyInfo<List<ClassEntity>> ClassProperty = RegisterProperty<List<ClassEntity>>(c => c.Class);

        public List<ClassEntity> Class
        {
            get { return GetProperty(ClassProperty); }
            set { SetProperty(ClassProperty, value); }
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
                Credits = Credits,
                Department = Department,
                Class = Class
            };



        }

        // Business rules
        //Custom business rules
        protected override void AddBusinessRules()
        {
         
            BusinessRules.AddRule(new CreditsRule { PrimaryProperty = CreditsProperty });
            BusinessRules.AddRule(new CodeFormatRule { PrimaryProperty = CodeProperty });
            BusinessRules.AddRule(new StringBusinessRule { PrimaryProperty = NameProperty });
            BusinessRules.AddRule(new StringBusinessRule { PrimaryProperty = DepartmentProperty });
            base.AddBusinessRules();
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
            LoadProperty(DepartmentProperty, course.Department);
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
        [DeleteSelf]
        protected void Delete([Inject] ICourseDAL dataAccessLayer)
        {
           
            dataAccessLayer.Delete(Map());
        }


    }
}

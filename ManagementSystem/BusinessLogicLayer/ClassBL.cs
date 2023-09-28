using Csla;
using Csla.Core;
using Csla.Rules;
using ManagementSystem.DataAccessLayer;
using ManagementSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ManagementSystem.BusinessLogicLayer
{
    [Serializable]
    public class ClassBL:BusinessBase<ClassBL>
    {
 

        public static readonly PropertyInfo<int> ClassIdProperty = RegisterProperty<int>(c => c.ClassId);

        public int ClassId
        {
            get { return GetProperty(ClassIdProperty); }
            set { SetProperty(ClassIdProperty, value); }
        }

        public static readonly PropertyInfo<LookupList> FacilitatorsListProperty = RegisterProperty<LookupList>(c => c.FacilitatorsList);

        public LookupList FacilitatorsList
        {
            get { return GetProperty(FacilitatorsListProperty); }
            set { SetProperty(FacilitatorsListProperty, value); }
        }

        public static readonly PropertyInfo<LookupList> CourseListProperty = RegisterProperty<LookupList>(c => c.CoursesList);

        public LookupList CoursesList
        {
            get { return GetProperty(CourseListProperty); }
            set { SetProperty(CourseListProperty, value); }
        }
        public static readonly PropertyInfo<string> ClassNameProperty = RegisterProperty<string>(c => c.ClassName);


        [Required]
        public string ClassName
        {
            get { return GetProperty(ClassNameProperty); }
            set { SetProperty(ClassNameProperty, value); }
        }
       

        public static readonly PropertyInfo<int> FacilitatorIdProperty = RegisterProperty<int>(c => c.FacilitatorFullName);



        public string FacilitatorFullName
        {
            get
            {
                return FacilitatorsList.Value(GetProperty(FacilitatorIdProperty).ToString());
            }
            set
            {
                SetProperty(FacilitatorIdProperty, Convert.ToInt32(FacilitatorsList.Key(value)));
            }
        }
        public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(c => c.CourseName);

        public string CourseName
        {
            get
            {
                return CoursesList.Value(GetProperty(IdProperty).ToString());
            }
            set
            {
                SetProperty(IdProperty, Convert.ToInt32(CoursesList.Key(value)));
            }
        }
        public int Id
        {
            get => ReadProperty(IdProperty);
            set => SetProperty(IdProperty, value);
        }


        public int FacilitatorId
        {
            get => ReadProperty(FacilitatorIdProperty);
            set => SetProperty(FacilitatorIdProperty, value);
        }


        public ClassEntity Map()
        {
            return new ClassEntity()
            {
                ClassId = ClassId,
                ClassName = ClassName,
                Id = Id,
                FacilitatorId = FacilitatorId,
                
                
               
            };

        }

     
        protected override void AddBusinessRules()
        {

            BusinessRules.AddRule(new StringBusinessRule { PrimaryProperty = ClassNameProperty });
            base.AddBusinessRules();
        }
        
       
        //Add CSLA Objects

        [Create]
        protected async Task Create([Inject] IDataPortal<LookupList> listDP)
        {
            await LoadLookups(listDP);
            BusinessRules.CheckRules();
        }

        [Fetch]
        protected async void Fetch(ClassEntity item, [Inject] IDataPortal<LookupList> listDP)
        {
            LoadProperty(ClassIdProperty, item.ClassId);
            LoadProperty(ClassNameProperty, item.ClassName);
            LoadProperty(IdProperty, item.Id);
            LoadProperty(FacilitatorIdProperty, item.FacilitatorId);
            await LoadLookups(listDP);
        }



        async Task LoadLookups(IDataPortal<LookupList> listDP)
        {
            LoadProperty(FacilitatorsListProperty, await listDP.FetchAsync("Facilitator_Table", "F_Id", "F_FullName"));
            LoadProperty(CourseListProperty, await listDP.FetchAsync("Course_Table", "Id", "Name"));
            
        }

        [Insert]
        protected void Insert([Inject] IClassDAL dataAccessLayer)
        {

            dataAccessLayer.Insert(Map());
            BusinessRules.CheckRules();
        }
        [Update]
        protected void Update([Inject] IClassDAL dataAccessLayer)
        {

            dataAccessLayer.Update(Map());
            BusinessRules.CheckRules();
        }
        [DeleteSelf]
        protected void Delete([Inject] IClassDAL dataAccessLayer)
        {

            dataAccessLayer.Delete(Map());
        }
    }
}

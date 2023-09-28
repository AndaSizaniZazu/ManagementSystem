using Csla;
using Csla.Core;
using Csla.Rules;
using ManagementSystem.DataAccessLayer;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ManagementSystem.BusinessLogicLayer
{
    [Serializable]
    public class StudentBL:BusinessBase<StudentBL>
    {
        

        public static readonly PropertyInfo<int> StudentIdProperty = RegisterProperty<int>(c => c.StudentId);

        public int StudentId
        {
            get { return GetProperty(StudentIdProperty); }
            set { SetProperty(StudentIdProperty, value); }
        }

      

        public static readonly PropertyInfo<string> FullNameProperty = RegisterProperty<string>(c => c.FullName);


        [Required]
        public string FullName
        {
            get { return GetProperty(FullNameProperty); }
            set { SetProperty(FullNameProperty, value); }
        }
        public static readonly PropertyInfo<string> StudentEmailProperty = RegisterProperty<string>(c => c.StudentEmail);

        
        public string StudentEmail
        {
            get { return GetProperty(StudentEmailProperty); }
            set { SetProperty(StudentEmailProperty, value); }
        }

        public static readonly PropertyInfo<string> StudentPhoneNumberProperty = RegisterProperty<string>(c => c.StudentPhoneNumber);


        public string StudentPhoneNumber
        {
            get { return GetProperty(StudentPhoneNumberProperty); }
            set { SetProperty(StudentPhoneNumberProperty, value); }
        }


        public static readonly PropertyInfo<DateTime> EnrollmentDateProperty = RegisterProperty<DateTime>(c => c.EnrollmentDate);


        public DateTime? EnrollmentDate
        {
            get { return GetProperty(EnrollmentDateProperty); }
            set { SetProperty(EnrollmentDateProperty, value); }
        }

        public int Id
        {
            get { return GetProperty(IdProperty); }
            set { SetProperty(IdProperty, value); }
        }

        public static readonly PropertyInfo<LookupList> CourseListProperty = RegisterProperty<LookupList>(c => c.CoursesList);

        public LookupList CoursesList
        {
            get { return GetProperty(CourseListProperty); }
            set { SetProperty(CourseListProperty, value); }
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


        //Mapp Entity objects to Business objects
        public StudentEntity Map()
        {
            return new StudentEntity()
            {
                StudentId = StudentId,
                FullName = FullName,
                StudentEmail = StudentEmail,
                StudentPhoneNumber = StudentPhoneNumber,
                EnrollmentDate = EnrollmentDate,
                Id = Id


            };

        }

        
        //Add CSLA Objects


        [Fetch]
        protected  async void Fetch(StudentEntity student, [Inject] IDataPortal<LookupList> listDP)
        {
            LoadProperty(StudentIdProperty, student.StudentId);
            LoadProperty(FullNameProperty, student.FullName);
            LoadProperty(StudentEmailProperty, student.StudentEmail);
            LoadProperty(StudentPhoneNumberProperty, student.StudentPhoneNumber);
            LoadProperty(EnrollmentDateProperty, student.EnrollmentDate);
            LoadProperty(IdProperty, student.Id);
            await LoadLookups(listDP);


        }
        async Task LoadLookups(IDataPortal<LookupList> listDP)
        {
            LoadProperty(CourseListProperty, await listDP.FetchAsync("Course_Table", "Id", "Name"));

        }


        [Create]
        protected async void Create([Inject] IDataPortal<LookupList> listDP)
        {
            EnrollmentDate = DateTime.Now;
            await LoadLookups(listDP);
            BusinessRules.CheckRules();
        }
        [Insert]
        protected void Insert([Inject] IStudentDAL dataAccessLayer)
        {

            dataAccessLayer.Insert(Map());
            BusinessRules.CheckRules();
        }
        [Update]
        protected void Update([Inject] IStudentDAL dataAccessLayer)
        {

            dataAccessLayer.Update(Map());
            BusinessRules.CheckRules();
        }
        [DeleteSelf]
        protected void Delete([Inject] IStudentDAL dataAccessLayer)
        {

            dataAccessLayer.Delete(Map());
        }
    }
}

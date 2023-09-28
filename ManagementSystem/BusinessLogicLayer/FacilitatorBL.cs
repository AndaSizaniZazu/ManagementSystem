using Csla;
using Csla.Rules;
using ManagementSystem.BusinessRules;
using ManagementSystem.DataAccessLayer;
using ManagementSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ManagementSystem.BusinessLogicLayer
{
    [Serializable]
    public class FacilitatorBL:BusinessBase<FacilitatorBL>
    {
        // Register the properties to the property system

        public static readonly PropertyInfo<int> FacilitatorIdProperty = RegisterProperty<int>(c => c.FacilitatorId);

        public int FacilitatorId
        {
            get { return GetProperty(FacilitatorIdProperty); }
            set { SetProperty(FacilitatorIdProperty, value); }
        }

        public static readonly PropertyInfo<string> FacilitatorFullNameProperty = RegisterProperty<string>(c => c.FacilitatorFullName);


        [Required]
        public string FacilitatorFullName
        {
            get { return GetProperty(FacilitatorFullNameProperty); }
            set { SetProperty(FacilitatorFullNameProperty, value); }
        }
        public static readonly PropertyInfo<string> FacilitatorEmailProperty = RegisterProperty<string>(c => c.FacilitatorEmail);

        [Required]

        public string FacilitatorEmail
        {
            get { return GetProperty(FacilitatorEmailProperty); }
            set { SetProperty(FacilitatorEmailProperty, value); }
        }
        public static readonly PropertyInfo<string> FacilitatorPhoneNumberProperty = RegisterProperty<string>(c => c.FacilitatorPhoneNumber);
        [Required]

        public string FacilitatorPhoneNumber
        {
            get { return GetProperty(FacilitatorPhoneNumberProperty); }
            set { SetProperty(FacilitatorPhoneNumberProperty, value); }
        }

        public static readonly PropertyInfo<string> QualificationProperty = RegisterProperty<string>(c => c.Qualification);


        [Required]
        public string Qualification
        {
            get { return GetProperty(QualificationProperty); }
            set { SetProperty(QualificationProperty, value); }
        }
        public static readonly PropertyInfo<string> FacilitatorIdNumberProperty = RegisterProperty<string>(c => c.FacilitatorIdNumber);

        [Required]
        public string FacilitatorIdNumber
        {
            get { return GetProperty(FacilitatorIdNumberProperty); }
            set { SetProperty(FacilitatorIdNumberProperty, value); }
        }

        //Mapp Entity objects to Business objects
        public FacilitatorEntity Map()
        {
            return new FacilitatorEntity()
            {
                FacilitatorId = FacilitatorId,
                FacilitatorFullName = FacilitatorFullName,
                FacilitatorEmail = FacilitatorEmail,
                Qualification = Qualification,
                FacilitatorIdNumber = FacilitatorIdNumber,
                FacilitatorPhoneNumber = FacilitatorPhoneNumber,
              
            };



        }

        // Business rules
        //Custom business rules
        protected override void AddBusinessRules()
        {

            BusinessRules.AddRule(new StringBusinessRule { PrimaryProperty = FacilitatorFullNameProperty });
            BusinessRules.AddRule(new IDNumberRule { PrimaryProperty = FacilitatorIdNumberProperty });
            BusinessRules.AddRule(new PhoneNumberRule { PrimaryProperty = FacilitatorPhoneNumberProperty });
            BusinessRules.AddRule(new EmailRule { PrimaryProperty = FacilitatorEmailProperty });
            BusinessRules.AddRule(new QualificationRule { PrimaryProperty = QualificationProperty });
            base.AddBusinessRules();
        }
    
      

        //Add CSLA Objects


        [Fetch]
        protected void Fetch(FacilitatorEntity item)
        {
            LoadProperty(FacilitatorIdProperty, item.FacilitatorId);
            LoadProperty(FacilitatorFullNameProperty, item.FacilitatorFullName);
            LoadProperty(FacilitatorEmailProperty, item.FacilitatorEmail);
            LoadProperty(QualificationProperty, item.Qualification);
            LoadProperty(FacilitatorIdNumberProperty, item.FacilitatorIdNumber);
            LoadProperty(FacilitatorPhoneNumberProperty, item.FacilitatorPhoneNumber);
        }


        [Create]
        protected void Create()
        {
            BusinessRules.CheckRules();
        }
        [Insert]
        protected void Insert([Inject] IFacilitatorDAL dataAccessLayer)
        {

            dataAccessLayer.Insert(Map());
            BusinessRules.CheckRules();
        }
        [Update]
        protected void Update([Inject] IFacilitatorDAL dataAccessLayer)
        {

            dataAccessLayer.Update(Map());
            BusinessRules.CheckRules();
        }
        [DeleteSelf]
        protected void Delete([Inject] IFacilitatorDAL dataAccessLayer)
        {

            dataAccessLayer.Delete(Map());
        }
    }
}

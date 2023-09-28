using Csla;
using Csla.Blazor;
using System;

namespace ManagementSystem.BusinessLogicLayer
{
    [Serializable]
    public class LookupInfo : ReadOnlyBase<LookupInfo>
    {


        public static readonly PropertyInfo<string> IdProperty = RegisterProperty<string>(c => c.Id);
        public string Id
        {
            get { return GetProperty(IdProperty); }
        }


        public static readonly PropertyInfo<string> ValueProperty = RegisterProperty<string>(c => c.Value);
        public string Value
        {
            get { return GetProperty(ValueProperty); }
        }


        [Fetch]
        protected void Fetch(string id, string value)
        {
            LoadProperty(IdProperty, id);
            LoadProperty(ValueProperty, value);
        }

    }
}

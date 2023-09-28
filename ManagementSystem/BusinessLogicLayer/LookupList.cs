using Csla;
using Csla.Rules;
using ManagementSystem.DataAccessLayer;
using System;

namespace ManagementSystem.BusinessLogicLayer
{
    [Serializable]
    public class LookupList : ReadOnlyListBase<LookupList, LookupInfo>
    {



        [Fetch]
        protected async Task Fetch(string tableName, string idField, string description, [Inject] IDataPortal<LookupInfo> lookupInfo, [Inject] ILookupDAL dataAccessLayer)
        {


            IsReadOnly = false;

            //Add our items


            Dictionary<string, string> list =  dataAccessLayer.Fetch(tableName, idField,description);

            foreach (var item in list) 
            {
                Add(await lookupInfo.FetchAsync(item.Key,item.Value));
            }



            IsReadOnly = true;

        }

        internal string Key(string value)
        {
            var lookup = this.FirstOrDefault(x => x.Value == value);
            if (lookup != null)
              return lookup.Id;
            return "0";
        }

        internal string Value(string key)
        {
            var item = this.FirstOrDefault(x => x.Id == key);
            if (item == null)
                return string.Empty;
            return item.Value != null ? item.Value : string.Empty; 
        }
    }
}

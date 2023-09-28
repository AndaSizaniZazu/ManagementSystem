using Csla;
using ManagementSystem.DataAccessLayer;

namespace ManagementSystem.BusinessLogicLayer
{
    [Serializable]
    public class ClassListBL : BusinessBindingListBase<ClassListBL, ClassBL>
    {
        [Fetch]
        protected void FetchList([Inject] IClassDAL dataAccessLayer, [Inject] IDataPortalFactory list)
        {
            var data = dataAccessLayer.FetchList();
            foreach (var item in data)
            {
                var datalist = list.GetPortal<ClassBL>().Fetch(item);
                Add(datalist);
            }

        }
    }
}

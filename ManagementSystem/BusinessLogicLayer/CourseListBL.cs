using Csla;
using ManagementSystem.DataAccessLayer;


namespace ManagementSystem.BusinessLogicLayer
{
    [Serializable]
    public class CourseListBL : BusinessBindingListBase<CourseListBL, CourseBL>
    {
       
        [Fetch]
        protected void FetchList([Inject] ICourseDAL dataAccessLayer, [Inject] IDataPortalFactory list)
        {
            var data = dataAccessLayer.FetchList();
            foreach (var item in data)
            {
                var datalist = list.GetPortal<CourseBL>().Fetch(item);
                Add(datalist);
            }

        }
    }
}

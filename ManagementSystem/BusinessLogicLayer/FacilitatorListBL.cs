using Csla;
using ManagementSystem.DataAccessLayer;


namespace ManagementSystem.BusinessLogicLayer
{
    [Serializable]
    public class FacilitatorListBL : BusinessBindingListBase<FacilitatorListBL, FacilitatorBL>
    {
       
        [Fetch]
        protected void FetchList([Inject] IFacilitatorDAL dataAccessLayer, [Inject] IDataPortalFactory list)
        {
            var data = dataAccessLayer.FetchList();
            foreach (var item in data)
            {
                var datalist = list.GetPortal<FacilitatorBL>().Fetch(item);
                Add(datalist);
            }

        }


    }
}

using ManagementSystem.BusinessLogicLayer;

namespace ManagementSystem.DataAccessLayer
{
    public interface IFacilitatorDAL
    {
        public List<FacilitatorEntity> FetchList();
        public FacilitatorEntity Fetch(int id);
        public FacilitatorEntity Insert(FacilitatorEntity facilitator);
        public void Update(FacilitatorEntity facilitator);
        public void Delete(FacilitatorEntity facilitator);
    }
}

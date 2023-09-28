using ManagementSystem.BusinessLogicLayer;

namespace ManagementSystem.DataAccessLayer
{
    public interface IClassDAL
    {
        public List<ClassEntity> FetchList();
        public ClassEntity Fetch(int id);
        public ClassEntity Insert(ClassEntity item);
        public void Update(ClassEntity item);
        public void Delete(ClassEntity item);
    }
}

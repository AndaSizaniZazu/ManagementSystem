using ManagementSystem.BusinessLogicLayer;

namespace ManagementSystem.DataAccessLayer
{
    public interface IStudentDAL
    {
        public List<StudentEntity> FetchList();
        public StudentEntity Fetch(int id);
        public StudentEntity Insert(StudentEntity item);
        public void Update(StudentEntity item);
        public void Delete(StudentEntity item);
    }
}

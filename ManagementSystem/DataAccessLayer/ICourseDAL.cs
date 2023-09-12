using ManagementSystem.BusinessLogicLayer;

namespace ManagementSystem.DataAccessLayer
{
    public interface ICourseDAL
    {
        public List<CourseEntity> FetchList();
        public CourseEntity Fetch(int id);
        public CourseEntity Insert(CourseEntity course);
        public void Update(CourseEntity course);
        public void Delete(CourseEntity course);
    }
}

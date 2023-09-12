using System;
using System.Linq;
using System.Collections.Generic;
using Csla.Core;
using ManagementSystem.BusinessLogicLayer;
using Csla;
using Csla.DataPortalClient;

namespace ManagementSystem.DataAccessLayer
{
    //[Serializable]
    public class CourseDAL : ICourseDAL
    {
        private readonly WebApiDbContext _dbContext;
        public CourseDAL(WebApiDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }

        public CourseEntity Fetch(int id)
        {
           
           
                try
                {

                    var entity = _dbContext.Courses.FirstOrDefault(item => item.Id == id);
                    if (entity == null)
                        throw new Exception("Course not found");

                    return entity;

                }
                catch (Exception ex)
                {
                    throw new Exception("Error Processing", ex);

                }
               
            
        }

        public List<CourseEntity> FetchList()
        {
           
            
                try
                {

                var entity = _dbContext.Courses;
                        
                    return entity.ToList();
                 

                }
                catch (Exception ex)
                {
                    throw new Exception("Error Processing", ex);

                }

            
        }
        public CourseEntity Insert(CourseEntity course)
        {
            try 
            {
               
                
                    var courseDetails = new CourseEntity
                    {
                        Name = course.Name,
                        Code = course.Code,
                        Credits = course.Credits,
                        Description = course.Description,
                    };
                    _dbContext.Add(courseDetails);
                    _dbContext.SaveChanges();
                    return courseDetails;
                
            }
            catch(Exception ex)
            {
                throw new Exception("Error Processing", ex);
            }
   
               
        }
       
        public void Update(CourseEntity course)
        {

            try 
            {
               
                
                    var entity= Fetch(course.Id);
                    
                    if (course != null)
                    {
                        entity.Name = course.Name;
                        entity.Description = course.Description;
                        entity.Code = course.Code;
                        entity.Credits = course.Credits;

                    }
                    _dbContext.Courses.Update(entity);
                    _dbContext.SaveChanges();

                
            }
            catch(Exception ex)
            {
                throw new Exception("Error Processing", ex);
            }
            

        }
        public void Delete(CourseEntity course)
        {
            try
            {
                
                
                    var entity = Fetch(course.Id);
                    if (course != null)
                    {
                        _dbContext.Courses.Remove(entity);
                        _dbContext.SaveChanges();
                    }
                   

            }
            catch(Exception ex)
            {
                throw new Exception("Error Processing", ex);
            }

        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;
using Csla.Core;
using ManagementSystem.BusinessLogicLayer;
using Csla;
using Csla.DataPortalClient;

namespace ManagementSystem.DataAccessLayer
{
    
    public class StudentDAL : IStudentDAL
    {
        private readonly WebApiDbContext _dbContext;
        public StudentDAL(WebApiDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }

        public StudentEntity Fetch(int id)
        {
           
           
                try
                {

                    var entity = _dbContext.Students.FirstOrDefault(item => item.StudentId == id);
                    if (entity == null)
                        throw new Exception("Student was not found");

                    return entity;

                }
                catch (Exception ex)
                {
                    throw new Exception("Error Processing", ex);

                }
               
            
        }

        public List<StudentEntity> FetchList()
        {
           
            
                try
                {

                    var entity = _dbContext.Students;
                        
                    return entity.ToList();
                 

                }
                catch (Exception ex)
                {
                    throw new Exception("Error Processing", ex);

                }

            
        }
        public StudentEntity Insert(StudentEntity student)
        {
            try 
            {
               

                var studentDetails = new StudentEntity
                {
                    FullName = student.FullName,
                    StudentEmail = student.StudentEmail,
                    StudentPhoneNumber = student.StudentPhoneNumber,
                    EnrollmentDate = student.EnrollmentDate,
                    Id = student.Id
                }; 
                _dbContext.Add(studentDetails);
                _dbContext.SaveChanges();
                return studentDetails;
                
            }
            catch(Exception ex)
            {
                throw new Exception("Error Adding the Class", ex);
            }
   
               
        }
       
        public void Update(StudentEntity student)
        {

            try 
            {
               
                
                    var entity= Fetch(student.StudentId);
                    
                    if (student != null)
                    {
                        entity.FullName = student.FullName;
                        entity.StudentEmail = student.StudentEmail;
                        entity.StudentPhoneNumber = student.StudentPhoneNumber;
                        entity.EnrollmentDate = student.EnrollmentDate;
                        entity.Id = student.Id;

                    }
                    _dbContext.Students.Update(entity);
                    _dbContext.SaveChanges();

                
            }
            catch(Exception ex)
            {
                throw new Exception("There was an Error updating the student", ex);
            }
            

        }
        public void Delete(StudentEntity student)
        {
            try
            {
                
                
                    var entity = Fetch(student.StudentId);
                    if (student != null)
                    {
                        _dbContext.Students.Remove(student);
                        _dbContext.SaveChanges();
                    }
                   

            }
            catch(Exception ex)
            {
                throw new Exception("The was an error deleting a student", ex);
            }

        }
    }
}

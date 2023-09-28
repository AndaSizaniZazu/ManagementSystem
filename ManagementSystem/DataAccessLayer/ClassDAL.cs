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
    public class ClassDAL : IClassDAL
    {
        private readonly WebApiDbContext _dbContext;
        public ClassDAL(WebApiDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }

        public ClassEntity Fetch(int id)
        {
           
           
                try
                {

                    var entity = _dbContext.Classes.FirstOrDefault(item => item.ClassId == id);
                    if (entity == null)
                        throw new Exception("Class not found");

                    return entity;

                }
                catch (Exception ex)
                {
                    throw new Exception("Error Processing", ex);

                }
               
            
        }

        public List<ClassEntity> FetchList()
        {
           
            
                try
                {

                var entity = _dbContext.Classes;
                        
                    return entity.ToList();
                 

                }
                catch (Exception ex)
                {
                    throw new Exception("Error Processing", ex);

                }

            
        }
        public ClassEntity Insert(ClassEntity item)
        {
            try 
            {
               

                var classDetails = new ClassEntity
                {
                    ClassName = item.ClassName,
                    Id = item.Id,
                    FacilitatorId = item.FacilitatorId,
                }; 
                _dbContext.Add(classDetails);
                _dbContext.SaveChanges();
                return classDetails;
                
            }
            catch(Exception ex)
            {
                throw new Exception("Error Adding the Class", ex);
            }
   
               
        }
       
        public void Update(ClassEntity item)
        {

            try 
            {
               
                
                    var entity= Fetch(item.ClassId);
                    
                    if (item != null)
                    {
                        entity.ClassName = item.ClassName;
                        entity.Id = item.Id;
                        entity.FacilitatorId = item.FacilitatorId;

                    }
                    _dbContext.Classes.Update(entity);
                    _dbContext.SaveChanges();

                
            }
            catch(Exception ex)
            {
                throw new Exception("There was an Error updating the code", ex);
            }
            

        }
        public void Delete(ClassEntity item)
        {
            try
            {
                
                
                    var entity = Fetch(item.ClassId);
                    if (item != null)
                    {
                        _dbContext.Classes.Remove(entity);
                        _dbContext.SaveChanges();
                    }
                   

            }
            catch(Exception ex)
            {
                throw new Exception("The was an error deleting the course", ex);
            }

        }
    }
}

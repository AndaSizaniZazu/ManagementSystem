using System;
using System.Linq;
using System.Collections.Generic;
using Csla.Core;
using ManagementSystem.BusinessLogicLayer;
using Csla;
using Csla.DataPortalClient;

namespace ManagementSystem.DataAccessLayer
{
    [Serializable]
    public class FacilitatorDAL : IFacilitatorDAL
    {
        private readonly WebApiDbContext _dbContext;
        public FacilitatorDAL(WebApiDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }

        public FacilitatorEntity Fetch(int id)
        {
           
           
                try
                {

                    var entity = _dbContext.Facilitators.FirstOrDefault(item => item.FacilitatorId == id);
                    if (entity == null)
                        throw new Exception("Facilitator not found");

                    return entity;

                }
                catch (Exception ex)
                {
                    throw new Exception("Error Processing", ex);

                }
               
            
        }

        public List<FacilitatorEntity> FetchList()
        {
           
            
                try
                {

                    var entity = _dbContext.Facilitators;
                        
                        return entity.ToList();
                 

                }
                catch (Exception ex)
                {
                    throw new Exception("Error Processing", ex);

                }

            
        }
        public FacilitatorEntity Insert(FacilitatorEntity facilitator)
        {
            try 
            {
               
                
                    var facilitatorDetails = new FacilitatorEntity
                    {
                        FacilitatorFullName = facilitator.FacilitatorFullName,
                        FacilitatorEmail = facilitator.FacilitatorEmail,
                        FacilitatorIdNumber = facilitator.FacilitatorIdNumber,
                        FacilitatorPhoneNumber = facilitator.FacilitatorPhoneNumber,
                        Qualification = facilitator.Qualification,

                        
                    };
                    _dbContext.Add(facilitatorDetails);
                    _dbContext.SaveChanges();
                    return facilitatorDetails;
                
            }
            catch(Exception ex)
            {
                throw new Exception("Error Adding the Facilitator", ex);
            }
   
               
        }
       
        public void Update(FacilitatorEntity facilitator)
        {

            try 
            {
               
                
                    var entity= Fetch(facilitator.FacilitatorId);
                    
                    if (facilitator != null)
                    {
                        entity.FacilitatorFullName = facilitator.FacilitatorFullName;
                        entity.FacilitatorEmail = facilitator.FacilitatorEmail;
                        entity.FacilitatorIdNumber = facilitator.FacilitatorIdNumber;
                        entity.FacilitatorPhoneNumber = facilitator.FacilitatorPhoneNumber;
                        entity.Qualification = facilitator.Qualification;

                    }
                    _dbContext.Facilitators.Update(entity);
                    _dbContext.SaveChanges();

                
            }
            catch(Exception ex)
            {
                throw new Exception("There was an Error updating the code", ex);
            }
            

        }
        public void Delete(FacilitatorEntity facilitator)
        {
            try
            {
                
                
                    var entity = Fetch(facilitator.FacilitatorId);
                    if (facilitator != null)
                    {
                        _dbContext.Facilitators.Remove(entity);
                        _dbContext.SaveChanges();
                    }
                   

            }
            catch(Exception ex)
            {
                throw new Exception("The was an error deleting the facilitator", ex);
            }

        }
    }
}

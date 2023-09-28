using Csla;
using ManagementSystem.DataAccessLayer;
using ManagementSystem.Models;

namespace ManagementSystem.BusinessLogicLayer
{
    public class GetData 
    { 
        private WebApiDbContext WebApiDbContext { get; set; }
        public GetData(WebApiDbContext context)
        {
            WebApiDbContext = context;
        }
        List<StringBusinessRule> GetFacilitators()
        {
           return WebApiDbContext.Facilitators.Select(x => new StringBusinessRule { Id = x.FacilitatorId, Name = x.FacilitatorFullName }).ToList();
        }
    }
}

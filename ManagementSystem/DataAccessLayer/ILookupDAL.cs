using ManagementSystem.BusinessLogicLayer;

namespace ManagementSystem.DataAccessLayer
{
    public interface ILookupDAL
    {
        
        public  Dictionary<string, string> Fetch(string tableName, string idField, string description);

    }
}

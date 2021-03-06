using Romsoft.GESTIONCLINICA.Common;
using System.Collections.Generic;

namespace Romsoft.GESTIONCLINICA.DataAccess.Core
{
    public interface IRepository<T> where T : class
    {
        int Add(T entity);
        int Delete(T entity);
        IList<T> GetAll(string whereFilters);
        IList<T> GetAllPaging(PaginationParameter paginationParameters);
        IList<T> GetAllFilters(T entity);
        
        int Update(T entity);
        IList<T> GetAllActives();
    }
}

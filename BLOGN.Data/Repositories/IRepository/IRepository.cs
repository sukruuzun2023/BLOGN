using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLOGN.Data.Repositories.IRepository
{
    public interface IRepository<T> where T : class // Her yer için kullanılabilir yaptık
    {
        Task<ICollection<T>> GetAll(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null);
        Task<T> Get(int id);
        Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string İncludeproperties = null);
        Task<bool> Add(T entity);
        T Update(T entity); // Update Async bulunmuyor normalde olmuyor
        bool Delete(int id);// bu kısmı asekron yapmadık örneğin aradaki farkı anlarız

    }
}
// yukarıda baslarına Task eklersek bunları asekron yapmış oluruz.
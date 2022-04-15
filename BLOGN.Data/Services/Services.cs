using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLOGN.Data.Repositories.IRepository;
using BLOGN.Data.Services.IService;

namespace BLOGN.Data.Services
{
    public class Services<T> : IService<T> where T : class // ilk kodlarımızı yazdıktan sonra implamate ettik
    {
        public readonly IUnitOfWork _unitOfWork;            // 2. bölüm kodlarımız
        private readonly IRepository<T> _repository;
        public Services(IUnitOfWork unitOfWork, IRepository<T> repository)   //ctor diyip tab yapıp olusturduk
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        // bu asamadan sonra program cs ıcersıne scoped kodlarımızı olusturcaz ve 
        // Daha Sonra ICategoryService ve Categoryservice oluşturuyoruz.
        public async Task<bool> Add(T entity) // async yaparak baslıyoruz
        {
            await _repository.Add(entity);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public bool Delete(int id) // await işlemine gerek yok
        {
            _repository.Delete(id);
            _unitOfWork.Save();
            return true;
        }

        public async Task<T> Get(int id)
        {
            return await _repository.Get(id);
        }

        public async Task<ICollection<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            return await _repository.GetAll(filter, orderBy, includeProperties);
        }

        public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string İncludeproperties = null)
        {
            return await _repository.GetFirstOrDefault(filter, İncludeproperties);
        }

        public T Update(T entity)
        {
            var newEntity = _repository.Update(entity);
            _unitOfWork.Save();
            return newEntity;
        }
    }
}

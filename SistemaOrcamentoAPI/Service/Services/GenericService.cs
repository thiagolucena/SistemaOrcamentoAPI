using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.IRepository;
using Domain.Interfaces.IServices;

namespace Services.Services
{
    public class GenericService<T> : IGenericService<T>, IDisposable where T : class

    {
        protected readonly IGenericRepository<T> _repository;

        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }
        public async Task Add(T obj)
        {
            await _repository.Add(obj);
        }
        public async Task<T> GetEntityById(int id)
        {
            return await _repository.GetEntityById(id);
        }
        public async Task<List<T>> List()
        {
            return await _repository.List();
        }
        public async Task Update(T obj)
        {
            await _repository.Update(obj);
        }
        public async Task Delete(T obj)
        {
            await _repository.Delete(obj);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }

}

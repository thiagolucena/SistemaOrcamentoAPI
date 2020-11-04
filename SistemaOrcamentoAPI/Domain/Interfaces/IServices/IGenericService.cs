using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IServices
{
    public interface IGenericService<T> where T : class
    {
        Task Add(T obj);
        Task<T> GetEntityById(int id);
        Task<List<T>> List();
        Task Update(T obj);
        Task Delete(T obj);
        void Dispose();

    }
}

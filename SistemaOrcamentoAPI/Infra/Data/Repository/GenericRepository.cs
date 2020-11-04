using Data.Configuration;
using Domain.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class GenericRepository<T> : IGenericRepository<T>, IDisposable where T : class
    {
        protected readonly ContextBase _contextBase;

        public GenericRepository(ContextBase contextBase)
        {
            _contextBase = contextBase;
        }

        public async Task Add(T Objeto)
        {
            await _contextBase.Set<T>().AddAsync(Objeto);
            await _contextBase.SaveChangesAsync();
        }

        public async Task Delete(T Objeto)
        {
            _contextBase.Set<T>().Remove(Objeto);
            await _contextBase.SaveChangesAsync();
        }

        public async Task<T> GetEntityById(int Id)
        {
            return await _contextBase.Set<T>().FindAsync(Id);
        }

        public async Task<List<T>> List()
        {
            return await _contextBase.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task Update(T Objeto)
        {
            _contextBase.Set<T>().Update(Objeto);
            await _contextBase.SaveChangesAsync();
        }

        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
        #endregion
    }
}

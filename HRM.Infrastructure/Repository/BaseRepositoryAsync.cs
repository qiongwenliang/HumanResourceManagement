using HRM.ApplicationCore.Contract.Repository;
using HRM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Infrastructure.Repository
{
    public class BaseRepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        //so here we import all the entities from HRMDbContext, so that it's easier to implement the
        //abstract functions in IRepositoryAsync
        private readonly HRMDbContext db;
        public BaseRepositoryAsync(HRMDbContext _context) 
            //here we are doing dependency injection, above is injecting an object of HRMDbContext
            //and we are able to do this injection due to we did it in program.cs
            //it will be automatically handled by program.cs 
            //whenever the baseRepositoryAsync is called, the HRMDbContext object(_context) will be 
            //automatically passed.
        {
            db = _context;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var entity = await db.Set<T>().FindAsync(id);
            if (entity != null)
            {
                db.Set<T>().Remove(entity);
                return await db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await db.Set<T>().ToListAsync();
            //ToListAsync is in the EntityFrameworkCore
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await db.Set<T>().FindAsync(id);
            //the Set<T> here is going to look at what particular T you have put into in tye DbSet<T> in HRMDbContext.cs
            //async and await currently only need to use it in repository and service
        }

        public async Task<int> InsertAsync(T entity)
        {
            db.Set<T>().Add(entity);
            return await db.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return await db.SaveChangesAsync();
        }
    }
}

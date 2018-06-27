using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UeharaApi_91Tel.EntityFramework;
using UeharaApi_91Tel.Models;

namespace UeharaApi_91Tel.Repositories
{
    public class LogResponseRepository:ILogResponseRepository
    {
        internal LogResponseDbContext context;
        internal DbSet<LogResponse> dbSet;

        public LogResponseRepository(LogResponseDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<LogResponse>();
        }

        public virtual async Task<LogResponse> GetById(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual void Insert(LogResponse entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public async Task<List<LogResponse>> GetAllWithPagination(int pageSize)
        {
            return await dbSet
                .Take(pageSize)
                .ToListAsync();
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using UeharaApi_91Tel.Models;

namespace UeharaApi_91Tel.Repositories
{
    public interface ILogResponseRepository
    {
        Task<LogResponse> GetById(object id);
        void Insert(LogResponse entity);
        Task<List<LogResponse>> GetAllWithPagination(int pageSize);
    }
}
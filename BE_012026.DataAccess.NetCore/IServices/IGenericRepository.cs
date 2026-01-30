using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_012026.DataAccess.NetCore.IServices
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetList(object param = null);
        Task<int> Insert(T t);
        Task<int> Update(T t);
        Task<int> Delete(T t);
    }
}

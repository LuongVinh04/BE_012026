using BE_012026.DataAccess.NetCore.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_012026.DataAccess.NetCore.IServices
{
    public interface IProductGenericRepository : IGenericRepository<Product>
    {
        public Task<int> Delete(Product t)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetList(object param = null)
        {
            throw new NotImplementedException();
        }

        public Task<int> Insert(Product t)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Product t)
        {
            throw new NotImplementedException();
        }
    }
}

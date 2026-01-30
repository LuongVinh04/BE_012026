using BE_012026.DataAccess.NetCore.DataObject;
using BE_012026.DataAccess.NetCore.Dbcontext;
using BE_012026.DataAccess.NetCore.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_012026.DataAccess.NetCore.Services
{
    public class ProductGenericRepository : GenericRepository<Product>, IProductGenericRepository
    {
        public ProductGenericRepository(BE_012026Dbcontext dbContext) : base(dbContext)
        {
        }
    }
}

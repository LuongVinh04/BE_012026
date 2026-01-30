using BE_012026.DataAccess.NetCore.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_012026.DataAccess.NetCore.Services
{
    public class CategoryGenericRepository : GenericRepository<DataObject.Category>, ICategoryGenericRepository
    {
        public CategoryGenericRepository(Dbcontext.BE_012026Dbcontext dbContext) : base(dbContext)
        {
        }
    }
}

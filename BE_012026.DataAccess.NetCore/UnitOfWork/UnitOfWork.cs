using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_012026.DataAccess.NetCore.Dbcontext;
using BE_012026.DataAccess.NetCore.IServices;

namespace BE_012026.DataAccess.NetCore.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IProductGenericRepository ProductGenericRepository {get; set; }

        public ICategoryGenericRepository CategoryRepository { set; get; }
        public BE_012026Dbcontext _dbContext { get; set; }
        
        public UnitOfWork(ICategoryGenericRepository categoryGenericRepository, IProductGenericRepository productGenericRepository, BE_012026Dbcontext dbContext)
        {
            CategoryRepository = categoryGenericRepository;
            ProductGenericRepository = productGenericRepository;
            _dbContext = dbContext;
        }

        public void SaveChange()
        {
            _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}

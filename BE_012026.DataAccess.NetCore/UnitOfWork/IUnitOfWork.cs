using BE_012026.DataAccess.NetCore.DataAccessLayer;
using BE_012026.DataAccess.NetCore.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_012026.DataAccess.NetCore.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductGenericRepository ProductGenericRepository { get; }
        ICategoryGenericRepository CategoryRepository { get; }
        void SaveChange();
        void Dispose();
    }
}

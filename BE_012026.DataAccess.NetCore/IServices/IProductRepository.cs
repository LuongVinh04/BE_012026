using BE_012026.DataAccess.NetCore.DataObject;
using BE_012026.DataAccess.NetCore.RequestData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_012026.DataAccess.NetCore.DataAccessLayer
{
    public interface IProductRepository
    {
        Task<List<ProductDTO>> Product_GetList(Product_GetListRequestData requestData);

        Task<List<Product>> Product_GetList_EfCore(Product_GetListRequestData requestData);

        Task<ReturnData> Product_Insert(Product_InsertRequestData requestData);
        Task<ReturnData> Product_Update(Product_UpdateRequestData requestData);
        Task<ReturnData> Product_Delete(Product_DeleteRequestData requestData);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_012026.DataAccess.NetCore.RequestData
{
    public class Product_GetListRequestData
    {
        public int ProductId { get; set; }
    }
    public class Product_InsertRequestData
    {
        public string? ProductName { get; set; }
        public string? ProductImage { get; set; }
        public int CategoryId { get; set; }
     
    }
    public class Product_UpdateRequestData
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductImage { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
    public class Product_DeleteRequestData 
    {
        public int ProductId { get; set; }
    }
}

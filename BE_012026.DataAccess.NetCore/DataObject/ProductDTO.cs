using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_012026.DataAccess.NetCore.DataObject
{
    public class ProductDTO
    {
        public int ProductId { get; set; }  
        public string? ProductName { get; set; }
        public string? ProductImage { get; set; }
       
    }
}

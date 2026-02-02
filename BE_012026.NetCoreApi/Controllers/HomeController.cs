using BE_012026.DataAccess.NetCore.DataAccessLayer;
using BE_012026.DataAccess.NetCore.DataObject;
using BE_012026.DataAccess.NetCore.IServices;
using BE_012026.DataAccess.NetCore.RequestData;
using BE_012026.DataAccess.NetCore.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BE_012026.NetCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        //private readonly IProductRepository _productServices;
        //private readonly IProductGenericRepository _productGenericServices;
        //public HomeController(IProductRepository productServices, IProductGenericRepository productGenericServices)
        //{
        //    _productServices = productServices;
        //    _productGenericServices = productGenericServices;
        //}
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost("Product_GetList")]
<<<<<<< HEAD
=======
        // Filter -> Claims
        // B1: Filter (Attributes)
        // -> Implement Interfcae IAuthorizationFilter
        // -> doc identity trong ham overide cua IAuthorizationFilter
        // -> Doc Claims trong identity
        [BE_012026.NetCoreApi.Filter.BE_012026_Authorize("Product_GetList", "ISVIEW")]
>>>>>>> 2fff400 (New)
        public async Task<IActionResult> Product_GetList(Product_GetListRequestData requestData)
        {
            try
            {
                var list = await _unitOfWork.ProductGenericRepository.GetList(requestData);
                return Ok(list);
            }
            catch (Exception ex)
            {
                throw;

            }
        }
        [HttpPost("Product_Insert")]
        public async Task<IActionResult> Product_Insert(Product_InsertRequestData  requestData)
        {
            try
            {

                //check du lieu dau vao
                if(string.IsNullOrWhiteSpace(requestData.ProductName))
                {
                    return BadRequest("Ten san pham khong duoc de trong");
                }
                //kien tra do dai ky tu
                if(requestData.ProductName.Length > 250)
                {
                    return BadRequest("Ten san pham khong duoc dai qua 250 ky tu");
                }
                //check xss
                if(!BE_012026.CommonNetcore.Sercutity.CheckXSSInput(requestData.ProductName))
                {
                    return BadRequest("Ten san pham khong hop le");
                }

                var rs_product = await _unitOfWork.ProductGenericRepository.Insert
                    (new Product
                    {
                        ProductName = requestData.ProductName,
                        ProductImage = requestData.ProductImage,
                        CategoryId = requestData.CategoryId
                    });

                var rs = await _unitOfWork.CategoryRepository.Insert(
                    new Category
                    {
                        CategoryName = "Category 123"
                    }
                    );
                _unitOfWork.SaveChange();

                //var list = await _unitOfWork.ProductGenericRepository.Insert(requestData);
                //return Ok(list);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;

            }
        }
        [HttpPost("Product_Update")]
        public async Task<IActionResult> Product_Update(Product_UpdateRequestData requestData)
        {
            try
            {
                //var list = await _unitOfWork.ProductGenericRepository.Product_Update(requestData);
                //return Ok(list);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost("Product_Delete")]
        public async Task<IActionResult> Product_Delete(Product_DeleteRequestData requestData)
        {
            try
            {
                //var list = await _productServices.Product_Delete(requestData);
                //return Ok(list);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

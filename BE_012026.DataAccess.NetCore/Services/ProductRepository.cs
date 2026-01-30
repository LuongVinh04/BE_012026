using BE_012026.DataAccess.NetCore.DataAccessLayer;
using BE_012026.DataAccess.NetCore.DataObject;
using BE_012026.DataAccess.NetCore.Dbcontext;
using BE_012026.DataAccess.NetCore.Enum;
using BE_012026.DataAccess.NetCore.RequestData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_012026.DataAccess.NetCore.Services
{

    public class ProductRepository : IProductRepository
    {
        private readonly BE_012026Dbcontext _dbContext;
        public ProductRepository(BE_012026Dbcontext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<ProductDTO>> Product_GetList(Product_GetListRequestData requestData)
        {
            var list = new List<ProductDTO>();
            try
            {
                await Task.Yield();
                for (int i = 0; i < 10; i++)
                {

                    {
                        var product = new ProductDTO();
                        product.ProductId = i;
                        product.ProductName = "Product " + i;
                        //product.CategoryName = "Category " + i;
                        list.Add(product);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public async Task<List<Product>> Product_GetList_EfCore(Product_GetListRequestData requestData)
        {
            //var list = new List<Product>();
            try
            {
                 return await _dbContext.product.ToListAsync();

            }
            catch (Exception ex)
            {
                throw;
            }
            //return list;
        }

        public async Task<ReturnData> Product_Insert(Product_InsertRequestData requestData)
        {
            var returnData = new ReturnData();
            try
            {
                //b1: ktra dlieu dau vao
                if(string.IsNullOrEmpty( requestData.ProductName))
                {
                    returnData.ResponseCode = (int)ProductManager_Status.PRODUCT_NAME_NOT_VALID;
                    returnData.ResponseMessage = "Product name is not valid";
                    return returnData;
                }

                //b2: Kiem tra trung du lieu
                var isDuplicate = _dbContext.product.Any(p => p.ProductName == requestData.ProductName);
                //var isDuplicate = false;
                //var list = _dbContext.product.ToList();
                //if (list.Count > 0)
                //{
                //    foreach (var item in list)
                //    {
                //        if (item.ProductName ==requestData.ProductName)
                //        {
                //            isDuplicate = true;
                //            break;
                //        }
                //    }
                //}

                //kiem tra du lieu trung
                if (isDuplicate)
                {
                    returnData.ResponseCode = (int)ProductManager_Status.PRODUCT_NAME_NOT_VALID;
                    returnData.ResponseMessage = "Product name is duplicate";
                    return returnData;
                }

                //Kiem tra do dai
                if(requestData.ProductName.Length > 250)
                {
                    returnData.ResponseCode = (int)ProductManager_Status.PRODUCT_NAME_NOT_VALID;
                    returnData.ResponseMessage = "Product name is too long";
                    return returnData;
                }

                //kiem tra xss
                if (!CommonNetcore.Sercutity.CheckXSSInput(requestData.ProductName))
                {
                    returnData.ResponseCode = (int)ProductManager_Status.PRODUCT_NAME_NOT_VALID;
                    returnData.ResponseMessage = "Product name is not valid";
                    return returnData;
                }
                //b3: insert du lieu
                var product = new Product();
                product.ProductName = requestData.ProductName;
                product.ProductImage = requestData.ProductImage;
                product.CategoryId = requestData.CategoryId;
                //product.CategoryName = requestData.CategoryName;
                _dbContext.product.Add(product);
                _dbContext.SaveChanges();

                returnData.ResponseCode = (int)ProductManager_Status.PRODUCT_INSERT_SUCCESS;
                returnData.ResponseMessage = "Product insert success";
                return returnData;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<ReturnData> Product_Update(Product_UpdateRequestData requestData)
        {
            var returnData = new ReturnData();
            try
            {
                //b1: ktra dlieu dau vao
                if (string.IsNullOrWhiteSpace(requestData.ProductName))
                {
                    returnData.ResponseCode = (int)ProductManager_Status.PRODUCT_NAME_NOT_VALID;
                    returnData.ResponseMessage = "Product name is not valid";
                    return returnData;
                }

                if (requestData.ProductName.Length > 250)
                {
                    returnData.ResponseCode = (int)ProductManager_Status.PRODUCT_NAME_NOT_VALID;
                    returnData.ResponseMessage = "Product name is too long";
                    return returnData;
                }

                //b2: kiem tra product co ton tai khong
                var productExist = await _dbContext.product.FindAsync(requestData.ProductId);
                if (productExist == null)
                {
                    returnData.ResponseCode = (int)ProductManager_Status.PRODUCT_NOT_FOUND;
                    returnData.ResponseMessage = "Product not found";
                    return returnData;
                }
                //b3: kiem tra trung ten
                var isDuplicate = _dbContext.product.Any(p => p.ProductName == requestData.ProductName && p.ProductId != requestData.ProductId);
                if (isDuplicate)
                {
                    returnData.ResponseCode = (int)ProductManager_Status.PRODUCT_NAME_NOT_VALID;
                    returnData.ResponseMessage  = "Product name is duplicate";
                    return returnData;
                }

                //b4: update du lieu
                productExist.ProductName = requestData.ProductName;
                productExist.ProductImage = requestData.ProductImage;
                productExist.CategoryId = requestData.CategoryId;
                //productExist.CategoryName = requestData.CategoryName;

                await _dbContext.SaveChangesAsync();
                returnData.ResponseCode = (int)ProductManager_Status.PRODUCT_UPDATE_SUCCESS;
                returnData.ResponseMessage = "Product update success";
                return returnData;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<ReturnData> Product_Delete(Product_DeleteRequestData requestData)
        {
            var returnData = new ReturnData();
            try
            {
                var productExist = await _dbContext.product.FindAsync(requestData.ProductId);
                if (productExist == null)
                {
                    returnData.ResponseCode = 0;
                    returnData.ResponseMessage = "Product not found";
                    return returnData;
                }
                _dbContext.product.Remove(productExist);
                await _dbContext.SaveChangesAsync();
                returnData.ResponseCode = 3;
                returnData.ResponseMessage = "Product delete success";
                return returnData;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

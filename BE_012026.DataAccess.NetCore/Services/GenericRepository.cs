using BE_012026.DataAccess.NetCore.Dbcontext;
using BE_012026.DataAccess.NetCore.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_012026.DataAccess.NetCore.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly BE_012026Dbcontext _dbContext;
        public GenericRepository(BE_012026Dbcontext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Delete(T t)
        {
            _dbContext.Set<T>().Remove(t);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetList(object param = null)
        {
            return _dbContext.Set<T>().ToList();
        }

        public async Task<int> Insert(T t)
        {

            try
            {
                //check du lieu dau vao 
                if (t == null)
                {
                    throw new Exception("Dữ liệu đầu vào không hợp lệ");
                }

                //check trung du lieu
                
                    //kiem tra do dai

                    _dbContext.Set<T>().Add(t);
                //return _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> Update(T t)
        {
            try
            {
                _dbContext.Set<T>().Update(t);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

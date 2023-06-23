using Microsoft.EntityFrameworkCore;
using SoatVe.Data;
using SoatVe.Models;
using System;

namespace SoatVe.Repository
{
    public class CTRepository : ICTRepository
    {

        private readonly SoatVeDbContext _dbContext;
        public CTRepository(SoatVeDbContext dbContext ) 
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ChuongTrinh>> GetChuongTrinhs()
        {
            return await _dbContext.ChuongTrinhs.ToListAsync();
        }


        public async Task<ChuongTrinh> Create(ChuongTrinh ctrinh)
        {
            await _dbContext.ChuongTrinhs.AddAsync(ctrinh);
            await _dbContext.SaveChangesAsync();
            return ctrinh;

        }

        public async Task<ChuongTrinh> Delete(ChuongTrinh ctrinh)
        {
             _dbContext.ChuongTrinhs.Remove(ctrinh);
            await _dbContext.SaveChangesAsync();
            return ctrinh;
        }

       

       

        public async Task<ChuongTrinh> Update( ChuongTrinh ctrinh)
        {
             _dbContext.ChuongTrinhs.Update(ctrinh);
            await _dbContext.SaveChangesAsync();
            return ctrinh;
        }

        public async Task<ChuongTrinh> GetById(Guid id)
        {
            return await _dbContext.ChuongTrinhs.FindAsync(id);
        }
    }
}

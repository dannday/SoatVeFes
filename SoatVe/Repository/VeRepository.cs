using SoatVe.Data;
using SoatVe.Models.DTO;
using SoatVe.Models;
using Microsoft.EntityFrameworkCore;
using SoatVe.Interface;
using Microsoft.AspNetCore.Mvc;

namespace SoatVe.Repository
{
    public class VeRepository : IVeRepository
    {

        private readonly SoatVeDbContext _dbContext;
        public VeRepository(SoatVeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<VeDto>> GetVes()
        {
            return await _dbContext.Ves.Select(x => new VeDto()
            {
                //Id = x.Id,
                //NgayDien = x.NgayDien,
                //QRCode = x.QRCode,
            }).ToListAsync();
        }

        //public async Task<IEnumerable<Ve> GetAll()
        //{
        //    return await _dbContext.Ves.Select(x => new Ve()
        //    {
        //        //Id = x.Id,
        //        //NgayDien= x.NgayDien,
        //        //QRCode= x.QRCode,
        //    }).ToListAsync();
        //}

       

        public async Task<Ve> Create(Ve ve)
        {
            await _dbContext.Ves.AddAsync(ve);
            await _dbContext.SaveChangesAsync();
            return ve;

        }

        public async Task<Ve> Delete(Ve ve)
        {
            _dbContext.Ves.Remove(ve);
            await _dbContext.SaveChangesAsync();
            return ve;
        }





        public async Task<Ve> Update(Ve ve)
        {
            _dbContext.Ves.Update(ve);
            await _dbContext.SaveChangesAsync();
            return ve;
        }

        public async Task<Ve> GetById(int id)
        {
            return await _dbContext.Ves.FindAsync(id);
        }

        
    }
}


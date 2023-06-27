using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoatVe.Data;
using SoatVe.Interface;
using SoatVe.Models;
using SoatVe.Models.DTO;
using System;

namespace SoatVe.Repository
{
    public class CTRepository : ICTRepository
    {

        private readonly SoatVeDbContext _dbContext;
        public CTRepository(SoatVeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CTDto>> GetChuongTrinhs()
        {
            return await _dbContext.ChuongTrinhs.Select(x => new CTDto()
            {
                Id = x.Id,
                Ten = x.Ten,
                DiaDiem = x.DiaDiem,
                type_progame = x.type_progame,
                

                }).ToListAsync();
        }


        //public async Task<IEnumerable<CTDto>> GetChuongTrinhs()
        //{
        //    return await _dbContext.ChuongTrinhs.ToListAsync();
        //}



        //public async Task<ChuongTrinh> GetTieu_Diem(int type)
        //{
        //    return await _dbContext.ChuongTrinhs.FindAsync(1);
        //}

        //public async Task<ChuongTrinh> AddChuongTrinh(AddChuongTrinhRequest addChuongTrinhRequest, ChuongTrinh ctrinh)
        //{

        //    //var ctrinh = new ChuongTrinh()
        //    //{
        //    //    Id = int.Newint(),
        //    //    Ten = addChuongTrinhRequest.Ten,
        //    //    DiaDiem = addChuongTrinhRequest.DiaDiem,
        //    //    HinhAnh = addChuongTrinhRequest.HinhAnh,
        //    //    MoTa = addChuongTrinhRequest.MoTa,
        //    //};

        //    await _dbContext.ChuongTrinhs.AddAsync(ctrinh);
        //    await _dbContext.SaveChangesAsync();
        //    return ctrinh;

        //}


        public async Task<IEnumerable<ChuongTrinh>> Search (string? ten, string? ddiem)
        {
            IQueryable<ChuongTrinh> query = _dbContext.ChuongTrinhs;

            if (!string.IsNullOrEmpty(ten))
            {
                query = query.Where(x => x.Ten == ten);
            }

            if (!string.IsNullOrEmpty(ddiem))
            {
                query = query.Where(x => x.DiaDiem == ddiem);
            }


            return await query.ToListAsync();
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



       



        public async Task<ChuongTrinh> Update(ChuongTrinh ctrinh)
        {
            _dbContext.ChuongTrinhs.Update(ctrinh);
            await _dbContext.SaveChangesAsync();
            return ctrinh;
        }

        public async Task<ChuongTrinh> GetById(int id)
        {
            return await _dbContext.ChuongTrinhs.FindAsync(id);
        }


        


    }
}

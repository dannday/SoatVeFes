using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoatVe.Data;
using SoatVe.Services;
using SoatVe.Models;
using SoatVe.ViewModel;
using System;
using Microsoft.IdentityModel.Tokens;

namespace SoatVe.Services
{
    public class CTRepository : ICTRepository
    {

        private readonly SoatVeDbContext _dbContext;
        public CTRepository(SoatVeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CTVM>> GetChuongTrinhs()
        {
            return await _dbContext.ChuongTrinhs.Select(x => new CTVM()
            {
                Ten = x.Ten,
                HinhAnh = x.HinhAnh,
                TenDD = x.DiaDiem.Ten,

            }).ToListAsync();
        }

      

      

      

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


        public async Task<IEnumerable<ChuongTrinh>> Search (string? ten, string? ddiem, int? type_progame)
        {
            IQueryable<ChuongTrinh> query = _dbContext.ChuongTrinhs;

            if (!string.IsNullOrEmpty(ten))
            {
                query = query.Where(x => x.Ten == ten);
            }


            if (type_progame != null)
            {
                query = query.Where(x => x.type_progame == type_progame);
            }

            if (!string.IsNullOrEmpty(ddiem))
            {
                query = query.Where(x => x.DiaDiem.Ten == ddiem);
            }


            return await query.ToListAsync();
        }



        public async Task<ChuongTrinh> Create(ChuongTrinh ctrinh)
        {
            await _dbContext.ChuongTrinhs.AddAsync(ctrinh);
            await _dbContext.SaveChangesAsync();
            return ctrinh;

        }


        //public async Task<Models.DTO.AddChuongTrinhRequest> CreateCT(Models.DTO.AddChuongTrinhRequest addChuongTrinhRequest)
        //{
        //    await _dbContext.ChuongTrinhs.AddAsync(addChuongTrinhRequest);
        //    await _dbContext.SaveChangesAsync();
        //    return addChuongTrinhRequest;
        //}

        //public async Task<AddChuongTrinhRequest> CreateCT((AddChuongTrinhRequest ctrinh)
        //{
        //    await _dbContext.ChuongTrinhs.AddAsync(ctrinh);
        //    await _dbContext.SaveChangesAsync();
        //    return ctrinh;

        //}

        //public async Task<AddChuongTrinhRequest> CreateCT(AddChuongTrinhRequest addctrinh)
        //{
        //    await _dbContext.ChuongTrinhs.AddAsync(addctrinh);
        //    await _dbContext.SaveChangesAsync();
        //    return addctrinh;

        //}


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

        public CTVM_Details Details(int id)
        {
            var ctrinh =_dbContext.ChuongTrinhs.FirstOrDefault(x => x.Id == id);
            
            if(ctrinh != null)
            {
                return new CTVM_Details
                {
                    Ten = ctrinh.Ten,
                    GiaVe = ctrinh.Ve.GiaVe,
                };
            }

            return null;
        }



       

        public async Task<ChuongTrinh> GetById(int id)
        {

            return await _dbContext.ChuongTrinhs.FindAsync(id);
        }

      
    }
}

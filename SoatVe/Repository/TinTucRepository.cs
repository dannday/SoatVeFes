﻿using SoatVe.Data;
using SoatVe.Interface;
using SoatVe.Models.DTO;
using SoatVe.Models;
using Microsoft.EntityFrameworkCore;

namespace SoatVe.Repository
{
    public class TinTucRepository : ITinTucRepository
    {

        private readonly SoatVeDbContext _dbContext;
        public TinTucRepository(SoatVeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CTDto>> GetTinTucs()
        {
            return await _dbContext.TinTucs.Select(x => new CTDto()
            {
                //Id = x.Id,
                //Ten = x.Ten,
                //DiaDiem = x.DiaDiem,
                //type_progame = x.type_progame,
            }).ToListAsync();
        }




        public async Task<IEnumerable<TinTuc>> Search(string ten)
        {
            IQueryable<TinTuc> query = _dbContext.TinTucs;

            if (!string.IsNullOrEmpty(ten))
            {
                query = query.Where(x => x.Ten == ten);
            }




            return await query.ToListAsync();
        }



        //public async Task<TinTuc> GetTieu_Diem(int type)
        //{
        //    return await _dbContext.TinTucs.FindAsync(1);
        //}

        //public async Task<TinTuc> AddTinTuc(AddTinTucRequest addTinTucRequest, TinTuc tintuc)
        //{

        //    //var tintuc = new TinTuc()
        //    //{
        //    //    Id = int.Newint(),
        //    //    Ten = addTinTucRequest.Ten,
        //    //    DiaDiem = addTinTucRequest.DiaDiem,
        //    //    HinhAnh = addTinTucRequest.HinhAnh,
        //    //    MoTa = addTinTucRequest.MoTa,
        //    //};

        //    await _dbContext.TinTucs.AddAsync(tintuc);
        //    await _dbContext.SaveChangesAsync();
        //    return tintuc;

        //}

        public async Task<TinTuc> Create(TinTuc tintuc)
        {
            await _dbContext.TinTucs.AddAsync(tintuc);
            await _dbContext.SaveChangesAsync();
            return tintuc;

        }

        public async Task<TinTuc> Delete(TinTuc tintuc)
        {
            _dbContext.TinTucs.Remove(tintuc);
            await _dbContext.SaveChangesAsync();
            return tintuc;
        }





        public async Task<TinTuc> Update(TinTuc tintuc)
        {
            _dbContext.TinTucs.Update(tintuc);
            await _dbContext.SaveChangesAsync();
            return tintuc;
        }

        public async Task<TinTuc> GetById(int id)
        {
            return await _dbContext.TinTucs.FindAsync(id);
        }





    }
}

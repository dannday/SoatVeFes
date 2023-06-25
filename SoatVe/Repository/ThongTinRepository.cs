using SoatVe.Data;
using SoatVe.Interface;
using SoatVe.Models.DTO;
using SoatVe.Models;
using Microsoft.EntityFrameworkCore;

namespace SoatVe.Repository
{
    public class ThongTinRepository : IThongTinRepository
    {

        private readonly SoatVeDbContext _dbContext;
        public ThongTinRepository(SoatVeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CTDto>> GetThongTins()
        {
            return await _dbContext.ThongTins.Select(x => new CTDto()
            {
                //Id = x.Id,
                //Ten = x.Ten,
                //DiaDiem = x.DiaDiem,
                //type_progame = x.type_progame,
            }).ToListAsync();
        }



        //public async Task<ThongTin> GetTieu_Diem(int type)
        //{
        //    return await _dbContext.ThongTins.FindAsync(1);
        //}

        //public async Task<ThongTin> AddThongTin(AddThongTinRequest addThongTinRequest, ThongTin menu)
        //{

        //    //var menu = new ThongTin()
        //    //{
        //    //    Id = int.Newint(),
        //    //    Ten = addThongTinRequest.Ten,
        //    //    DiaDiem = addThongTinRequest.DiaDiem,
        //    //    HinhAnh = addThongTinRequest.HinhAnh,
        //    //    MoTa = addThongTinRequest.MoTa,
        //    //};

        //    await _dbContext.ThongTins.AddAsync(menu);
        //    await _dbContext.SaveChangesAsync();
        //    return menu;

        //}

        public async Task<ThongTin> Create(ThongTin menu)
        {
            await _dbContext.ThongTins.AddAsync(menu);
            await _dbContext.SaveChangesAsync();
            return menu;

        }

        public async Task<ThongTin> Delete(ThongTin menu)
        {
            _dbContext.ThongTins.Remove(menu);
            await _dbContext.SaveChangesAsync();
            return menu;
        }





        public async Task<ThongTin> Update(ThongTin menu)
        {
            _dbContext.ThongTins.Update(menu);
            await _dbContext.SaveChangesAsync();
            return menu;
        }

        public async Task<ThongTin> GetById(int id)
        {
            return await _dbContext.ThongTins.FindAsync(id);
        }





    }
}

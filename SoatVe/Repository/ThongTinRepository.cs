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



        public async Task<IEnumerable<ThongTin>> Search(string ten)
        {
            IQueryable<ThongTin> query = _dbContext.ThongTins;

            if (!string.IsNullOrEmpty(ten))
            {
                query = query.Where(x => x.Ten == ten);
            }




            return await query.ToListAsync();
        }


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

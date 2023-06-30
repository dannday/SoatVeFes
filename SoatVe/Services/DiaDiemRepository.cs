using SoatVe.Data;
using SoatVe.Services;
using SoatVe.Models;
using Microsoft.EntityFrameworkCore;
using SoatVe.ViewModel;

namespace SoatVe.Services
{
    public class DiaDiemRepository : IDiaDiemRepository
    {

        private readonly SoatVeDbContext _dbContext;
        public DiaDiemRepository(SoatVeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<DiaDiemVM>> GetDiaDiems()
        {
            return await _dbContext.DiaDiems.Select(x => new DiaDiemVM()
            {
                Ten = x.Ten,
                HinhAnh= x.HinhAnh,
            }).ToListAsync();
        }




        public async Task<IEnumerable<DiaDiem>> Search(string ten)
        {
            IQueryable<DiaDiem> query = _dbContext.DiaDiems;

            if (!string.IsNullOrEmpty(ten))
            {
                query = query.Where(x => x.Ten == ten);
            }

            


            return await query.ToListAsync();
        }



        public async Task<DiaDiem> Create(DiaDiem ddiem)
        {
            await _dbContext.DiaDiems.AddAsync(ddiem);
            await _dbContext.SaveChangesAsync();
            return ddiem;

        }

        public async Task<DiaDiem> Delete(DiaDiem ddiem)
        {
            _dbContext.DiaDiems.Remove(ddiem);
            await _dbContext.SaveChangesAsync();
            return ddiem;
        }





        public async Task<DiaDiem> Update(DiaDiem ddiem)
        {
            _dbContext.DiaDiems.Update(ddiem);
            await _dbContext.SaveChangesAsync();
            return ddiem;
        }

        public async Task<DiaDiem> GetById(int id)
        {
            return await _dbContext.DiaDiems.FindAsync(id);
        }





    }
}

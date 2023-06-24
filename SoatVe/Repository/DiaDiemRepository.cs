using SoatVe.Data;
using SoatVe.Interface;
using SoatVe.Models.DTO;
using SoatVe.Models;
using Microsoft.EntityFrameworkCore;

namespace SoatVe.Repository
{
    public class DiaDiemRepository : IDiaDiemRepository
    {

        private readonly SoatVeDbContext _dbContext;
        public DiaDiemRepository(SoatVeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<DDiemDto>> GetDiaDiems()
        {
            return await _dbContext.DiaDiems.Select(x => new DDiemDto()
            {
                //Id = x.Id,
                //Ten = x.Ten,
                //DiaDiem = x.DiaDiem,
                //type_progame = x.type_progame,
            }).ToListAsync();
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

        public async Task<DiaDiem> GetById(Guid id)
        {
            return await _dbContext.DiaDiems.FindAsync(id);
        }





    }
}

using SoatVe.Data;
using SoatVe.Models;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Mvc;
using SoatVe.ViewModel;

namespace SoatVe.Services
{
    public class VeRepository : IVeRepository
    {

        private readonly SoatVeDbContext _dbContext;
        public VeRepository(SoatVeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

       


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


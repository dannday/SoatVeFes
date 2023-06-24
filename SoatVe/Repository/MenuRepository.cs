using SoatVe.Data;
using SoatVe.Interface;
using SoatVe.Models.DTO;
using SoatVe.Models;
using Microsoft.EntityFrameworkCore;

namespace SoatVe.Repository
{
    public class MenuRepository : IMenuRepository
    {

        private readonly SoatVeDbContext _dbContext;
        public MenuRepository(SoatVeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CTDto>> GetMenus()
        {
            return await _dbContext.Menus.Select(x => new CTDto()
            {
                //Id = x.Id,
                //Ten = x.Ten,
                //DiaDiem = x.DiaDiem,
                //type_progame = x.type_progame,
            }).ToListAsync();
        }



        //public async Task<Menu> GetTieu_Diem(int type)
        //{
        //    return await _dbContext.Menus.FindAsync(1);
        //}

        //public async Task<Menu> AddMenu(AddMenuRequest addMenuRequest, Menu menu)
        //{

        //    //var menu = new Menu()
        //    //{
        //    //    Id = Guid.NewGuid(),
        //    //    Ten = addMenuRequest.Ten,
        //    //    DiaDiem = addMenuRequest.DiaDiem,
        //    //    HinhAnh = addMenuRequest.HinhAnh,
        //    //    MoTa = addMenuRequest.MoTa,
        //    //};

        //    await _dbContext.Menus.AddAsync(menu);
        //    await _dbContext.SaveChangesAsync();
        //    return menu;

        //}

        public async Task<Menu> Create(Menu menu)
        {
            await _dbContext.Menus.AddAsync(menu);
            await _dbContext.SaveChangesAsync();
            return menu;

        }

        public async Task<Menu> Delete(Menu menu)
        {
            _dbContext.Menus.Remove(menu);
            await _dbContext.SaveChangesAsync();
            return menu;
        }





        public async Task<Menu> Update(Menu menu)
        {
            _dbContext.Menus.Update(menu);
            await _dbContext.SaveChangesAsync();
            return menu;
        }

        public async Task<Menu> GetById(Guid id)
        {
            return await _dbContext.Menus.FindAsync(id);
        }





    }
}

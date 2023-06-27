using Microsoft.EntityFrameworkCore;
using SoatVe.Data;
using SoatVe.Interface;
using SoatVe.Models;
using SoatVe.Models.DTO;
using System;

namespace SoatVe.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly SoatVeDbContext _dbContext;
        public UserRepository(SoatVeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CTDto>> GetUsers()
        {
            return await _dbContext.Users.Select(x => new CTDto()
            {
                //Id =x.Id,
                //Ten = x.Ten,
                //DiaDiem = x.DiaDiem,
                //type_progame = x.type_progame,
            }).ToListAsync();
        }




        public async Task<IEnumerable<User>> Search(string ten)
        {
            IQueryable<User> query = _dbContext.Users;

            if (!string.IsNullOrEmpty(ten))
            {
                query = query.Where(x => x.Sdt == ten);
            }




            return await query.ToListAsync();
        }


        //public async Task<User> GetTieu_Diem(int type)
        //{
        //    return await _dbContext.Users.FindAsync(1);
        //}

        //public async Task<User> AddUser(AddUserRequest addUserRequest, User ctrinh)
        //{

        //    //var ctrinh = new User()
        //    //{
        //    //    Id = int.Newint(),
        //    //    Ten = addUserRequest.Ten,
        //    //    DiaDiem = addUserRequest.DiaDiem,
        //    //    HinhAnh = addUserRequest.HinhAnh,
        //    //    MoTa = addUserRequest.MoTa,
        //    //};

        //    await _dbContext.Users.AddAsync(ctrinh);
        //    await _dbContext.SaveChangesAsync();
        //    return ctrinh;

        //}

        public async Task<User> Create(User ctrinh)
        {
            await _dbContext.Users.AddAsync(ctrinh);
            await _dbContext.SaveChangesAsync();
            return ctrinh;

        }

        public async Task<User> Delete(User ctrinh)
        {
            _dbContext.Users.Remove(ctrinh);
            await _dbContext.SaveChangesAsync();
            return ctrinh;
        }





        public async Task<User> Update(User ctrinh)
        {
            _dbContext.Users.Update(ctrinh);
            await _dbContext.SaveChangesAsync();
            return ctrinh;
        }

        public async Task<User> GetById(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }


        


    }
}

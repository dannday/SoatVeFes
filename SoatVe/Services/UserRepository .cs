using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SoatVe.Data;

using SoatVe.Models;
using SoatVe.ViewModel;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SoatVe.Services
{
    public class UserRepository : IUserRepository
    {


        public UserRepository(UserManager<User> userManager, SignInManager<User> signInManager,
        IConfiguration configuration, RoleManager<IdentityRole> roleManager, SoatVeDbContext dbContext)
        {
            _dbContext = dbContext;

            _userManager = userManager;
            _signInManager = signInManager;
            _config = configuration;
            _roleManager = roleManager;
            _dbContext = dbContext;
        }

        private readonly SoatVeDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _config;




        public async Task<string> Authencate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Sdt);
            if (user == null)
            {
                return null;
            }

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            if (!result.Succeeded)
            {
                return null;
            }

            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.GivenName,user.Ten),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role, string.Join(";",roles))
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);


        }


        public async Task<bool> Register(RegisterRequest request)
        {
            var user = new User()
            {
                Sdt = request.Sdt,
                Ten = request.Ten,
                Email = request.Email,
                Password = request.Password,
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }



        //public async Task<IEnumerable<UserVM>> GetUsers()
        //{
        //    return await _dbContext.Users.Select(x => new UserVM()
        //    {
        //        //Id =x.Id,
        //        //Ten = x.Ten,
        //        //DiaDiem = x.DiaDiem,
        //        //type_progame = x.type_progame,
        //    }).ToListAsync();
        //}




        public async Task<IEnumerable<User>> Search(string ten)
        {
            IQueryable<User> query = _dbContext.Users;

            if (!string.IsNullOrEmpty(ten))
            {
                query = query.Where(x => x.Sdt == ten);
            }




            return await query.ToListAsync();
        }


        
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

///using DurableTask.Core.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SoatVe.Models;
using SoatVe.Services;
using SoatVe.ViewModel;
using System;

namespace SoatVe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultToken = await _userRepository.Authencate(request);

            if (string.IsNullOrEmpty(resultToken))
            {
                return BadRequest("Khong ton tai");
            }
            return Ok(new { token = resultToken });
        }



        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userRepository.Register(request);

            if (!result)
            {
                return BadRequest("Khong Thanh Cong");
            }
            return Ok();
        }






        //hi

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var users = await _userRepository.GetUsers();
        //    return Ok(users);
        //}




        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<User>>> Search(string ten)
        {
            try
            {
                var users = await _userRepository.Search(ten);

                if (users.Any())
                {
                    return Ok(users);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Loi");

            }
        }




        //[HttpPost]
        //public async Task<IActionResult> Create(Models.User user)
        //{

        //    var users = await _userRepository.Create(user);
        //    return CreatedAtAction(nameof(GetById), new { id = user.Id }, users);
        //}





        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateUserRequest([FromRoute] int id, ViewModel.UpdateUserRequest updateUserRequest)
        {
            var user = await _userRepository.GetById(id);
            if (user != null)
            {
                user.Ten = updateUserRequest.Ten;
                user.Email= updateUserRequest.Email;
                user.Sdt = updateUserRequest.Sdt;
                user.Password = updateUserRequest.Password;

                await _userRepository.Update(user);

                return Ok(user);
            }

            return NotFound();
        }






        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var users = await _userRepository.GetById(id);

            if (users == null)
            {
                return NotFound($"{id} is not found");
            }

            return Ok(users);
        }



        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var user = await _userRepository.GetById(id);
            if (user != null)
            {



                await _userRepository.Delete(user);

                return Ok(user);
            }

            return NotFound();
        }
    }

}




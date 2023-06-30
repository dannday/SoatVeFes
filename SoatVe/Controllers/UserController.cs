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


        //[HttpPost("authenticate")]
        //[AllowAnonymous]
        //public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        //{
        //    if(!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var resultToken = await _userRepository.Authencate(request);

        //    if (string.IsNullOrEmpty(resultToken))
        //    {
        //        return BadRequest("Khong ton tai");
        //    }
        //    return Ok(new { token = resultToken });
        //}



        //[HttpPost("register")]
        //[AllowAnonymous]
        //public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var result = await _userRepository.Register(request);

        //    if (!result)
        //    {
        //        return BadRequest("Khong Thanh Cong");
        //    }
        //    return Ok();
        //}






        //hi

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var ctrinhs = await _userRepository.GetUsers();
        //    return Ok(ctrinhs);
        //}




        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<User>>> Search(string ten)
        {
            try
            {
                var ctrinhs = await _userRepository.Search(ten);

                if (ctrinhs.Any())
                {
                    return Ok(ctrinhs);
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
        //public async Task<IActionResult> Create(Models.User ctrinh)
        //{

        //    var ctrinhs = await _userRepository.Create(ctrinh);
        //    return CreatedAtAction(nameof(GetById), new { id = ctrinh.Id }, ctrinhs);
        //}





        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateUserRequest([FromRoute] int id, UpdateUserRequest updateUserRequest)
        {
            var ctrinh = await _userRepository.GetById(id);
            if (ctrinh != null)
            {
                //ctrinh.Ten = updateUserRequest.Ten;
                //ctrinh.DiaDiem = updateUserRequest.DiaDiem;
                //ctrinh.HinhAnh = updateUserRequest.HinhAnh;
                //ctrinh.MoTa = updateUserRequest.MoTa;

                await _userRepository.Update(ctrinh);

                return Ok(ctrinh);
            }

            return NotFound();
        }






        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var ctrinhs = await _userRepository.GetById(id);

            if (ctrinhs == null)
            {
                return NotFound($"{id} is not found");
            }

            return Ok(ctrinhs);
        }



        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var ctrinh = await _userRepository.GetById(id);
            if (ctrinh != null)
            {



                await _userRepository.Delete(ctrinh);

                return Ok(ctrinh);
            }

            return NotFound();
        }
    }

}




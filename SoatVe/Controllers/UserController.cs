///using DurableTask.Core.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoatVe.Interface;
using SoatVe.Models;
using System;

namespace SoatVe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly IUserRepository _userRepository;

        public UsersController(IUserRepository ctRepository)
        {
            _userRepository = ctRepository;
        }


        //hi

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ctrinhs = await _userRepository.GetUsers();
            return Ok(ctrinhs);
        }




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




        [HttpPost]
        public async Task<IActionResult> Create(Models.User ctrinh)
        {

            var ctrinhs = await _userRepository.Create(ctrinh);
            return CreatedAtAction(nameof(GetById), new { id = ctrinh.Id }, ctrinhs);
        }





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


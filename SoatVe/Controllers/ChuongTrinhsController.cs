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
    public class ChuongTrinhsController : ControllerBase
    {
        public readonly ICTRepository _cTRepository;

        public ChuongTrinhsController(ICTRepository ctRepository)
        {
            _cTRepository = ctRepository;
        }


        //hi

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ctrinhs = await _cTRepository.GetChuongTrinhs();
            return Ok(ctrinhs);
        }


        

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<ChuongTrinh>>> Search(string? ten, string? ctrinh)
        {
            try
            {
                var ctrinhs = await _cTRepository.Search(ten,ctrinh);

                if (ctrinhs.Any())
                {
                    return Ok(ctrinhs);
                }
                return NotFound();
            }
            catch(Exception ) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Loi");
            
            }
        }




        [HttpPost]
        public async Task<IActionResult> Create(Models.ChuongTrinh ctrinh)
        {

            var ctrinhs = await _cTRepository.Create(ctrinh);
            return CreatedAtAction(nameof(GetById), new { id = ctrinh.Id }, ctrinhs);
        }

       



        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateChuongTrinhRequest([FromRoute] int id, UpdateChuongTrinhRequest updateChuongTrinhRequest)
        {
            var ctrinh = await _cTRepository.GetById(id);
            if (ctrinh != null)
            {
                ctrinh.Ten = updateChuongTrinhRequest.Ten;
                ctrinh.DiaDiem = updateChuongTrinhRequest.DiaDiem;
                ctrinh.HinhAnh = updateChuongTrinhRequest.HinhAnh;
                ctrinh.MoTa = updateChuongTrinhRequest.MoTa;

                await _cTRepository.Update(ctrinh);

                return Ok(ctrinh);
            }

            return NotFound();
        }


        
       


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var ctrinhs = await _cTRepository.GetById(id);

            if(ctrinhs == null)
            {
                return NotFound($"{id} is not found");
            }

            return Ok(ctrinhs);
        }



        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var ctrinh = await _cTRepository.GetById(id);
            if (ctrinh != null)
            {



                await _cTRepository.Delete(ctrinh);

                return Ok(ctrinh);
            }

            return NotFound();
        }
    }


}


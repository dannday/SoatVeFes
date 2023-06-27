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
    public class ThongTinsController : ControllerBase
    {
        public readonly IThongTinRepository _tTRepository;

        public ThongTinsController(IThongTinRepository ctRepository)
        {
            _tTRepository = ctRepository;
        }


        //hi

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ttins = await _tTRepository.GetThongTins();
            return Ok(ttins);
        }




        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<ThongTin>>> Search(string ten)
        {
            try
            {
                var ttins = await _tTRepository.Search(ten);

                if (ttins.Any())
                {
                    return Ok(ttins);
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
        public async Task<IActionResult> Create(Models.ThongTin ttin)
        {

            var ttins = await _tTRepository.Create(ttin);
            return CreatedAtAction(nameof(GetById), new { id = ttin.Id }, ttins);
        }





        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateThongTinRequest([FromRoute] int id, UpdateThongTinRequest updateThongTinRequest)
        {
            var ttin = await _tTRepository.GetById(id);
            if (ttin != null)
            {
                //ttin.Ten = updateThongTinRequest.Ten;
                //ttin.DiaDiem = updateThongTinRequest.DiaDiem;
                //ttin.HinhAnh = updateThongTinRequest.HinhAnh;
                //ttin.MoTa = updateThongTinRequest.MoTa;

                await _tTRepository.Update(ttin);

                return Ok(ttin);
            }

            return NotFound();
        }






        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var ttins = await _tTRepository.GetById(id);

            if (ttins == null)
            {
                return NotFound($"{id} is not found");
            }

            return Ok(ttins);
        }



        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var ttin = await _tTRepository.GetById(id);
            if (ttin != null)
            {



                await _tTRepository.Delete(ttin);

                return Ok(ttin);
            }

            return NotFound();
        }
    }


}


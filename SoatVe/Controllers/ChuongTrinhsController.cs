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


        [HttpPost]
        public async Task<IActionResult> Create(Models.ChuongTrinh ctrinh)
        {

            var ctrinhs = await _cTRepository.Create(ctrinh);
            return CreatedAtAction(nameof(GetById), new { id = ctrinh.Id }, ctrinhs);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetTieu_Diem()
        //{
        //    var ctrinhs = await _cTRepository.GetTieu_Diem();
        //    return Ok(ctrinhs);
        //}






        //[HttpPost]
        //public async Task<IActionResult> AddChuongTrinh(AddChuongTrinhRequest addChuongTrinhRequest)
        //{
        //    var ctrinhs = new ChuongTrinh()
        //    {
        //       // Id = int.Newint(),
        //       Id = addChuongTrinhRequest.Id,
        //        Ten = addChuongTrinhRequest.Ten,
        //        DiaDiem = addChuongTrinhRequest.DiaDiem,
        //        HinhAnh = addChuongTrinhRequest.HinhAnh,
        //        MoTa = addChuongTrinhRequest.MoTa,
        //        type_progame = addChuongTrinhRequest.type_progame,

        //    };

        //    await _cTRepository.Create(ctrinhs);

        //    return Ok(ctrinhs);
        //}



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

    }
}

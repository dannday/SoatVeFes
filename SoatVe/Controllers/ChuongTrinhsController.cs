///using DurableTask.Core.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoatVe.Models;
using SoatVe.Services;
using SoatVe.ViewModel;
using System;
using System.Linq.Expressions;

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
        public async Task<ActionResult<IEnumerable<ChuongTrinh>>> Search(string? ten, string? ctrinh, int? type_progame)
        {
            try
            {
                var ctrinhs = await _cTRepository.Search(ten,ctrinh, type_progame);

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
        public async Task<AddChuongTrinh> Add(ViewModel.AddChuongTrinh add)
        {

            var ctrinhs = new ChuongTrinh()
            {
                Ten = add.TenCT,
                HinhAnh = add.HinhAnh,
                MoTa = add.MoTa,
                type_progame = add.type_progame,
                DiaDiemId = add.DiaDiemId,
                
            };
            await _cTRepository.Create(ctrinhs);

            return add;

        }





        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateChuongTrinhRequest([FromRoute] int id, ViewModel.UpdateChuongTrinh updateChuongTrinhRequest)
        {


            var ctrinh = await _cTRepository.GetById(id);
            if (ctrinh != null)
            {
                ctrinh.Ten = updateChuongTrinhRequest.TenCT;

                ctrinh.HinhAnh = updateChuongTrinhRequest.HinhAnh;
                ctrinh.MoTa = updateChuongTrinhRequest.MoTa;

                await _cTRepository.Update(ctrinh);

                return Ok(ctrinh);
            }

            return NotFound();
        }


        //[HttpGet("{id}")]
        //public IActionResult Detais(int id)
        //{
        //    try
        //    {
        //        var ctrinh = _cTRepository.Details(id);
        //        if(ctrinh != null)
        //        {
        //            return Ok(ctrinh);
        //        }
        //        else{
        //            return NotFound();
        //        }
        //    }
        //    catch
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            "Loi");
        //    }
        //}



        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var ctrinhs = await _cTRepository.GetById(id);

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


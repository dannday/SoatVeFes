///using DurableTask.Core.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoatVe.Models;
using SoatVe.Services;
using SoatVe.ViewModel;
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




        [HttpPost]
        public async Task<AddThongTin> AddThongTin(ViewModel.AddThongTin add)
        {
            var ttin = new ThongTin()
            {
                Ten=add.Ten,
                NoiDung=add.NoiDung,
            };

            await _tTRepository.Create(ttin);

            return add;
        }



        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateThongTinRequest([FromRoute] int id, ViewModel.UpdateThongTin updateThongTinRequest)
        {
            var ttin = await _tTRepository.GetById(id);
            if (ttin != null)
            {
                ttin.Ten = updateThongTinRequest.Ten;
                ttin.NoiDung= updateThongTinRequest.NoiDung;

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


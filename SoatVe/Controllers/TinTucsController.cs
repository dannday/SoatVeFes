﻿///using DurableTask.Core.Common;
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
    public class TinTucsController : ControllerBase
    {
        public readonly ITinTucRepository _tTRepository;

        public TinTucsController(ITinTucRepository tTRepository)
        {
            _tTRepository = tTRepository;
        }


        //hi

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ttucs = await _tTRepository.GetTinTucs();
            return Ok(ttucs);
        }




        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<TinTuc>>> Search(string ten)
        {
            try
            {
                var ttucs = await _tTRepository.Search(ten);

                if (ttucs.Any())
                {
                    return Ok(ttucs);
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
        public async Task<IActionResult> Create(Models.TinTuc ttuc)
        {

            var ttucs = await _tTRepository.Create(ttuc);
            return CreatedAtAction(nameof(GetById), new { id = ttuc.Id }, ttucs);
        }





        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateTinTucRequest([FromRoute] int id, UpdateTinTucRequest updateTinTucRequest)
        {
            var ttuc = await _tTRepository.GetById(id);
            if (ttuc != null)
            {
                //ttuc.Ten = updateTinTucRequest.Ten;
                //ttuc.DiaDiem = updateTinTucRequest.DiaDiem;
                //ttuc.HinhAnh = updateTinTucRequest.HinhAnh;
                //ttuc.MoTa = updateTinTucRequest.MoTa;

                await _tTRepository.Update(ttuc);

                return Ok(ttuc);
            }

            return NotFound();
        }






        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var ttucs = await _tTRepository.GetById(id);

            if (ttucs == null)
            {
                return NotFound($"{id} is not found");
            }

            return Ok(ttucs);
        }



        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var ttuc = await _tTRepository.GetById(id);
            if (ttuc != null)
            {



                await _tTRepository.Delete(ttuc);

                return Ok(ttuc);
            }

            return NotFound();
        }
    }


}


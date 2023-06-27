using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoatVe.Data;
using SoatVe.Interface;
using SoatVe.Models;
using SoatVe.Repository;

namespace SoatVe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiaDiemsController : ControllerBase
    {
        public readonly IDiaDiemRepository _ddRepository;

        public DiaDiemsController(IDiaDiemRepository ctRepository)
        {
            _ddRepository = ctRepository;
        }


        //hi

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ddiems = await _ddRepository.GetDiaDiems();
            return Ok(ddiems);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Models.DiaDiem ddiem)
        {

            var ddiems = await _ddRepository.Create(ddiem);
            return CreatedAtAction(nameof(GetById), new { id = ddiem.Id }, ddiems);
        }





        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<DiaDiem>>> Search(string ten)
        {
            try
            {
                var ddiems = await _ddRepository.Search(ten);

                if (ddiems.Any())
                {
                    return Ok(ddiems);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Loi");

            }
        }

       

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateDiaDiemRequest([FromRoute] int id, UpdateDiaDiemRequest updateDiaDiemRequest)
        {
            var ddiem = await _ddRepository.GetById(id);
            if (ddiem != null)
            {
                //ddiem.Ten = updateDiaDiemRequest.Ten;
                //ddiem.DiaDiem = updateDiaDiemRequest.DiaDiem;
                //ddiem.HinhAnh = updateDiaDiemRequest.HinhAnh;
                //ddiem.MoTa = updateDiaDiemRequest.MoTa;

                await _ddRepository.Update(ddiem);

                return Ok(ddiem);
            }

            return NotFound();
        }





        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var ddiems = await _ddRepository.GetById(id);

            if (ddiems == null)
            {
                return NotFound($"{id} is not found");
            }

            return Ok(ddiems);
        }



        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var ddiem = await _ddRepository.GetById(id);
            if (ddiem != null)
            {



                await _ddRepository.Delete(ddiem);

                return Ok(ddiem);
            }

            return NotFound();
        }


    }
}

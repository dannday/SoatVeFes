using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoatVe.Data;
using SoatVe.Interface;
using SoatVe.Models;

namespace SoatVe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiaDiemsController : ControllerBase
    {
        public readonly IDiaDiemRepository _cTRepository;

        public DiaDiemsController(IDiaDiemRepository ctRepository)
        {
            _cTRepository = ctRepository;
        }


        //hi

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ddiems = await _cTRepository.GetDiaDiems();
            return Ok(ddiems);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Models.DiaDiem ddiem)
        {

            var ddiems = await _cTRepository.Create(ddiem);
            return CreatedAtAction(nameof(GetById), new { id = ddiem.Id }, ddiems);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetTieu_Diem()
        //{
        //    var ddiems = await _cTRepository.GetTieu_Diem();
        //    return Ok(ddiems);
        //}






        //[HttpPost]
        //public async Task<IActionResult> AddDiaDiem(AddDiaDiemRequest addDiaDiemRequest)
        //{
        //    var ddiems = new DiaDiem()
        //    {
        //       // Id = Guid.NewGuid(),
        //       Id = addDiaDiemRequest.Id,
        //        Ten = addDiaDiemRequest.Ten,
        //        DiaDiem = addDiaDiemRequest.DiaDiem,
        //        HinhAnh = addDiaDiemRequest.HinhAnh,
        //        MoTa = addDiaDiemRequest.MoTa,
        //        type_progame = addDiaDiemRequest.type_progame,

        //    };

        //    await _cTRepository.Create(ddiems);

        //    return Ok(ddiems);
        //}



        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateDiaDiemRequest([FromRoute] int id, UpdateDiaDiemRequest updateDiaDiemRequest)
        {
            var ddiem = await _cTRepository.GetById(id);
            if (ddiem != null)
            {
                //ddiem.Ten = updateDiaDiemRequest.Ten;
                //ddiem.DiaDiem = updateDiaDiemRequest.DiaDiem;
                //ddiem.HinhAnh = updateDiaDiemRequest.HinhAnh;
                //ddiem.MoTa = updateDiaDiemRequest.MoTa;

                await _cTRepository.Update(ddiem);

                return Ok(ddiem);
            }

            return NotFound();
        }






        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var ddiems = await _cTRepository.GetById(id);

            if (ddiems == null)
            {
                return NotFound($"{id} is not found");
            }

            return Ok(ddiems);
        }

    }
}

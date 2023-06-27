using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoatVe.Interface;
using SoatVe.Models;
using SoatVe.Repository;

namespace SoatVe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VesController : ControllerBase
    {
        public readonly IVeRepository _veRepository;

        public VesController(IVeRepository veRepository)
        {
            _veRepository = veRepository;
        }



        //[HttpGet]
        //public async Task<Ve> GetAll()
        //{
        //    return Ok(await _veRepository.GetAll.ToListAsync());
        //}




        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ves = await _veRepository.GetVes();
            return Ok(ves);
        }



        [HttpPost]
        public async Task<IActionResult> Create(Models.Ve ve)
        {
            var ves = await _veRepository.Create(ve);
            return CreatedAtAction(nameof(GetById), new { id = ve.Id }, ves);
        }




        //[HttpPost]
        //public async Task<IActionResult> AddVe(AddVeRequest addVeRequest)
        //{
        //    var ves = new Ve()
        //    {
        //      //  Id = Guid.NewGuid(),

        //        NgayDien= addVeRequest.NgayDien,
        //        Soluong = addVeRequest.Soluong,
        //        GiaVe = addVeRequest.GiaVe,
        //        QRCode= addVeRequest.QRCode,    
        //    };

        //    await _veRepository.Create(ves);

        //    return Ok(ves);
        //}



        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateVeRequest([FromRoute] int id, UpdateVeRequest updateVeRequest)
        {
            var ve = await _veRepository.GetById(id);
            if (ve != null)
            {
                ve.NgayDien= updateVeRequest.NgayDien;
                ve.Soluong= updateVeRequest.Soluong;
                ve.GiaVe= updateVeRequest.GiaVe;

                await _veRepository.Update(ve);

                return Ok(ve);
            }

            return NotFound();
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var ve = await _veRepository.GetById(id);
            if (ve != null)
            {



                await _veRepository.Delete(ve);

                return Ok(ve);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var ves = await _veRepository.GetById(id);

            if (ves == null)
            {
                return NotFound($"{id} is not found");
            }

            return Ok(ves);
        }

    }
}

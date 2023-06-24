using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoatVe.Interface;
using SoatVe.Models;

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


        //hi

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ves = await _veRepository.GetVes();
            return Ok(ves);
        }


        //[HttpPost]
        //public async Task<IActionResult> Create(Models.Ve ve)
        //{
        //    var ves = await _veRepository.Create(ve);
        //    return CreatedAtAction(nameof(GetById), new { id = ve.Id }, ves);
        //}




        [HttpPost]
        public async Task<IActionResult> AddVe(AddVeRequest addVeRequest)
        {
            var ves = new Ve()
            {
                Id = Guid.NewGuid(),
                NgayDien= addVeRequest.NgayDien,
                Soluong = addVeRequest.Soluong,
                GiaVe = addVeRequest.GiaVe,
                QRCode= addVeRequest.QRCode,    
            };

            await _veRepository.Create(ves);

            return Ok(ves);
        }



        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateVeRequest([FromRoute] Guid id, UpdateVeRequest updateVeRequest)
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


        //[HttpPut]
        //[Route("{id}")]

        //public async Task<IActionResult> Update(Guid id, Models.Ve ve)
        //{
        //    if (!ModelState.IsValid) 
        //        return BadRequest(ModelState);


        //    var CTFromDb = await _cTRepository.GetById(id);

        //    if (CTFromDb == null)
        //    {
        //        return NotFound();
        //    }


        //    var ves = await _cTRepository.Update(ve);
        //    return Ok(ves);
        //}


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
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

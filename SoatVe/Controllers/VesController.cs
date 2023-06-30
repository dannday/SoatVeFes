using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoatVe.Models;
using SoatVe.Services;
using SoatVe.ViewModel;

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



        [HttpPost]
        public async Task<AddVe> AddVe(ViewModel.AddVe add)
        {
            var ves = new Ve()
            {
                NgayDien = add.NgayDien,
                Soluong = add.Soluong,
                GiaVe = add.GiaVe,
                QRCode = add.QRCode,
               

            };

            await _veRepository.Create(ves);

            return add;
        }



        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateVeRequest([FromRoute] int id, UpdateVe update)
        {
            var ve = await _veRepository.GetById(id);
            if (ve != null)
            {
                //ve.NgayDien= updateVeRequest.NgayDien;
                //ve.Soluong= updateVeRequest.Soluong;
                //ve.GiaVe= updateVeRequest.GiaVe;

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

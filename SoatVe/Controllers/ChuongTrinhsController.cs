///using DurableTask.Core.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoatVe.Models;
using SoatVe.Repository;

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
            return CreatedAtAction(nameof(GetById),new{id=ctrinh.Id },ctrinhs );
        }



        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> Update(Guid id, Models.ChuongTrinh ctrinh)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);


            var CTFromDb = await _cTRepository.GetById(id);

            if (CTFromDb == null)
            {
                return NotFound();
            }


            var ctrinhs = await _cTRepository.Update(ctrinh);
            return Ok(ctrinhs);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
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

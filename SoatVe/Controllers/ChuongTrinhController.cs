///using DurableTask.Core.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoatVe.Models;
using SoatVe.Repository;

namespace SoatVe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChuongTrinhController : ControllerBase
    {
        public readonly ICTRepository _cTRepository;

        public ChuongTrinhController(ICTRepository ctRepository) 
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
        public async Task<IActionResult> Create(ChuongTrinh ctrinh)
        {
            var ctrinhs = await _cTRepository.Create(ctrinh);
            return CreatedAtAction(nameof(GetById),ctrinhs);
        }



        [HttpPut("{:id}")]
        public async Task<IActionResult> Update(Guid id ,ChuongTrinh ctrinh)
        {

            var CTFromDb = await _cTRepository.GetById(id);
            if(CTFromDb == null)
            {
                return NotFound();
            }


            var ctrinhs = await _cTRepository.Update(ctrinh);
            return Ok(ctrinhs);
        }


        [HttpGet("{:id}")]
        public async Task<IActionResult> GetById(Guid id)
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

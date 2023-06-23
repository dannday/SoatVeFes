using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoatVe.Data;
using SoatVe.Models;

namespace SoatVe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiaDiemsController : Controller
    {
        private readonly SoatVeDbContext dbContext;

        public DiaDiemsController(SoatVeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        //[HttpGet]
        //public async Task<IActionResult> GetDiaDiems()
        //{
        //    return Ok(await dbContext.DiaDiems.ToListAsync());
        //}


        [HttpGet]
        public async Task<IActionResult> GetMNDiaDiem()
        {
            return Ok(await dbContext.DiaDiems.ToListAsync());
        }


        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetDiaDiem([FromRoute] Guid id)
        {
            var diadiem = await dbContext.DiaDiems.FindAsync(id);

            if (diadiem == null)
            {
                return NotFound();
            }

            return Ok(diadiem);

        }


        [HttpPost]
        public async Task<IActionResult> AddDiaDiem(AddDiaDiemRequest addDiaDiemRequest)
        {
            var diadiem = new DiaDiem()
            {
                Id = Guid.NewGuid(),
                Ten = addDiaDiemRequest.Ten,
                HinhAnh = addDiaDiemRequest.HinhAnh,
                NoiDung = addDiaDiemRequest.NoiDung,
            };

            await dbContext.DiaDiems.AddAsync(diadiem);
            await dbContext.SaveChangesAsync();

            return Ok(diadiem);
        }


        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateDiaDiem([FromRoute] Guid id, UpdateDiaDiemRequest updateDiaDiemRequest)
        {
            var diadiem = await dbContext.DiaDiems.FindAsync(id);
            if (diadiem != null)
            {
                diadiem.Ten = updateDiaDiemRequest.Ten;
                diadiem.HinhAnh = updateDiaDiemRequest.HinhAnh;
                diadiem.NoiDung = updateDiaDiemRequest.NoiDung;

                await dbContext.SaveChangesAsync();

                return Ok(diadiem);
            }

            return NotFound();
        }


        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteDiaDiem([FromRoute] Guid id)
        {
            var diadiem = await dbContext.DiaDiems.FindAsync(id);

            if (diadiem != null)
            {
                dbContext.Remove(diadiem);
                await dbContext.SaveChangesAsync();
                return Ok(diadiem);
            }

            return NotFound();

        }

    }
}

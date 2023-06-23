using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoatVe.Data;
using SoatVe.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SoatVe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TinTucsController : Controller
    {
        private readonly SoatVeDbContext dbContext;

        public TinTucsController(SoatVeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetTinTucs()
        {
            return Ok(await dbContext.TinTucs.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetTinTuc([FromRoute] Guid id)
        {
            var tintuc = await dbContext.TinTucs.FindAsync(id);

            if (tintuc == null)
            {
                return NotFound();
            }

            return Ok(tintuc);

        }


        [HttpPost]
        public async Task<IActionResult> AddTinTuc(AddTinTucRequest addTinTucRequest)
        {
            var tintuc = new TinTuc()
            {
                Id = Guid.NewGuid(),
                Ten = addTinTucRequest.Ten,
                HinhAnh = addTinTucRequest.HinhAnh,
                NoiDung = addTinTucRequest.NoiDung,
                NgayDang = addTinTucRequest.NgayDang
            };

            await dbContext.TinTucs.AddAsync(tintuc);
            await dbContext.SaveChangesAsync();

            return Ok(tintuc);
        }


        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateTinTuc([FromRoute] Guid id, UpdateTinTucRequest updateTinTucRequest)
        {
            var tintuc = await dbContext.TinTucs.FindAsync(id);
            if (tintuc != null)
            {
                tintuc.Ten = updateTinTucRequest.Ten;
                tintuc.HinhAnh = updateTinTucRequest.HinhAnh;
                tintuc.NoiDung = updateTinTucRequest.NoiDung;
                tintuc.NgayDang = updateTinTucRequest.NgayDang;

                await dbContext.SaveChangesAsync();

                return Ok(tintuc);
            }

            return NotFound();
        }


        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteTinTuc([FromRoute] Guid id)
        {
            var tintuc = await dbContext.TinTucs.FindAsync(id);

            if (tintuc != null)
            {
                dbContext.Remove(tintuc);
                await dbContext.SaveChangesAsync();
                return Ok(tintuc);
            }

            return NotFound();

        }

    }
}


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SoatVe.Data;
using SoatVe.Models;
using SoatVe.ViewModel;
using System.Reflection.PortableExecutable;

namespace SoatVe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChuongTrinhsController : Controller
    {
        private readonly SoatVeDbContext dbContext;

        public ChuongTrinhsController(SoatVeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //private readonly IChuongTrinhService  chuongTrinhsv;

        //public ChuongTrinhsController(IChuongTrinhService _chuongTrinhsv)
        //{
        //    chuongTrinhsv = _chuongTrinhsv;
        //}


        [HttpGet("get_chuong_trinh")]
        public async Task<IActionResult> GetChuongTrinhs()
        {
            return Ok(await dbContext.ChuongTrinhs.ToListAsync());
        }




        [HttpGet("details_chuong_trinh")]
        public async Task<IActionResult> GetCTVm( )
        {
            return Ok(await dbContext.ChuongTrinhs.ToListAsync());
        }



        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetChuongTrinh([FromRoute] Guid id)
        {
            var chuongtrinh = await dbContext.ChuongTrinhs.FindAsync(id);

            if (chuongtrinh == null)
            {
                return NotFound();
            }

            return Ok(chuongtrinh);

        }


        //[HttpPost]
        //public async Task<IActionResult> AddChuongTrinh(AddChuongTrinhRequest addChuongTrinhRequest)
        //{
        //    var chuongtrinh = new ChuongTrinh()
        //    {
        //        Id = Guid.NewGuid(),
        //        Ten = addChuongTrinhRequest.Ten,
        //        DiaDiem = addChuongTrinhRequest.DiaDiem,
        //        HinhAnh = addChuongTrinhRequest.HinhAnh,
        //        MoTa = addChuongTrinhRequest.MoTa,
        //        Gia = addChuongTrinhRequest.Gia
        //    };

        //    await dbContext.ChuongTrinhs.AddAsync(chuongtrinh);
        //    await dbContext.SaveChangesAsync();

        //    return Ok(chuongtrinh);
        //}


        //[HttpPut]
        //[Route("{id:guid}")]
        //public async Task<IActionResult> UpdateChuongTrinh([FromRoute] Guid id, UpdateChuongTrinhRequest updateChuongTrinhRequest)
        //{
        //    var chuongtrinh = await dbContext.ChuongTrinhs.FindAsync(id);
        //    if (chuongtrinh != null)
        //    {
        //        chuongtrinh.Ten = updateChuongTrinhRequest.Ten;
        //        chuongtrinh.DiaDiem = updateChuongTrinhRequest.DiaDiem;
        //        chuongtrinh.HinhAnh = updateChuongTrinhRequest.HinhAnh;
        //        chuongtrinh.MoTa = updateChuongTrinhRequest.MoTa;
        //        chuongtrinh.Gia = updateChuongTrinhRequest.Gia;

        //        await dbContext.SaveChangesAsync();

        //        return Ok(chuongtrinh);
        //    }

        //    return NotFound();
        //}


        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteChuongTrinh([FromRoute] Guid id)
        {
            var chuongtrinh = await dbContext.ChuongTrinhs.FindAsync(id);

            if (chuongtrinh != null)
            {
                dbContext.Remove(chuongtrinh);
                await dbContext.SaveChangesAsync();
                return Ok(chuongtrinh);
            }

            return NotFound();

        }

    }
}


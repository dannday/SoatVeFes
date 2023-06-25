using Microsoft.AspNetCore.Mvc;
using SoatVe.Interface;
using SoatVe.Models;

namespace SoatVe.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        public class ThongTinsController : ControllerBase
        {
            public readonly IThongTinRepository _menuRepository;

            public ThongTinsController(IThongTinRepository menuRepository)
            {
            _menuRepository = menuRepository;
            }


            //hi

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var menus = await _menuRepository.GetThongTins();
                return Ok(menus);
            }


            //[HttpPost]
            //public async Task<IActionResult> Create(Models.ThongTin menu)
            //{

            //    var menus = await _menuRepository.Create(menu);
            //    return CreatedAtAction(nameof(GetById), new { id = menu.Id }, menus);
            //}

            //[HttpGet]
            //public async Task<IActionResult> GetTieu_Diem()
            //{
            //    var menus = await _menuRepository.GetTieu_Diem();
            //    return Ok(menus);
            //}






            [HttpPost]
            public async Task<IActionResult> AddThongTin(AddThongTinRequest addThongTinRequest)
            {
                var menus = new ThongTin()
                {
                    //Id = int.Newint(),
                    //Ten = addThongTinRequest.Ten,
                    //DiaDiem = addThongTinRequest.DiaDiem,
                    //HinhAnh = addThongTinRequest.HinhAnh,
                    //MoTa = addThongTinRequest.MoTa,
                    //type_progame = addThongTinRequest.type_progame,

                };

                await _menuRepository.Create(menus);

                return Ok(menus);
            }



            [HttpPut]
            [Route("{id:int}")]
            public async Task<IActionResult> UpdateThongTinRequest([FromRoute] int id, UpdateThongTinRequest updateThongTinRequest)
            {
                var menu = await _menuRepository.GetById(id);
                if (menu != null)
                {
                    //menu.Ten = updateThongTinRequest.Ten;
                    //menu.DiaDiem = updateThongTinRequest.DiaDiem;
                    //menu.HinhAnh = updateThongTinRequest.HinhAnh;
                    //menu.MoTa = updateThongTinRequest.MoTa;

                    await _menuRepository.Update(menu);

                    return Ok(menu);
                }

                return NotFound();
            }






            [HttpGet]
            [Route("{id}")]
            public async Task<IActionResult> GetById([FromRoute] int id)
            {
                var menus = await _menuRepository.GetById(id);

                if (menus == null)
                {
                    return NotFound($"{id} is not found");
                }

                return Ok(menus);
            }

        }
    }

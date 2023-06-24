using Microsoft.AspNetCore.Mvc;
using SoatVe.Interface;
using SoatVe.Models;

namespace SoatVe.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        public class MenusController : ControllerBase
        {
            public readonly IMenuRepository _menuRepository;

            public MenusController(IMenuRepository menuRepository)
            {
            _menuRepository = menuRepository;
            }


            //hi

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var menus = await _menuRepository.GetMenus();
                return Ok(menus);
            }


            //[HttpPost]
            //public async Task<IActionResult> Create(Models.Menu menu)
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
            public async Task<IActionResult> AddMenu(AddMenuRequest addMenuRequest)
            {
                var menus = new Menu()
                {
                    //Id = Guid.NewGuid(),
                    //Ten = addMenuRequest.Ten,
                    //DiaDiem = addMenuRequest.DiaDiem,
                    //HinhAnh = addMenuRequest.HinhAnh,
                    //MoTa = addMenuRequest.MoTa,
                    //type_progame = addMenuRequest.type_progame,

                };

                await _menuRepository.Create(menus);

                return Ok(menus);
            }



            [HttpPut]
            [Route("{id:guid}")]
            public async Task<IActionResult> UpdateMenuRequest([FromRoute] Guid id, UpdateMenuRequest updateMenuRequest)
            {
                var menu = await _menuRepository.GetById(id);
                if (menu != null)
                {
                    //menu.Ten = updateMenuRequest.Ten;
                    //menu.DiaDiem = updateMenuRequest.DiaDiem;
                    //menu.HinhAnh = updateMenuRequest.HinhAnh;
                    //menu.MoTa = updateMenuRequest.MoTa;

                    await _menuRepository.Update(menu);

                    return Ok(menu);
                }

                return NotFound();
            }






            [HttpGet]
            [Route("{id}")]
            public async Task<IActionResult> GetById([FromRoute] Guid id)
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

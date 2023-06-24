using SoatVe.Models.DTO;
using SoatVe.Models;

namespace SoatVe.Interface
{
    public interface IMenuRepository
    {
        Task<IEnumerable<CTDto>> GetMenus();
        Task<Menu> Create(Menu menu);
        Task<Menu> Update(Menu menu);
        Task<Menu> Delete(Menu menu);
        Task<Menu> GetById(Guid id);
    }
}

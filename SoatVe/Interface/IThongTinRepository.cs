using SoatVe.Models.DTO;
using SoatVe.Models;

namespace SoatVe.Interface
{
    public interface IThongTinRepository
    {
        Task<IEnumerable<CTDto>> GetThongTins();

        Task<IEnumerable<ThongTin>> Search(string ten);
        Task<ThongTin> Create(ThongTin menu);
        Task<ThongTin> Update(ThongTin menu);
        Task<ThongTin> Delete(ThongTin menu);
        Task<ThongTin> GetById(int id);
    }
}

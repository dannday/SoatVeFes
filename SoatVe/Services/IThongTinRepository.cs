using SoatVe.Models;
using SoatVe.ViewModel;

namespace SoatVe.Services
{
    public interface IThongTinRepository
    {
        Task<IEnumerable<ThongTinVM>> GetThongTins();

        Task<IEnumerable<ThongTin>> Search(string ten);
        Task<ThongTin> Create(ThongTin menu);
        Task<ThongTin> Update(ThongTin menu);
        Task<ThongTin> Delete(ThongTin menu);
        Task<ThongTin> GetById(int id);
    }
}

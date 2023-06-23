using SoatVe.Models;

namespace SoatVe.Repository
{
    public interface ICTRepository
    {
        Task<IEnumerable<ChuongTrinh>> GetChuongTrinhs();
        Task<ChuongTrinh> Create(ChuongTrinh ctrinh);
        Task<ChuongTrinh> Update(ChuongTrinh ctrinh);
        Task<ChuongTrinh> Delete(ChuongTrinh ctrinh);
        Task<ChuongTrinh> GetById(Guid id);

    }
}

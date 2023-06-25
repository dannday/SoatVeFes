using SoatVe.Models.DTO;
using SoatVe.Models;

namespace SoatVe.Interface
{
    public interface ITinTucRepository
    {
        Task<IEnumerable<CTDto>> GetTinTucs();
        Task<TinTuc> Create(TinTuc tintuc);
        Task<TinTuc> Update(TinTuc tintuc);
        Task<TinTuc> Delete(TinTuc tintuc);
        Task<TinTuc> GetById(int id);
    }
}

using SoatVe.Models;
using SoatVe.ViewModel;

namespace SoatVe.Services
{
    public interface ITinTucRepository
    {
        Task<IEnumerable<TinTucVM>> GetTinTucs();
        Task<IEnumerable<TinTuc>> Search(string ten);

        Task<TinTuc> Create(TinTuc tintuc);
        Task<TinTuc> Update(TinTuc tintuc);
        Task<TinTuc> Delete(TinTuc tintuc);
        Task<TinTuc> GetById(int id);
    }
}

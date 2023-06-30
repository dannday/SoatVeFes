using SoatVe.Models;
using SoatVe.ViewModel;

namespace SoatVe.Services
{
    public interface IVeRepository
    {
        Task<Ve> Create(Ve ve);
        Task<Ve> Update(Ve ve);
        Task<Ve> Delete(Ve ve);
        Task<Ve> GetById(int id);
    }
}

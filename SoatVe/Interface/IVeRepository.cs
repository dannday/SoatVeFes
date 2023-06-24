using SoatVe.Models.DTO;
using SoatVe.Models;

namespace SoatVe.Interface
{
    public interface IVeRepository
    {
        Task<IEnumerable<VeDto>> GetVes();
        Task<Ve> Create(Ve ve);
        Task<Ve> Update(Ve ve);
        Task<Ve> Delete(Ve ve);
        Task<Ve> GetById(Guid id);
    }
}

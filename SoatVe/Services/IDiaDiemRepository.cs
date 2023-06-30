using SoatVe.Models;
using SoatVe.ViewModel;

namespace SoatVe.Services
{
    public interface IDiaDiemRepository
    {
        Task<IEnumerable<DiaDiemVM>> GetDiaDiems();

        Task<IEnumerable<DiaDiem>> Search(string ten);


        Task<DiaDiem> Create(DiaDiem ddiem);
        Task<DiaDiem> Update(DiaDiem ddiem);
        Task<DiaDiem> Delete(DiaDiem ddiem);
        Task<DiaDiem> GetById(int id);
    }
}

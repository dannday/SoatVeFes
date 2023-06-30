using Microsoft.AspNetCore.Mvc;
using SoatVe.Models;
using SoatVe.ViewModel;

namespace SoatVe.Services
{
    public interface ICTRepository
    {
        Task<IEnumerable<CTVM>> GetChuongTrinhs();
       
        Task<IEnumerable<ChuongTrinh>> Search(string? ten, string? ddiem, int? type_progame);

        CTVM_Details Details(int id);

        Task<ChuongTrinh> Create(ChuongTrinh ctrinh);
        Task<ChuongTrinh> Update(ChuongTrinh ctrinh);
        Task<ChuongTrinh> Delete(ChuongTrinh ctrinh);
        Task<ChuongTrinh> GetById(int id);
    }
}

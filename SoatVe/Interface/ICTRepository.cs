using Microsoft.AspNetCore.Mvc;
using SoatVe.Models;
using SoatVe.Models.DTO;

namespace SoatVe.Interface
{
    public interface ICTRepository
    {
        Task<IEnumerable<CTDto>> GetChuongTrinhs();

        Task<IEnumerable<ChuongTrinh>> Search(string? ten, string? ddiem);
        
        Task<ChuongTrinh> Create(ChuongTrinh ctrinh);
        Task<ChuongTrinh> Update(ChuongTrinh ctrinh);
        Task<ChuongTrinh> Delete(ChuongTrinh ctrinh);
        Task<ChuongTrinh> GetById(int id);

        //Task<ChuongTrinh> GetTieu_Diem();

    }
}

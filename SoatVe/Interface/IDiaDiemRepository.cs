﻿using SoatVe.Models.DTO;
using SoatVe.Models;

namespace SoatVe.Interface
{
    public interface IDiaDiemRepository
    {
        Task<IEnumerable<DDiemDto>> GetDiaDiems();
        Task<DiaDiem> Create(DiaDiem ddiem);
        Task<DiaDiem> Update(DiaDiem ddiem);
        Task<DiaDiem> Delete(DiaDiem ddiem);
        Task<DiaDiem> GetById(Guid id);
    }
}
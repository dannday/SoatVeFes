using SoatVe.Models;
using SoatVe.Models.DTO;

namespace SoatVe.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<CTDto>> GetUsers();
        Task<User> Create(User user);
        Task<User> Update(User user);
        Task<User> Delete(User user);
        Task<User> GetById(int id);

        //Task<User> GetTieu_Diem();

    }
}

using SoatVe.Models;
using SoatVe.ViewModel;

namespace SoatVe.Services
{
    public interface IUserRepository
    {

        Task<string> Authencate(ViewModel.LoginRequest request);
        Task<bool> Register(ViewModel.RegisterRequest request);

        //Task<IEnumerable<UserVM>> GetUsers();
        Task<IEnumerable<User>> Search(string ten);

        //Task<User> Create(User user);
        Task<User> Update(User user);
        Task<User> Delete(User user);
        Task<User> GetById(int id);

        //Task<User> GetTieu_Diem();

       

    }
}

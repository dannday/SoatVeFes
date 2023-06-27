using Microsoft.EntityFrameworkCore;

namespace SoatVe.Models
{

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sdt { get; set; }
    }


    public class UpdateUserRequest
    {
        public string Name { get; set; }
        public string Sdt { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SoatVe.Models
{

    public class User 
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public string Sdt { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }

       
    }


   
}

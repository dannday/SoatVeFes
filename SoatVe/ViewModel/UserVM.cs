﻿using System.ComponentModel.DataAnnotations;

namespace SoatVe.ViewModel
{
    public class UserVM
    
    {
    }


    public class RegisterRequest
    {
        [Required]
        public string Ten { get; set; }
        [Required]
        public string Sdt { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }

    }

    public class LoginRequest
    {
        public string Sdt { get; set; }
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }

    public class UpdateUserRequest
    {
        public string Ten { get; set; }

        public string Sdt { get; set;}
        public string Password { get; set;}
        public string Email { get; set;}
    }
}

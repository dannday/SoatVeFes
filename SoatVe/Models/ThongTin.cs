﻿namespace SoatVe.Models
{
    public class ThongTin
    {
        public int Id { get; set; }
        public string Ten { get; set; }

    }

    public class AddThongTinRequest
    {
        public string Ten { get; set; }
    }
    public class UpdateThongTinRequest
    {
        public string Ten { get; set; }
    }

}
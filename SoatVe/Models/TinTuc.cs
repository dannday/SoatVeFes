﻿namespace SoatVe.Models
{
    public class TinTuc
    {
        
        public Guid Id { get; set; }
        public string Ten { get; set; }
        public string HinhAnh { get; set; }
        public string NoiDung { get; set; }

        public DateTime NgayDang { get; set; }
    }

    public class AddTinTucRequest
    {
        public string Ten { get; set; }
        public string HinhAnh { get; set; }
        public string NoiDung { get; set; }
        public DateTime NgayDang { get; set; }
    }

    public class UpdateTinTucRequest
    {
        public string Ten { get; set; }
        public string HinhAnh { get; set; }
        public string NoiDung { get; set; }
        public DateTime NgayDang { get; set; }
    }

}

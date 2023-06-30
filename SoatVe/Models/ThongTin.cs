using Microsoft.EntityFrameworkCore;

namespace SoatVe.Models
{
   
    public class ThongTin
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public string NoiDung { get; set; }

    }

    //public class AddThongTinRequest
    //{
    //    public string Ten { get; set; }
    //}
    //public class UpdateThongTinRequest
    //{
    //    public string Ten { get; set; }
    //}

}

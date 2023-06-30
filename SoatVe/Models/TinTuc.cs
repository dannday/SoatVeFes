using Microsoft.EntityFrameworkCore;

namespace SoatVe.Models
{
   
    public class TinTuc
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public string HinhAnh { get; set; }
        public string NoiDung { get; set; }
        public DateTime NgayDang { get; set; }
    }

   

}

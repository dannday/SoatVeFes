using Microsoft.EntityFrameworkCore;

namespace SoatVe.Models
{
  
    public class Ve
    {
        public int Id { get; set; }

        public DateTime NgayDien { get; set; }
        public int Soluong { get; set; }
        public string GiaVe { get; set; }
        public string QRCode { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }

    }




    




}



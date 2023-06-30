using SoatVe.Models;
using System.ComponentModel.DataAnnotations;

namespace SoatVe.ViewModel
{
    public class VeVM
    {

        public DateTime NgayDien { get; set; }
        public string GiaVe { get; set; }
       

        
    }


    public class AddVe
    {
        [Required]
        public DateTime NgayDien { get; set; }
        [Required]
        public int Soluong { get; set; }
        [Required]
        public string GiaVe { get; set; }
        [Required]
        public string QRCode { get; set; }
       public int ChuongTrinhId { get; set; }
        public int? UserId { get; set; }

    }


    public class UpdateVe
    {
        public DateTime NgayDien { get; set; }
        public int Soluong { get; set; }
        public string GiaVe { get; set; }
        public string QRCode { get; set; }

    }

}

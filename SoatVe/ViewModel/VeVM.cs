using SoatVe.Models;

namespace SoatVe.ViewModel
{
    public class VeVM
    {

        public DateTime NgayDien { get; set; }
        public string GiaVe { get; set; }
        public string QRCode { get; set; }

        
    }


    public class AddVe
    {

        public DateTime NgayDien { get; set; }
        public int Soluong { get; set; }
        public string GiaVe { get; set; }
        public string QRCode { get; set; }

    }


    public class UpdateVe
    {
        public DateTime NgayDien { get; set; }
        public int Soluong { get; set; }
        public string GiaVe { get; set; }
        public string QRCode { get; set; }

    }

}

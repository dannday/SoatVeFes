namespace SoatVe.Models
{
    public class Ve
    {
        public Guid Id { get; set; }

        public DateTime NgayDien { get; set; }
        public int Soluong { get; set; }
        public string GiaVe { get; set; }
        public string QRCode { get; set; }

        
    }


    public class AddVeRequest
    {
        public DateTime NgayDien { get; set; }
        public int Soluong { get; set; }
        public string GiaVe { get; set; }
        public string QRCode { get; set; }
    }

    public class UpdateVeRequest
    {
        public DateTime NgayDien { get; set; }
        public int Soluong { get; set; }
        public string GiaVe { get; set; }
    }




}



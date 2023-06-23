namespace SoatVe.Models
{
    public class ChuongTrinh
    {
        public Guid Id { get; set; }
        public string Ten { get; set; }
        public string DiaDiem { get; set; }

        public string HinhAnh { get; set; }
        public string MoTa { get; set; }

        public string Gia { get; set; }

    }

    public class ChuongTrinhDetails
    {
        public Guid Id { get; set; }
        public string Ten { get; set; }
        public string DiaDiem { get; set; }
        public string HinhAnh { get; set; }

    }

    public class AddChuongTrinhRequest
    {
        public string Ten { get; set; }
        public string DiaDiem { get; set; }
        public string HinhAnh { get; set; }
        public string MoTa { get; set; }
        public string Gia { get; set; }
    }

    public class UpdateChuongTrinhRequest
    {
        public string Ten { get; set; }
        public string DiaDiem { get; set; }
        public string HinhAnh { get; set; }
        public string MoTa { get; set; }
        public string Gia { get; set; }
    }

}

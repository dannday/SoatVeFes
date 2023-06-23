    namespace SoatVe.Models
{
    public class DiaDiem
    {
        public Guid Id { get; set; }
        public string Ten { get; set; }
        public string HinhAnh { get; set; }
        public string NoiDung { get; set; }

    }

    public class MNDiaDiem
    {
        public Guid Id { get; set; }
        public string Ten { get; set; }
        public string HinhAnh { get; set; }

    }

    public class DiaDiem_Details
    {
        public string Ten { get; set; }
        public string HinhAnh { get; set; }
        public string NoiDung { get; set; }

    }

    public class AddDiaDiemRequest
    {
        public string Ten { get; set; }
        public string HinhAnh { get; set; }
        public string NoiDung { get; set; }

    }

    public class UpdateDiaDiemRequest
    {
        public string Ten { get; set; }
        public string HinhAnh { get; set; }
        public string NoiDung { get; set; }

    }


}

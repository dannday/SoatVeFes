
namespace SoatVe.ViewModel
{
    public class CTVM
    {
        public string Ten { get; set; }

        public string HinhAnh { get; set; }
        public string TenDD { get; set; }

    }

    public class CTVM_Details
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        
        public string HinhAnh { get; set; }
        public string MoTa { get; set; }
        //public int type_progame { get; set; }
        public string TenDD { get; set; }

        public DateTime NgayDien { get; set; }
        public string GiaVe { get; set; }
    }




    public class AddChuongTrinh
    {
        public string TenCT { get; set; }
        public string HinhAnh { get; set; }
        public string MoTa { get; set; }
        public int type_progame { get; set; }
        public int DiaDiemId { get; set; }
        public int? VeId { get; set; }
    }


    public class UpdateChuongTrinh
    {
        public string TenCT { get; set; }
        
        public string HinhAnh { get; set; }
        public string MoTa { get; set; }
        public int type_progame { get; set; }
    }

   


}

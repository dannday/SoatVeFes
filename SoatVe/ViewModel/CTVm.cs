
using System.ComponentModel.DataAnnotations;

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
        
        public string Ten { get; set; }
        
        public string HinhAnh { get; set; }
        public string MoTa { get; set; }
        
        public string TenDD { get; set; }

        public DateTime NgayDien { get; set; }
        public string GiaVe { get; set; }
    }




    public class AddChuongTrinh
    {
        [Required]
        public string TenCT { get; set; }
        [Required]
        public string HinhAnh { get; set; }
        [Required]
        public string MoTa { get; set; }
        [Required]
        public int type_progame { get; set; }
        [Required]
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

using System.ComponentModel.DataAnnotations;

namespace SoatVe.ViewModel
{
    public class DiaDiemVM
    {
        public string Ten { get; set; }
        public string HinhAnh { get; set; }

    }

    public class DiaDiem_Details
    {
        public string Ten { get; set; }
        public string HinhAnh { get; set; }
        public string MoTa { get; set; }
    }


    public class AddDiaDiem
    {
        [Required]
        public string Ten { get; set; }
        [Required]
        public string HinhAnh { get; set; }
        [Required]
        public string MoTa { get; set; }
    }

    
    public class UpdateDiaDiem
    {
        
        public string Ten { get; set; }
        public string HinhAnh { get; set; }
        public string MoTa { get; set; }

    }

}

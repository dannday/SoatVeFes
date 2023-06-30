using System.ComponentModel.DataAnnotations;

namespace SoatVe.ViewModel
{
    public class TinTucVM
    {
        public string Ten { get; set; }
        public string HinhAnh { get; set; }
        public DateTime NgayDang { get; set; }
    }

    public class AddTinTuc
    {
        [Required]
        public string Ten { get; set; }
        [Required]
        public string HinhAnh { get; set; }
        [Required]
        public string NoiDung { get; set; }
        [Required]
        public DateTime NgayDang { get; set; }

    } 

    public class UpdateTinTuc
    {
        public string Ten { get; set; }
        public string HinhAnh { get; set; }
        public string NoiDung { get; set; }
        public DateTime NgayDang { get; set; }
    }

}

using System.ComponentModel.DataAnnotations;

namespace SoatVe.ViewModel
{
    public class ThongTinVM
    {
        public string Ten { get; set; }

    }


    public class AddThongTin
    {
        [Required]
        public string Ten { get; set; }
        [Required]
        public string NoiDung { get; set; }
    }

    public class UpdateThongTin
    {
        public string Ten { get; set; }
        public string NoiDung { get; set; }
    }

}

using Castle.Components.DictionaryAdapter;
using Microsoft.EntityFrameworkCore;

namespace SoatVe.Models
{
    
    public class ChuongTrinh
    {
        
        public int Id { get; set; }
        public string Ten { get; set; }
        public string DiaDiem { get; set; }

        public string HinhAnh { get; set; }
        public string MoTa { get; set; }

        public int type_progame { get; set; }

       

    }

    public class ChuongTrinhDetails
    {
        public int CTId { get; set; }
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
        public int type_progame { get; set; }


    }

    public class UpdateChuongTrinhRequest
    {
        public string Ten { get; set; }
        public string DiaDiem { get; set; }
        public string HinhAnh { get; set; }
        public string MoTa { get; set; }
    }

}

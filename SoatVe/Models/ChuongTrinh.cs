using Castle.Components.DictionaryAdapter;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace SoatVe.Models
{
    
    public class ChuongTrinh
    {
        
        public int Id { get; set; }
        public string Ten { get; set; }
        public string HinhAnh { get; set; }
        public string MoTa { get; set; }
        public int type_progame { get; set; }
        public int DiaDiemId { get; set; }
       public virtual DiaDiem DiaDiem { get; set; }

        public int? VeId { get; set; }
        public virtual Ve Ve { get; set; }

    }

  



}

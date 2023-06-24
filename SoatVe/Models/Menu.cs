namespace SoatVe.Models
{
    public class Menu
    {
        public Guid Id { get; set; }
        public string Ten { get; set; }

    }

    public class AddMenuRequest
    {
        public string Ten { get; set; }
    }
    public class UpdateMenuRequest
    {
        public string Ten { get; set; }
    }

}

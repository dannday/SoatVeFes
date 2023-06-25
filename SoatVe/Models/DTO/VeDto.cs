namespace SoatVe.Models.DTO
{
    public class VeDto
    {
        public int Id { get; set; }
        public DateTime NgayDien { get; set; }

        public string QRCode { get; set; }

        public virtual ChuongTrinh ChuongTrinh { get; set; }
    }
}

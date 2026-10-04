namespace BSNU_Api.Dtos
{
    public class SectorDto
    {
        public string NameEn { get; set; } = null!;
        public string? NameAr { get; set; }
        public string SubTitleAr { get; set; } = null!;
        public string SubTitleEn { get; set; } = null!;
        public string Image { get; set; }
        public string DeanName { get; set; }
        public string DeanId { get; set; }
    }
}

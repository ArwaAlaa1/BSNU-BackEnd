namespace BSNUDashboard.ViewsModels
{
    public class CategoryVM
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public IFormFile ImageFile { get; set; }
        public string? Image { get; set; }
    }
}

namespace PruebaJR.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int AutorId { get; set; }
        public string AutorName { get; set; } = string.Empty;
    }
}

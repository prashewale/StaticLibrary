namespace StaticLibrary.WebUI.Models
{
    public class Book : FullAuditModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}

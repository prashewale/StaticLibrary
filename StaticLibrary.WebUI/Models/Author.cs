namespace StaticLibrary.WebUI.Models
{
    public class Author : FullAuditModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public virtual List<Book> Books { get; set; }
    }
}

namespace EasyBlog.Data
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        // Navigation property
        public List<Post> Posts { get; set; } = new List<Post>();
    }
}

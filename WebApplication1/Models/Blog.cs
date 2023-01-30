namespace WebApplication1.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Author { get; set; } = null!;
        public DateTime RealyaseDate { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public string Image { get; set; } = null!;  

        public List<Comment> Comments { get; set; }

        public Blog()
        {
            Comments = new List<Comment>();
        }


    }
}

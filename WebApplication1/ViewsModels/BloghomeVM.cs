using WebApplication1.Models;

namespace WebApplication1.ViewsModels
{
    public class BloghomeVM
    {
        public List<Blog> Blogs { get; set; }
        public List<Comment> Comments { get; set; }
    }
}

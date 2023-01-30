using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class WebApplicationContext:DbContext
    {
        public WebApplicationContext(DbContextOptions<WebApplicationContext> options) : base(options) { }
       
        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Comment> Comments { get; set; }     


    }
}

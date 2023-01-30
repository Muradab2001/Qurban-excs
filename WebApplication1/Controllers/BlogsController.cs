using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.ViewsModels;

namespace WebApplication1.Controllers
{
    public class BlogsController : Controller
    {
        WebApplicationContext _context;
        public BlogsController(WebApplicationContext context) 
        { _context = context; }  
        public IActionResult Index()
        {
            List<Blog> blogs = _context.Blogs.ToList();  
            if(blogs is null) return NotFound();
            BloghomeVM vm = new BloghomeVM { 
            
            Blogs= blogs,
            Comments= _context.Comments.ToList(),
            };
            return View(blogs);
        }
        public IActionResult delete(int id,int commnetid)
        {
            Comment existed=_context.Comments.FirstOrDefault(c=>c.ID==commnetid);
            if(existed==null) return NotFound();
            _context.Remove(existed);
            _context.SaveChanges();
            return RedirectToAction("details", "Blogs", new { id = id });
        }
        public IActionResult Details(int? id)
        {
            if (id is null) return NotFound();
            Blog blogs = _context.Blogs.Include(x=>x.Comments).FirstOrDefault(x=>x.Id==id);
            ViewBag.Recent=_context.Blogs.Where(b=>b.Id!=id).ToList();
            if (blogs is null) return NotFound();
            return View(blogs);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult comment(Comment comment,int id) 
        {
            Comment existed = new Comment
            {
                BlogId=id,
                Date= DateTime.Now,
                Message=comment.Message,
                User=comment.User,
            };
            _context.Comments.Add(existed);
            _context.SaveChanges();
            return RedirectToAction("details", "Blogs", new { id = id });
        }
    }
}

namespace WebApplication1.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public string User { get; set; } = null!;
        public string Message { get; set; } = null!;
        public DateTime Date { get; set; } 

        public int BlogId { get; set; }
        public Blog Blog { get; set; }  
    }
}

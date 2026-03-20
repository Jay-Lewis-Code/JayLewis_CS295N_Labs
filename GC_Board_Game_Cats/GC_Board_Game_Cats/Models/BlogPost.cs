namespace GC_Board_Game_Cats.Models
{
    public class BlogPost
    {
        public int BlogPostId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public DateTime DatePosted { get; set; }
        public int Rating { get; set; }
    }
}

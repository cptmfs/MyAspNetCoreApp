namespace MyAspNetCoreApp.Web2.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string LessonName { get; set; }
        public string LessonDescription { get; set;}
        public int LessonHour { get; set; }
        public decimal Price { get; set; }
    }
}

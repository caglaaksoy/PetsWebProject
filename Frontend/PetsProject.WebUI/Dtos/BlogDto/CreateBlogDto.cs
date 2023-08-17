using System;

namespace PetsProject.WebUI.Dtos.BlogDto
{
    public class CreateBlogDto
    {
        public string MainTitle { get; set; }
        public string BlogTitle { get; set; }
        public string Writer { get; set; }
        public string BlogPhotoUrl { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}

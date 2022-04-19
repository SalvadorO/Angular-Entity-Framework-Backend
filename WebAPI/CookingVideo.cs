

namespace WebAPI
{
    public class CookingVideo
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
           
        public bool IsHidden { get; set; } = false;       

        public int CategoryId { get; set; }
        public Category? CategoryName { get; set; }

    }
}


 namespace WebAPI
{
    public class Category
    {
        public int Id { get; set; }

        public string CategoryName { get; set; } = String.Empty;

        public bool IsActive { get; set; } = true;
    }
}

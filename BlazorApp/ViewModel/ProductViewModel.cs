namespace BlazorApp.ViewModel
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<string> CategoryNames { get; set; } = new List<string>();
    }
}

namespace FoodOrdering.MVC.ViewModels
{
    public class AuthResponseViewModel
    {
        public string Token { get; set; }
            = string.Empty;

        public DateTime Expiration { get; set; }

        public List<string> Roles
        { get; set; } = new();
    }
}
namespace BlazorApp.Models
{
    public class User
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }

        public string token { get; set; }
        public string code { get; set; }
        public bool IsDeleting { get; set; }
        public string message { get; set; }
    }
}
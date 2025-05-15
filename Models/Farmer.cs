namespace Agri_Energy.Models
{
    public class Farmer
    {
        public int FarmerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Password { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}

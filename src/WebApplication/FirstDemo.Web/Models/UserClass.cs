namespace FirstDemo.Web.Models
{
    public class UserClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; } 



        public decimal Sum(decimal a, decimal b)
        {
            return a * b;
        }
    }
}

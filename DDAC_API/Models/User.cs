namespace DDAC_API.Models
{
    public class User
    {
        public User()
        {
            Status = 1;
        }

        public int UserId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int Role { get; set; }

        public int Status { get; set; }

        public Staff Staff { get; set; }

        public Admin Admin { get; set; }

        public Customer Customer { get; set; }

    }
}

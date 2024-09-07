namespace RememberTask.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public int IsVerify { get; set; }
        //verifi - bool
        public int RoleId { get; set; }
        public Role? Role { get; set; }

    }
}
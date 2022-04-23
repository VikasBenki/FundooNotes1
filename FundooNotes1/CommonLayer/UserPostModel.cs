using System;

namespace CommonLayer
{
    public class UserPostModel
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
    }
}

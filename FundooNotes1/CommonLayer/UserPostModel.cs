using System;
using System.ComponentModel.DataAnnotations;

namespace CommonLayer
{
    public class UserPostModel
    {
       
        public int UserID { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{1}[a-z]{4,}$", ErrorMessage = "name starts with Cap and has minimum 8 characters")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{1}[a-z]{4,}$", ErrorMessage = "name starts with Cap and has minimum 8 characters")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]{3,}([._+-][a-zA-Z0-9]{1,})?@[a-zA-Z0-9]{1,10}[.][a-zA-Z]{2,3}([.][a-zA-Z]{2,3})?$", ErrorMessage = "Email Id is not valid")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public DateTime RegisterDate { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[&%$#@?^*!~]).{8,}$", ErrorMessage = "Passsword is not valid")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Address { get; set; }
    }
}

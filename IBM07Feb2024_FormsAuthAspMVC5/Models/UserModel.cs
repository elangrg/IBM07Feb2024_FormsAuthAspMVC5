using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace IBM07Feb2024_FormsAuthAspMVC5.Models
{
    public class UserModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
    public class CurrentUserModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }

        public string Role { get; set; }
        public int? ReferenceToId { get; set; }
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
    }
}
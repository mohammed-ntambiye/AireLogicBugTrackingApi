using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AireLogicBugTrackingApi.Models
{
    public class UserModel
    {
        [Key]
        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Department { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}

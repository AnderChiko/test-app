
using System.ComponentModel.DataAnnotations;

namespace Test.BusinessLogic.Models
{
    public class User
    {
        public int Id { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        [StringLength(256)]
        public string Surname { get; set; }

        [StringLength(256)]
        public string UserName { get; set; }

        [StringLength(256)]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
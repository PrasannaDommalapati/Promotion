using System.ComponentModel.DataAnnotations;

namespace Promotion.Models
{
    public class Post
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public string Avatar { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models
{
    /// <summary>
    /// UserModel represents the model for a user.
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// UserId represents the unique identifier for the user.
        /// </summary>
        [Key]
        public Guid UserId { get; set; }

        /// <summary>
        /// Name represents the name of the user.
        /// </summary>
        public string? Name { get; set; }
    }
}

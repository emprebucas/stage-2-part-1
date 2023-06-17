using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Entities
{
    /// <summary>
    /// The UserEntity represents a real world user and defines the properties and 
    /// attributes associated with a user, such as the user's ID and name.
    /// </summary>
    public class UserEntity
    {
        /// <summary>
        /// The UserId, a primary key in GUID.
        /// </summary>
        [Key]
        public Guid UserId { get; set; }

        /// <summary>
        /// The user's name in string.
        /// </summary>
        public string? Name { get; set; }
    }
}

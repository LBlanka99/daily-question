using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class UserModel
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Email { get; set; }
    [DefaultValue(0)]
    public int Streak { get; set; }
    public string ProfilePicture { get; set; }
}
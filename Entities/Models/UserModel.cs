using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Entities.Models;

public class UserModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [DefaultValue(0)]
    public int Streak { get; set; }
    public string? ProfilePicture { get; set; }
}
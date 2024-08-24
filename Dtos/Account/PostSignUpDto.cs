using System.ComponentModel.DataAnnotations;

namespace ASP.NET_SignalR.Dtos;

public class PostSignUpDto
{
    [Required]
    [MinLength(5, ErrorMessage = "{0} must be {1} characters")]
    [MaxLength(280, ErrorMessage = "{0} can not be over {1} characters")]
    public string FullName { get; set; } = string.Empty;
    public string? Address { get; set; }
    public DateTime? BirthDate { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "Your email address is not valid")]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MinLength(5, ErrorMessage = "{0} must be {1} characters")]
    [MaxLength(30, ErrorMessage = "{0} can not be over {1} characters")]
    public string UserName { get; set; } = string.Empty;

    [Required]
    [MinLength(5, ErrorMessage = "{0} must be {1} characters")]
    [MaxLength(30, ErrorMessage = "{0} can not be over {1} characters")]
    public string Password { get; set; } = string.Empty;
}